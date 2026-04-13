using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.UI.Xaml.Shapes;
using Windows.Media.Protection.PlayReady;

namespace Models
{
    public class ServiceGuichet
    {

        public Client ClientCourant;

        private string m_cheminFichierClients;
        private string m_cheminFichierTransaction;
        private List<Client> m_clients;
        private List<Transaction> m_transactions;

        public string CheminFichierClients { get { return m_cheminFichierClients; } }
        public string CheminFichierTransactions { get { return m_cheminFichierTransaction; }  }
        public List<Client> Clients { get { return m_clients; } }
        public List<Transaction> Transactions { get { return m_transactions; } }

        public ServiceGuichet(string pCheminFichierClients, string pCheminFichierTransactions)
        {
            //StreamReader inputFile = new StreamReader(pCheminFichierClients);
            //StreamReader inputFiles = new StreamReader(pCheminFichierTransactions);

            if (!File.Exists(pCheminFichierClients))
            {
                throw new ArgumentException(CheminFichierClients);
            }

            if (!File.Exists(pCheminFichierTransactions))
            {
                throw new ArgumentException(CheminFichierTransactions);
            }


            m_cheminFichierClients = pCheminFichierClients;
            m_cheminFichierTransaction = pCheminFichierTransactions;

            m_clients = new List<Client>();
            m_transactions = new List<Transaction>();

        }
        public int ChargerClients()
        {
            StreamReader reader = new StreamReader(m_cheminFichierClients);
            string ligne =string.Empty;
            int lignesErronees = 0;
            while ((ligne = reader.ReadLine()) != null)
            {
                try
                {
                    Client client = new Client(ligne);
                    Clients.Add(client);
                }
                catch (Exception)
                {
                    lignesErronees++;
                }
            }

            reader.Close();
            return lignesErronees;
        }

        public int ChargerTransactions()
        {
            {
                int lignesErronees = 0;
                StreamReader reader = new StreamReader(m_cheminFichierTransaction);
                string ligne = string.Empty;

                while ((ligne = reader.ReadLine()) != null)
                {
                    try
                    {

                        string[] parts = ligne.Split(',');

                        SorteTransactions sorteTransactions = parts[0] == "0" ? SorteTransactions.Dépôt : SorteTransactions.Retrait;
                        DateTime date = DateTime.Parse(parts[2]);
                        string pnumClient = parts[1];
                        int montant = int.Parse(parts[3]);

                        

                        CreerTransaction(sorteTransactions, pnumClient, date, montant); // adapte les paramètres
                    }
                    catch (Exception)
                    {
                        lignesErronees++;
                    }
                }

                reader.Close();
                return lignesErronees;
            } 
        
        }
        public bool Connexion(string numclient, string motDePasse)
        {
            Client client = TrouverClient(numclient);

            if (client == null)
            {
                return false; // client introuvable
            }

            if (client.MotDePasse == motDePasse)
            {
                ClientCourant = client; // connexion réussie
                return true;
            }
            return false;
        }
        public void CreerTransaction(SorteTransactions pSorte, string pNumClient, DateTime pDate, int pMontant)
        {
            Client clientTrouve = null;

            foreach (Client t in m_clients)
            {
                if (t.NumClient == pNumClient)
                {
                    clientTrouve = t;
                   
                }
            }

          
            if (clientTrouve == null)
            {
                throw new ArgumentException();
            }
           
            Transaction transaction = new Transaction(pSorte,pNumClient, pDate, pMontant);

            clientTrouve.AjouterTransaction(transaction);
            m_transactions.Add(transaction);
        }

        public bool Deconnexion() { 
        if (ClientCourant != null)
            {
                ClientCourant = null;
                
            }
        return true;
        }
        public bool Sauvegarde() {

            SauvegarderClients(CheminFichierClients);
            SauvegarderTransactions(CheminFichierTransactions);

            return true;
        }
        public void SauvegarderClients(string pFichier) {
        StreamWriter writer= new StreamWriter(pFichier);
            

            foreach (Client client in m_clients)
            {
                writer.WriteLine(client.ToCsv());
            }

            writer.Close();

        }
        public void SauvegarderTransactions(string pFichier) {
        
        StreamWriter writer = new StreamWriter(pFichier);
            foreach(Transaction t in m_transactions)
            {
                writer.WriteLine(t.ToCsv());
            }
            writer.Close ();
        }

       
        public Client TrouverClient(string pNumClient)
        {
            foreach (Client client in m_clients)
            {
                if (client.NumClient == pNumClient)
                {
                    return client; 
                }
            }

            return null; 
        }
    }

}

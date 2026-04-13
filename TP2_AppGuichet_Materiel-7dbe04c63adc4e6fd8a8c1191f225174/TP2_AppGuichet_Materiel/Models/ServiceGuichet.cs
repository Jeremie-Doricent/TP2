using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Models
{
    public class ServiceGuichet
    {

        private Client clientCourant;

        private string m_cheminFichierClients;
        private string m_cheminFichierTransaction;
        private List<Client> m_clients;
        private List<Transaction> m_transactions;

        public string CheminFichierClients { get { return m_cheminFichierClients; } set { } }
        public string CheminFichierTransaction { get { return m_cheminFichierTransaction; } set { } }
        public List<Client> Clients { get { return m_clients; } }
        public List<Transaction> Transactions { get { return m_transactions; } set { m_transactions = value; } }

        ServiceGuichet(string pCheminFichierClients, string pCheminFichierTransactions)
        {
            StreamReader inputFile = new StreamReader(pCheminFichierClients);
            StreamReader inputFiles = new StreamReader(pCheminFichierTransactions);

            // Validation des fichiers
            if (!File.Exists(pCheminFichierClients){
                throw new ArgumentException(); }

            if (!File.Exists(pCheminFichierTransactions){
                throw new ArgumentException(); }

            // Mémoriser les chemins
            m_cheminFichierClients = pCheminFichierClients;
            m_cheminFichierTransaction = pCheminFichierTransactions;

            // Initialiser les listes
            m_clients = new List<Client>();
            m_transactions = new List<Transaction>();
        }
        public int ChargerClient()
        {

        }
        public int ChargerTransaction()
        {

        }
        public bool Connexion(string numclient, string motDePasse)
        {

        }
        public bool CreeTransaction()
        {

        }
        public bool Deconnexion() { }
        public bool Sauvegarde() { }
        public void SauvegardeClients(string pFichier) { }
        public void SauvegardeTransaction(string pFichier) { }

        ServiceGuichet(string pCheminFichier)
        {
        }
        public Client TrouverClient()
        {

        }
    }

}
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AppGuichet.AppGuichet;

//namespace AppGuichet
//{
//   public class ServiceGuichet
//    {
//        public const string CHEMIN_FICHIER_SESSIONS = "Fichiers\\Sessions.csv";
//        public const string CHEMIN_FICHIER_TRANSACTIONS = "Fichiers\\Transactions.csv";
//        public const string CHEMIN_FICHIER_CLIENTS = "Fichiers\\Clients.csv";
//        public const string CHEMIN_FICHIER_COMPTES = "Fichiers\\Comptes.csv";
              


//        private List<Client> m_clients;
       
//        private List<Compte> m_comptes;
//        private List<Transaction> m_transactions;
//        public List<Transaction> Transactions
//        {
//            get { return m_transactions; }
//        }
//        private List<Session> m_sessions;
//        public Client ClientCourant;
//        public Session SessionCourante;

//        public ServiceGuichet()
//        {
//            m_clients = new List<Client>();
//            m_comptes = new List<Compte>();
//            m_transactions = new List<Transaction>();
//            m_sessions = new List<Session>();
           

//            ChargerClients(CHEMIN_FICHIER_CLIENTS);
//            ChargerComptes(CHEMIN_FICHIER_COMPTES);
//            ChargerTransactions(CHEMIN_FICHIER_TRANSACTIONS);
//            ChargerSessions(CHEMIN_FICHIER_SESSIONS);           



//        }

//        #region Chargement des données à partir des fihciers csv
//        public void ChargerTransactions(string pFichier)
//        {
//            foreach (string ligne in File.ReadAllLines(pFichier))
//            {
//                string[] infos = ligne.Split(',');

//                SorteTransactions sorte = (SorteTransactions)int.Parse(infos[0]);
//                string numCompte = infos[1];
//                DateTime date = DateTime.Parse(infos[2]);
//                int montant = int.Parse(infos[3]);

//                Compte compte = TrouverCompte(numCompte);

//                Transaction t = new Transaction(sorte, compte, date, montant);

//                m_transactions.Add(t);
//            }
//        }
//        public void ChargerSessions(string pFichier)
//        {
//            foreach (string ligne in File.ReadAllLines(pFichier))
//            {
//                string[] infos = ligne.Split(',');

               
//                string numClient = infos[0];
//                DateTime dateDebut = DateTime.Parse(infos[1]);
//                DateTime? dateFin=null;
//                if (infos[2]!="")
//                {
//                    dateFin = DateTime.Parse(infos[2]);
//                }
                

//                Client client = TrouverClient(numClient);

//                Session s = new Session(client, dateDebut, dateFin);

//                m_sessions.Add(s);
//            }
//        }
//        public void ChargerClients(string pFichier)
//        {
//            foreach (string ligne in File.ReadAllLines(pFichier))
//            {
              
//                Client client = new Client(ligne);

//                m_clients.Add(client);
//            }
//        }
//        public void ChargerComptes(string pFichier)
//        {
//            foreach (string ligne in File.ReadAllLines(pFichier))
//            {
//                string[] infos = ligne.Split(',');

//                string numCompte = infos[0];
//                SorteComptes sorteCompte = (SorteComptes)int.Parse(infos[1]);
//                int solde = int.Parse(infos[2]);

//                string numClient = infos[3];
//                Client client = TrouverClient(numClient);

//                Compte compte = new Compte(numCompte,sorteCompte, solde, client);
//                var x = m_clients;
//                m_comptes.Add(compte);
//            }
//        }
//        #endregion
//        public void CreerTransaction(SorteTransactions pSorte, string pNumCompte, DateTime pDate, int pMontant)
//        {

//            Compte compte = TrouverCompte(pNumCompte);
//            if (compte == null)
//            {
//                throw new ArgumentException("Le numéro du compte bancaire est invalide");
//            }
//            Transaction transaction = new Transaction(pSorte, compte, pDate,pMontant);
//            m_transactions.Add(transaction);
          
//        }
//        public void CreerTransaction(SorteTransactions pSorte, Compte pCompte, DateTime pDate, int pMontant)
//        {

//            Transaction transaction = new Transaction(pSorte, pCompte, pDate, pMontant);
//            m_transactions.Add(transaction);

//        }
//        #region Sauvegarde
//        public bool Sauvegarde()
//        {
//            SauvegarderTransactions(CHEMIN_FICHIER_TRANSACTIONS);

//            SauvegarderSessions(CHEMIN_FICHIER_SESSIONS);
//            SauvegarderClients(CHEMIN_FICHIER_SESSIONS);

//            SauvegarderComptes(CHEMIN_FICHIER_SESSIONS);

//            return true;
//        }
//        public void SauvegarderTransactions(string pFichier)
//        {
//            StreamWriter writer = new StreamWriter(pFichier);

//            foreach (Transaction t in m_transactions)
//            {
//                writer.WriteLine(t.ToString());
//            }

//            writer.Close();
//        }
//        public void SauvegarderSessions(string pFichier)
//        {
//            StreamWriter writer = new StreamWriter(pFichier);

//            foreach (Session s in m_sessions)
//            {
//                writer.WriteLine(s.ToString());
//            }

//            writer.Close();
//        }
//        public void SauvegarderClients(string pFichier)
//        {
//            StreamWriter writer = new StreamWriter(pFichier);

//            foreach (Client c in m_clients)
//            {
//                writer.WriteLine(c.ToString());
//            }

//            writer.Close();
//        }
//        public void SauvegarderComptes(string pFichier)
//        {
//            StreamWriter writer = new StreamWriter(pFichier);

//            foreach (Compte c in m_comptes)
//            {
//                writer.WriteLine(c.ToString());
//            }

//            writer.Close();
//        }
//        #endregion
//        #region Connexion-Déconnexion
//        public bool Connexion(string numClient, string motDePasse)
//        {
//            Client client = TrouverClient(numClient);
//            if (client == null)
//            {
//                return false;
//            }
//            if (client.MotDePasse==motDePasse)
//            {
//                Session session = new Session(client);
//                m_sessions.Add(session);
//                ClientCourant = client;
//                return true;
//            }
           
            
//            return false;
//        }
//        public bool Deconnexion()
//        {
//            //SessionCourante.Terminer();
//            //bool sucess = Sauvegarde();
//            ClientCourant = null;
//            return true;
//        }
//        #endregion
       
//        #region Utilitaires
//        public Compte TrouverCompte(string pNumCompte)
//        {
//            foreach (Compte c in m_comptes)
//            {
//                if (c.NumCompte == pNumCompte)
//                    return c;
//            }

//            return null;
//        }
//        public Client TrouverClient(string pNumClient)
//        {
//            foreach (Client c in m_clients)
//            {
//                if (c.NumClient == pNumClient)
//                    return c;
//            }

//            return null;
//        }
//        #endregion

//    }
//}

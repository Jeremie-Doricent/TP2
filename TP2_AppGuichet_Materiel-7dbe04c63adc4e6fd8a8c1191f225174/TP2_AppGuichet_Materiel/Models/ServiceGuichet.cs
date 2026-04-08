using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List <Transaction> Transactions { get { return m_transactions; } }

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

        ServiceGuichet(string pCheminFichier ) {
        }
        public  Client TrouverClient()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        private string m_motDePasse;
        private string m_nom;
        private string m_numClient;
        private Roles m_role;
        private int m_solde;
        private SorteComptes m_sorteComptes;
        const int MAX_SOLDE = 1000000;

        public bool IsAdmin { get { if (m_role == Roles.Administrateur) 
                { 
                return true;
                }
                return false;
            }
        }
        public string MotDePasse { get { return m_motDePasse; } }
        public string Nom { get { return m_nom; } }
        public string NumClient { get { return m_numClient; } 
            private set {
                if (value == null) { throw new ArgumentNullException(); }

                if (value.Trim().Length != 6)
                {
                    throw new ArgumentException();
                }

                value = value.Trim();
                NumClient = value;
            } 
        }
        public Roles Role { get { return m_role; } }
        public int Solde { get { return m_solde; }
            private set
            {
                if (value < 0)
                { throw new InvalidOperationException(); }
                if(value> MAX_SOLDE)
                {
                    throw new InvalidOperationException();
                }
            }
            
        }
        public SorteComptes SorteComptes { get { return m_sorteComptes; } }
        public List<Transaction> Transaction { get  }
        


        public void AjouterTransaction(Transaction pTransaction)
        {

        }
        public  Client(string pChaineLue)
        {
            int sortetransaction = m_sorteTransaction == SorteTransactions.Dépôt ? 0 : 1;
            pChaineLue = $"{NumClient},{Nom},{MotDePasse},{Role},"

        }
        public  Client(string pNumClient, string pNom, string pMotDePasse, Roles PRole,SorteComptes pSorte , int pSolde)
        {

        }
        public void Deposer(int Montant)
        {

        }
        public bool PeutRetirer(int montant)
        {

        }
        public string toCsv() {
        
        }
    }
}

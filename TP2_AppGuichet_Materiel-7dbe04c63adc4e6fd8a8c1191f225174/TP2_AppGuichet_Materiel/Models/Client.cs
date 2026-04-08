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
        public string MotDePasse { get { return m_motDePasse; } private set { m_motDePasse = value; } }
        public string Nom { get { return m_nom; }private set { m_nom = value; } }
        public string NumClient { get { return m_numClient;  } 
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
        public Roles Role { get { return m_role; } set { } }
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
        public SorteComptes SorteComptes { get { return m_sorteComptes; } private set { } }
        public List<Transaction> Transaction { get  }



        public void AjouterTransaction(Transaction pTransaction)
        {
            if(pTransaction == null)
            {
                throw new ArgumentNullException();
            }
            if(pTransaction.NumClient != NumClient)
            {
                throw new InvalidOperationException();
            }
            if (Transaction.Contains(pTransaction)) {

                throw new InvalidOperationException();
            }
        }
        public Client(string pChaineLue)
        {
            string[] parties = pChaineLue.Split(',');

            NumClient = parties[0];
            Nom = parties[1];
            MotDePasse = parties[2];
            Role = (Roles)int.Parse(parties[3]);
            SorteComptes = (SorteComptes)int.Parse(parties[4]);
            Solde = int.Parse(parties[5]);
        }
        public  Client(string pNumClient, string pNom, string pMotDePasse, Roles Prole,SorteComptes pSorte , int pSolde)
        {
            
        }
        public void Deposer(int Montant)
        {  Solde += Montant;
            if(Montant < 0) { throw new ArgumentOutOfRangeException(); }
            if (Montant > MAX_SOLDE) { throw new InvalidOperationException(); }
          
        }
        public bool PeutRetirer(int montant)
        {
            Solde -= montant;
            if(montant < Solde) {  return true; }
            return false;
        }
        public string toCsv()
        {
            int roleInt = (int)Role;
            int sortecompte = (int)SorteComptes;
            Role = (Roles)int.Parse();
            return $"{NumClient}, {Nom} , {MotDePasse},{roleInt},{sortecompte},{Solde}";
                    
                    
        }
    }
}

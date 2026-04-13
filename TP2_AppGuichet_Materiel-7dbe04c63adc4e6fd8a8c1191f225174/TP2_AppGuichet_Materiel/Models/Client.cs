using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
       
        public const int MAX_SOLDE = 1000000;

        public bool IsAdmin { get { if (m_role == Roles.Administrateur) 
                { 
                return true;
                }
                return false;
            }
        }
        public string MotDePasse { get { return m_motDePasse; } private set { m_motDePasse = value; } }
        public string Nom { get { return m_nom; }
            
            private set { 
               if(value == null)
                {
                    throw new ArgumentNullException();
                }
                if(value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                m_nom = value; } }
        public string NumClient 
        { 
            get
            { 
                return m_numClient;
            } 
             set 
            {
                if (value == null)
                { 
                    throw new ArgumentNullException();
                }

                if (value.Trim().Length != 6)
                {
                    throw new ArgumentException();
                }

                if (!int.TryParse(value, out int nombre))
                {
                    throw new ArgumentException();
                }
                value = value.Trim();
                m_numClient = value;
            } 
        }
        public Roles Role
        {
            get
            { 
                return m_role; }
            set
            {
                m_role = value;
            }
        }
        public int Solde { get { return m_solde; }
          set
            {
                if (value < 0)
                { throw new InvalidOperationException(); }
                if(value> MAX_SOLDE)
                {
                    throw new InvalidOperationException();
                }
                m_solde = value;
            }
            
        }
        public SorteComptes SorteCompte { get { return m_sorteComptes; } private set { m_sorteComptes = value; } }
         public List<Transaction> Transactions { get;   set ; }



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
            if (Transactions.Contains(pTransaction))
            {
                throw new InvalidOperationException();
            }

            Transactions.Add(pTransaction);


        }
        public Client(string pChaineLue)
        {
            string[] parties = pChaineLue.Split(',');

            NumClient = parties[0];
            Nom = parties[1];
            MotDePasse = parties[2];
            Role = (Roles)int.Parse(parties[3]);
            SorteCompte = (SorteComptes)int.Parse(parties[4]);
            Solde = int.Parse(parties[5]);
            Transactions = new List<Transaction>();
        }
        public  Client(string pNumClient, string pNom, string pMotDePasse, Roles Prole,SorteComptes pSorte , int pSolde)
        {
            NumClient = pNumClient;
            Nom = pNom;
            MotDePasse= pMotDePasse;
            Role = Prole;
            SorteCompte = pSorte;
            Solde = pSolde;
         Transactions = new List<Transaction>();
        }
        public void Deposer(int Montant)
        {  
            if(Montant <= 0) { throw new ArgumentOutOfRangeException(); }
            if (Montant > MAX_SOLDE) { throw new InvalidOperationException(); }
            Solde += Montant;

        }
        public bool PeutRetirer(int montant)
        {
           
            if(montant < Solde) return true;
            
            return false;

        }
        public void Retirer(int pMontant)
        {
            if (pMontant <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (pMontant > Solde) {
            throw new InvalidOperationException();
            
            }
            Solde -= pMontant;
        }
        public string ToCsv()
        {
            int roleInt = (int)Role;
            int sortecompte = (int)SorteCompte;
          
            return $"{NumClient}, {Nom} , {MotDePasse},{roleInt},{sortecompte},{Solde}";
                    
                    
        }
    }
}

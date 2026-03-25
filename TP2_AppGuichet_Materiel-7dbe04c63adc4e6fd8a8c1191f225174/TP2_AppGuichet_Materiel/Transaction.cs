//using System;
//using System.Collections.Generic;

//namespace AppGuichet
//{
//    public class Transaction
//    {
//        private SorteTransactions m_sorteTransaction;
//        public SorteTransactions SorteTransaction
//        {
//            get { return m_sorteTransaction; }
//        }

//        private DateTime m_date;
//        public DateTime Date
//        {
//            get { return m_date; }
//        }

//        private Compte m_compte;
//        public Compte Compte
//        {
//            get { return m_compte; }
//        }

//        private int m_montant;
//        public int Montant
//        {
//            get { return m_montant; }
//        }

//        public Transaction(SorteTransactions pSorte, Compte pCompte, DateTime pDate, int pMontant)
//        {
//            m_sorteTransaction = pSorte;
//            m_compte = pCompte;
//            m_date = pDate;
//            m_montant = pMontant;
//            pCompte.Transactions.Add(this);
           
//        }
//        //public Transaction(string pChaineLue, List<Compte> pComptes)
//        //{
//        //    string[] tabInfos = pChaineLue.Split(',');
//        //    m_sorteTransaction = (SorteTransactions)int.Parse(tabInfos[0]);
//        //    m_numClient = tabInfos[1];
//        //    m_date = DateTime.Parse(tabInfos[2]);
//        //    int leMontant = int.Parse(tabInfos[3]);
//        //    //if (SorteTransaction == SorteTransactions.Retrait && leMontant < 0)
//        //    //    throw new ArgumentException();
//        //    //if ((SorteTransaction == SorteTransactions.Connexion || SorteTransaction == SorteTransactions.Déconnexion) && leMontant != 0)
//        //    //    throw new ArgumentException();
//        //    m_montant = leMontant;

//        //}
      
//        public override string ToString()
//        {
//            return (int)m_sorteTransaction + ","
//                 + m_compte.NumCompte + ","
//                 + m_date.ToString("yyyy-MM-dd HH:mm:ss") + ","
//                 + m_montant;
//        }
//    }
//}

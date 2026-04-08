using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Transaction
    {
        private DateTime m_date;
        private int m_montant;
        private string m_numClient;
        private SorteTransactions m_sorteTransaction;

        public DateTime Date { get; set; }
        public int Montant { 
            get { return m_montant; } set
            {
                m_montant = value;
                if (value <= 0) 
                 throw new ArgumentOutOfRangeException();
                m_montant = value;

                
            }
        
        }
        public string NumClient
        {
            get { return m_numClient; }
            set
            {

                if (value == null) { throw new ArgumentNullException(); }

                if (value.Trim().Length != 6)
                {
                    throw new ArgumentException();
                }

                value = value.Trim();
               
                if (!int.TryParse(value, out int numero ))
                {
                    throw new ArgumentException();
                }
                m_numClient = value;
            }
        }
        
        
        

        public SorteTransactions SorteTransaction { get; set; }

        public string ToCsv()

        {
            
            string texte = m_date.ToString("yyyy-MM-dd HH:mm:ss");
            return $"{(int)SorteTransaction},{NumClient},{Date},{Montant}";

        }
        public  Transaction()
        {
            
        }
        public Transaction(SorteTransactions pSorte, string pNumClient, DateTime pDate, int pMontant)
        {
            

            SorteTransaction = pSorte;
            NumClient = pNumClient;
            Date = pDate;
            Montant = pMontant;

        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;
using Models;


namespace AppGuichet
{

    public partial class FrmListeTransactions : Form
    {
        //------------------------------------------------------------------------------

        public const string CHEMIN_FICHIER_TRANSACTIONS = "../../../Fichiers/Transactions.csv";
       
        //----------------------------------------------------------------
        public FrmListeTransactions()
        {
            InitializeComponent();
            //--------------------------------------
           


            
        }
        //------------------------------------------------------------------------------
     
        private void AfficherListeTransactions()
        { 
          StreamReader streamReader =new StreamReader(CHEMIN_FICHIER_TRANSACTIONS);

            while (streamReader.EndOfStream) { 
            
                string line = streamReader.ReadLine();
                string [] w = line.Split(",");
                
                int choix =int.Parse(w[0]);
               SorteTransactions sorteTransactions = (SorteTransactions)choix;
                string numclient = w[1];
                DateTime date = DateTime.Parse(w[2]);
                int montant = int.Parse(w[3]);

                
            }
            ServiceGuichet service =new ServiceGuichet();
            
        }
        //------------------------------------------------------------------------------
        private void cboOpération_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
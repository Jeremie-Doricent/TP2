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

      private ServiceGuichet serviceGuichet;       
        //----------------------------------------------------------------
        public FrmListeTransactions()
        {
            InitializeComponent();
            //--------------------------------------
           


            
        }
        //------------------------------------------------------------------------------
     
        private void AfficherListeTransactions()
        {
         lsvTransactions.Items.Clear();
            int compteur = 0;
            foreach (Transaction t in serviceGuichet)
            {
                bool afficherTransaction;
                if (cboOpération.SelectedItem.ToString() == "tout")
                {
                    afficherTransaction = true;
                }
                else if (cboOpération.SelectedItem.ToString() == "Retrait" && t.SorteTransaction == SorteTransactions.Retrait)
                {
                    afficherTransaction = true;
                }
                else if (cboOpération.SelectedItem.ToString() == "Dépôt" && t.SorteTransaction == SorteTransactions.Dépôt)
                {
                    afficherTransaction = true;
                }

                if (afficherTransaction)
                {
                    ListViewItem item = new ListViewItem(t.SorteTransaction.ToString());
                    item.SubItems.Add(item.ToString());
                    item.SubItems.Add(t.SorteTransaction.ToString());
                    item.SubItems.Add(t.Montant.ToString("00.00 $"));
                    item.SubItems.Add(t.Montant.ToString());
                    item.SubItems.Add(t.Montant.ToString());
                    lsvTransactions.Items.Add(item);
                    compteur++;
                }
            }
           lsvTransactions.Text = compteur.ToString();
        
        }
        //------------------------------------------------------------------------------
        private void cboOpération_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherListeTransactions();
        }
    }
}
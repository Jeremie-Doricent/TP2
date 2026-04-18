using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Models;


namespace AppGuichet
{
    /// =====================================================================================================================
    /// <summary>
    /// Représente l’utilisation d’un guichet automatique. Un client peut se connecter avec son numéro et son mot de passe.
    /// Il peut retirer de l’argent si son solde le permet. L’administrateur du guichet peut demander la liste des clients
    /// où la liste des transactions effectuées sur le guichet.
    /// </summary>
    /// ======================================================================================================================
    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "(Démo)";

        #region Constantes
        //--- CHAMPS: constantes ----------------------------------------------------------
        public const string CHEMIN_FICHIER_CLIENTS = "../../../Fichiers/Clients.csv";
               public const string CHEMIN_FICHIER_TRANSACTIONS = "../../../Fichiers/Transactions.csv";
        #endregion

        #region Champs et Propriétés
       


        #endregion

        #region Constructeur
        //---------------------------------------------------------------------------------
        public FrmPrincipal()
        {
            InitializeComponent();
            this.Text += APP_INFO;

            serviceGuichet = new ServiceGuichet(CHEMIN_FICHIER_CLIENTS,CHEMIN_FICHIER_TRANSACTIONS);
            
        }
        #endregion

       public ServiceGuichet serviceGuichet;

       public Client client1;

        #region Menu Administrateur
        //---------------------------------------------------------------------------------
        private void mnuAdminListeClients_Click(object sender, EventArgs e)
        {
          FrmListeClients clients = new FrmListeClients();
            clients.ShowDialog();
        }
        //---------------------------------------------------------------------------------
        private void mnuAdminListeTransactions_Click(object sender, EventArgs e)
        {
           
            FrmListeTransactions transactions = new FrmListeTransactions();
            transactions.ShowDialog();
           
        }


        #endregion

        private void FrmPrincipal_FormClosing(object sender, EventArgs e)
        {
            serviceGuichet.Sauvegarde();  
            
        }
        private void mnuFichierQuitter_Click(object sender, EventArgs e)
        {
           this.Close();
           
           
        }

       

        #region Bouton Connexion/Déconnexion 
        //---------------------------------------------------------------------------------
        public void btnConnexion_Click(object sender, EventArgs e)
        {
            if (client1 != null)
            {
                serviceGuichet.Deconnexion();
                client1 = null;
                btnConnexion.Text = "Se connecter";
           
                txtNom.Clear();
                txtSolde.Clear();
                txtSorteCompte.Clear();
                grpInfosClient.Enabled = false;
                mnuAdministrateur.Enabled = false;
                btnRetirer.Enabled = false;
                btnDeposer.Enabled = false;
                txtNumClient.Clear();
                
            }
            else
            {
                string numClient = txtNumClient.Text;
                string motpasse = txtMotDePasse.Text;
                
                bool choix = serviceGuichet.Connexion(numClient, motpasse);

                if (!choix )  // ← connexion réussie
                {
                    client1 = serviceGuichet.ClientCourant;
                    btnConnexion.Text = "Deconnexion";
                   grpInfosClient.Enabled = true;
                    
                }
                else  // ← connexion échouée
                {
                    MessageBox.Show("Numéro ou mot de passe invalide !");
                }
                StreamReader streamReader = new StreamReader(CHEMIN_FICHIER_TRANSACTIONS);

                while (streamReader.EndOfStream)
                {

                    string line = streamReader.ReadLine();
                    string[] w = line.Split(",");

                    int chwoix = int.Parse(w[0]);
                    SorteTransactions sorteTransactions = (SorteTransactions)chwoix;
                    string numclient = w[1];
                    DateTime date = DateTime.Parse(w[2]);
                    int montant = int.Parse(w[3]);


                }
            }
        }
        #endregion

        #region Bouton Retirer et Événement Combo Montant à retirer
        //---------------------------------------------------------------------------------
        //Retire le montant choisi
        public void btnDeposer_Click(object sender, EventArgs e)
        {
            int montant = int.Parse(cboMontant.Text);
            try
            {
                client1.Deposer(montant);
                serviceGuichet.CreerTransaction(SorteTransactions.Dépôt, client1.NumClient, DateTime.Now, montant);
            }
            catch (Exception) {

                MessageBox.Show("eurreur dêpot", "toujours pas", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    }

           
        }
        //---------------------------------------------------------------------------------
        //Choix du montant à retirer
        private void cboMontant_SelectedIndexChanged(object sender, EventArgs e)
        {

            cboMontant.Show();
        }

        #endregion

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            int montant = int.Parse(cboMontant.Text);
            try
            {
                client1.Retirer(montant);
                serviceGuichet.CreerTransaction(SorteTransactions.Retrait, client1.NumClient, DateTime.Now, montant);
            }
            catch (Exception)
            {

                MessageBox.Show("eurreur dêpot", "toujours pas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

        }

        

        private void mnuAdministrateur_Click(object sender, EventArgs e)
        {
            
                mnuAdminListeClients.Enabled = true;
                mnuAdminListeTransactions.Enabled = true;
            
            
        }
    }
}
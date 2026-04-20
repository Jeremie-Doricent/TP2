using Models;
using System.Collections.Generic;
using System.Windows.Forms;


namespace AppGuichet
{
    public partial class FrmListeClients : Form
    {
        //---------------------------------------------------------------------------------
        private ServiceGuichet serviceGuichet;


        public FrmListeClients()
        {
            InitializeComponent();
            
            AfficherListeClients();
        }
        //---------------------------------------------------------------------------------
        public void AfficherListeClients()
        {
           lsvClients.Items.Clear();
            foreach(Client client in serviceGuichet.Clients)
            {
                ListViewItem item = new ListViewItem(client.NumClient);
                item.SubItems.Add(client.Nom);
                item.SubItems.Add(client.Role.ToString());
                item.SubItems.Add(client.SorteCompte.ToString());
                item.SubItems.Add(client.Solde.ToString());
                lsvClients.Items.Add(item);
            }
        }
    }
}
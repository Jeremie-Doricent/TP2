using System;
using System.Collections.Generic;
using System.IO;

namespace AppGuichet
    {
        public class Client
        {
            private string m_numClient;
            public string NumClient
            {
                get { return m_numClient; }
            }

            private string m_nom;
            public string Nom
            {
                get { return m_nom; }
            }

            private string m_motDePasse;
            public string MotDePasse
            {
                get { return m_motDePasse; }
            }
            private Roles m_role;
            public Roles Role
            {
                get { return m_role; }
            }

            private List<Compte> m_comptes;

            public List<Compte> Comptes
            {
                get { return m_comptes; }
            }           
            public bool IsAdmin
            {
                get { return (m_role == Roles.Administrateur); }
            }

            public Client(string pNumClient, string pNom, string pMotDePasse, Roles pRole)
            {
                m_numClient = pNumClient;
                m_nom = pNom;
                m_motDePasse = pMotDePasse;
                m_role = pRole;
                m_comptes = new List<Compte>();
                
            }
            public Client(string pChaineLue)
            {
                
                string[] tabInfos = pChaineLue.Split(',');

                m_numClient = tabInfos[0];              
                m_nom = tabInfos[1];
                m_motDePasse = tabInfos[2];
                m_role = (Roles) int.Parse(tabInfos[3]);
                m_comptes = new List<Compte>();
                
            }

            public void AjouterCompte(Compte pCompte)
            {
                if (pCompte == null )
                    throw new ArgumentNullException();
                m_comptes.Add(pCompte);
            }
           
            public string ToCsv()
            {
                return m_numClient + ","                     
                       + m_nom + ","                     
                       + m_motDePasse + ","
                       + (int) Role;
            }
            public override string ToString()
        {
                return m_numClient + " : " + m_nom;
            }

    }
    

}

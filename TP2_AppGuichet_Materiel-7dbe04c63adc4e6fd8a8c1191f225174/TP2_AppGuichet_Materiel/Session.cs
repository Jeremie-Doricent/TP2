//using System;
//using AppGuichet.AppGuichet;

//namespace AppGuichet
//{
//    public class Session
//    {
//        private Client m_client;
//        public Client Client
//        {
//            get { return m_client; }
//        }

//        private DateTime m_dateDebut;
//        public DateTime DateDebut
//        {
//            get { return m_dateDebut; }
//        }

//        private DateTime? m_dateFin;
//        public DateTime? DateFin
//        {
//            get { return m_dateFin; }
//            set { m_dateFin = value; }
//        }

//        public Session(Client pClient)
//        {
//            m_client = pClient;
//            m_dateDebut = DateTime.Now;
//        }
//        public Session(Client pClient, DateTime pDateDebut, DateTime? pDateFin)
//        {
//            m_client = pClient;
//            m_dateDebut = pDateDebut;
//            m_dateFin = pDateFin;

//            pClient.AjouterSession(this);
//        }

//        public void Terminer()
//        {
//            m_dateFin = DateTime.Now;
//        }

//        public override string ToString()
//        {
//            return Client.NumClient + "," +
//                   DateDebut.ToString("yyyy-MM-dd HH:mm:ss") + "," +
//                   (DateFin.HasValue ? DateFin.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
//        }
//    }
//}
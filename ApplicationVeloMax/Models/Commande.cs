using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Commande
    {
        static private List<Commande> ensemble = new List<Commande>();

        private int id;
        private DateTime dateE;
        private DateTime dateS;
        private Adresse adresseLivraison;
        private Client clientCommande;

        public Commande(int idAdresse, int idClient)
        {
            Adresse a = Adresse.Ensemble.Find(e => e.Id == idAdresse);
            if (a != null) this.AdresseLivraison = a;
            Client c = Client.Ensemble.Find(e => e.Id == idClient);
            if (c != null) this.ClientCommande = c;
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
        }
        public Commande()
        {

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DateE
        {
            get { return dateE; }
            set { dateE = value; }
        }

        public DateTime DateS
        {
            get { return dateS; }
            set { dateS = value; }
        }

        public Adresse AdresseLivraison
        {
            get { return adresseLivraison; }
            set { adresseLivraison = value; }
        }

        public Client ClientCommande
        {
            get { return clientCommande; }
            set { clientCommande = value; }
        }

        static public List<Commande> Ensemble
        {
            get { return ensemble; }
        }
    }
}

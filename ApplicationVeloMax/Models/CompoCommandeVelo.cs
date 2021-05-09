using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class CompoCommandeVelo
    {
        static private List<CompoCommandeVelo> ensemble = new List<CompoCommandeVelo>();

        private Commande commandeVelo;
        private Modele veloCompoCommande;
        private int quantite;

        public CompoCommandeVelo(int idCommande, int idModele)
        {
            Commande c = Commande.Ensemble.Find(e => e.Id == idCommande);
            if (c != null) this.CommandeVelo = c;
            Modele v = Modele.Ensemble.Find(e => e.Id == idModele);
            if (v != null) this.VeloCompoCommande = v;
            if (ensemble.Find(e => e.CommandeVelo.Id == this.CommandeVelo.Id) == null) ensemble.Add(this);
        }

        public Commande CommandeVelo
        {
            get { return commandeVelo; }
            set { commandeVelo = value; }
        }

        public Modele VeloCompoCommande
        {
            get { return veloCompoCommande; }
            set { veloCompoCommande = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        static public List<CompoCommandeVelo> Ensemble
        {
            get { return ensemble; }
        }
    }
}

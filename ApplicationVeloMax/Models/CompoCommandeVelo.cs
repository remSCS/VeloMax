using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class CompoCommandeVelo
    {
        private Commande commandeVelo;
        private Modele veloCompoCommande;
        private int quantite;

        public CompoCommandeVelo()
        {

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
    }
}

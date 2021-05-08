using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Modele
    {
        private int id;
        private string nom;
        private decimal prixUnitaire;
        private DateTime dateE;
        private DateTime dateS;
        private Grandeur grandeurModele;
        private LigneProduit ligneProduitModele;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public decimal PrixUnitaire
        {
            get { return prixUnitaire; }
            set { prixUnitaire = value; }
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

        public Grandeur GrandeurModele
        {
            get { return grandeurModele; }
            set { grandeurModele = value; }
        }

        public LigneProduit LigneProduitModele
        {
            get { return ligneProduitModele; }
            set { ligneProduitModele = value; }
        }
    }
}

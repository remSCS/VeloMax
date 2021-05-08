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
        private int quantite;

        public Modele(int idGrandeur, int idLigneProduit)
        {
            Grandeur f = Grandeur.ensembleGrandeurs.Find(g => g.ID == idGrandeur);
            if (f != null) this.GrandeurModele = f;
        }

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

        public Grandeur GrandeurModele
        {
            get { return grandeurModele; }
            set { grandeurModele = value; }
        }

        public decimal PrixUnitaire
        {
            get { return prixUnitaire; }
            set { prixUnitaire = value; }
        }

        public LigneProduit LigneProduitModele
        {
            get { return ligneProduitModele; }
            set { ligneProduitModele = value; }
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

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public override string ToString()
        {
            return $"{this.id} ; {this.nom} ; {this.prixUnitaire} ; {this.quantite} ; {this.grandeurModele} ; {this.ligneProduitModele}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Modele
    {
        static private List<Modele> ensemble = new List<Modele>();

        private int id;
        private string nom;
        private decimal prixUnitaire;
        private DateTime dateE;
        private DateTime dateS;
        private Grandeur grandeurModele;
        private LigneProduit ligneProduitModele;
        private List<PieceDetachee> piecesComposition = new List<PieceDetachee>();
        private int quantite;

        public Modele() { }

        public Modele(int idGrandeur, int idLigneProduit)
        {
            Grandeur g = Grandeur.Ensemble.Find(e => e.Id == idGrandeur);
            if (g != null) this.GrandeurModele = g;
            LigneProduit l = LigneProduit.Ensemble.Find(e => e.Id == idLigneProduit);
            if (l != null) this.LigneProduitModele = l;
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
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

        public int Nbvendus
        {
            get
            {
                int compteur = 0;
                foreach(Commande co in Commande.Ensemble)
                {
                    foreach(Modele mo in co.ModelesCommande)
                    {
                        if (mo.Id == this.Id) compteur++;
                    }
                }
                return compteur;
            }
        }

        public List<PieceDetachee> PiecesComposition
        {
            get { return piecesComposition; }
            set { piecesComposition = value; }
        }

        public override string ToString()
        {
            return $"{this.id} ; {this.nom} ; {this.prixUnitaire} ; {this.quantite} ; {this.grandeurModele.Nom} ; {this.ligneProduitModele.Nom} ; {this.dateE}";
        }

        static public List<Modele> Ensemble
        {
            get { return ensemble; }
        }

        static public List<Modele> ModelesThatMatch(string nomModele)
        {
            
            return Ensemble.FindAll(md => md.Nom.ToLower().Contains(nomModele.ToLower()) || md.Id.ToString().Contains(nomModele));
            
        }
    }
}

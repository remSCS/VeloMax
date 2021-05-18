using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class PieceDetachee
    {
        static private List<PieceDetachee> ensemble = new List<PieceDetachee>();

        private int id;
        private string reference;
        private string nom;
        private string description;
        private DateTime dateE;
        private DateTime dateS;
        private int quantite;
        private decimal prixVente;

        public PieceDetachee()
        {
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal PrixVente
        {
            get { return prixVente; }
            set { prixVente = value; }
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
                foreach (Commande co in Commande.Ensemble)
                {
                    foreach (PieceDetachee pd in co.PiecesCommande)
                    {
                        if (pd.Id == this.Id) compteur++;
                    }
                }
                return compteur;
            }
        }

        static public List<PieceDetachee> Ensemble
        {
            get { return ensemble; }
        }

        static public void Update()
        {
            ensemble = new List<PieceDetachee>();
        }

        static public List<PieceDetachee> PiecesThatMatch(string nomPiece)
        {

            return Ensemble.FindAll(md => md.Reference.ToLower().Contains(nomPiece.ToLower()) || md.Description.ToLower().Contains(nomPiece.ToLower()) || md.Nom.ToLower().Contains(nomPiece.ToLower()));

        }
    }
}

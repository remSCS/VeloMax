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

        static public List<PieceDetachee> Ensemble
        {
            get { return ensemble; }
        }

        static public void Update()
        {
            ensemble = new List<PieceDetachee>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class LigneProduit
    {
        static private List<LigneProduit> ensemble = new List<LigneProduit>();

        private int id;
        private string nom;

        public LigneProduit()
        {
            if(ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
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

        public override string ToString()
        {
            return $"{this.id} ; {this.nom}";
        }

        static public List<LigneProduit> Ensemble
        {
            get { return ensemble; }
        }
    }
}

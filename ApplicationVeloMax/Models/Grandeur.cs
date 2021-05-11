using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Grandeur
    {
        static private List<Grandeur> ensemble = new List<Grandeur>();

        private int id;
        private string nom;

        public Grandeur()
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
            return $"{this.nom}";
        }

        static public List<Grandeur> Ensemble
        {
            get { return ensemble; }
        }
    }
}

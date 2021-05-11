using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Libelle
    {
        static private List<Libelle> ensemble = new List<Libelle>();
        
        private int id;
        private string nom;

        public Libelle()
        {
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

        public override string ToString()
        {
            return $"{this.Nom}";
        }

        static public List<Libelle> Ensemble
        {
            get { return ensemble; }
        }
    }
}

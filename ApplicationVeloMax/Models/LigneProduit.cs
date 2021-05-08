using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class LigneProduit
    {
        static public List<LigneProduit> ensembleLigneProduit = new List<LigneProduit>();
        private int id;
        private string nom;

        public LigneProduit()
        {
            if(ensembleLigneProduit.Find(p => p.Id == this.Id) == null) ensembleLigneProduit.Add(this);
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
    }
}

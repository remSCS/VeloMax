using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Grandeur
    {
        static public List<Grandeur> ensembleGrandeurs = new List<Grandeur>();

        private int id;
        private string nom;

        public Grandeur()
        {
            ensembleGrandeurs.Add(this);
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
            return $"{this.id}; {this.nom}";
        }
    }
}

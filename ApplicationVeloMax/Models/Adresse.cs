using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Adresse
    {
        private int id;
        private string ligne1;
        private string ligne2;
        private int codePostal;
        private string ville;
        private string province;
        private string pays;

        public Adresse()
        {

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Ligne1
        {
            get { return ligne1; }
            set { ligne1 = value; }
        }

        public string Ligne2
        {
            get { return ligne2; }
            set { ligne2 = value; }
        }

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        public int CodePostal
        {
            get { return codePostal; }
            set { codePostal = value; }
        }

        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        public string Pays
        {
            get { return pays; }
            set { pays = value; }
        }
    }
}

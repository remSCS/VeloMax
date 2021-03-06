using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Adresse
    {
        static private List<Adresse> ensemble = new List<Adresse>();

        private int id;
        private string ligne1;
        private string ligne2;
        private string codePostal;
        private string ville;
        private string province;
        private string pays;

        public Adresse(string ligne2 = "", string province = "")
        {
            this.Ligne2 = ligne2;
            this.Province = province;
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
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

        public string CodePostal
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

        public string FullAdresse
        {
            get
            {
                string str = $"{this.Ligne1}\n";
                if (this.ligne2 != "" && this.ligne2 != null) str += $"{this.Ligne2}\n";
                str += $"{this.CodePostal}, {this.ville}\n";
                if (this.province != "" && this.province != null) str += $"{this.province}, ";
                str += $"{this.pays}";
                return str;
            }
        }

        public override string ToString()
        {
            string str = $"{this.ligne1}";
            if (this.ligne2 != "" && this.ligne2 != null) str += $", {this.ligne2}";
            str += $", {this.CodePostal}, {this.ville}";
            if (this.province != "" && this.province != null) str += $", {this.province}";
            str += $", {this.pays}";
            return str;
        }

        static public List<Adresse> Ensemble
        {
            get { return ensemble; }
        }
    }
}

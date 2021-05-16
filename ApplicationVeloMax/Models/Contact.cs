using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Contact
    {
        static private List<Contact> ensemble = new List<Contact>();

        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string tel;

        public Contact()
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

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string FormatTel
        {
            get { return Convert.ToInt32(Tel).ToString("0# ## ## ## ##"); }
        }

        public override string ToString() => $"{this.Nom} {this.Prenom} - {this.Tel} - {this.Email}";

        public string FullName
        {
            get{ return this.prenom + " " + this.nom; }
        }

        static public List<Contact> Ensemble
        {
            get { return ensemble; }
        }
    }
}

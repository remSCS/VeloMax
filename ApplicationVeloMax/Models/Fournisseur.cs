using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Fournisseur
    {
        static private List<Fournisseur> ensemble = new List<Fournisseur>();

        private int siret;
        private string nom;
        private Contact contactFournisseur;
        private Adresse adresseFournisseur;
        private Libelle libelleFournisseur;

        public Fournisseur()
        {
            if (ensemble.Find(e => e.Siret == this.Siret) == null) ensemble.Add(this);
        }

        public int Siret
        {
            get { return siret; }
            set { siret = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public Contact ContactFournisseur
        {
            get { return contactFournisseur; }
            set { contactFournisseur = value; }
        }

        public Adresse AdresseFournisseur
        {
            get { return adresseFournisseur; }
            set { adresseFournisseur = value; }
        }

        public Libelle LibelleFournisseur
        {
            get { return libelleFournisseur; }
            set { libelleFournisseur = value; }
        }

        static public List<Fournisseur> Ensemble
        {
            get { return ensemble; }
        }
    }
}

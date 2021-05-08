using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Fournisseur
    {
        private int siret;
        private string nom;
        private Contact contactFournisseur;
        private Adresse adresseFournisseur;
        private Libelle libelleFournisseur;

        public Fournisseur()
        {

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
    }
}

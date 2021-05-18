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

        public Fournisseur(int idContact, int idAdresse, int idLibelle)
        {
            Contact c = Contact.Ensemble.Find(e => e.Id == idContact);
            if (c != null) this.ContactFournisseur = c;
            Adresse a = Adresse.Ensemble.Find(e => e.Id == idAdresse);
            if (a != null) this.AdresseFournisseur = a;
            Libelle l = Libelle.Ensemble.Find(e => e.Id == idLibelle);
            if (l != null) this.LibelleFournisseur = l;
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

        static public List<Fournisseur> FournisseursThatMatch(string nomClient)
        {

            return Ensemble.FindAll(md => md.ContactFournisseur.FullName.ToLower().Contains(nomClient.ToLower()) || md.Siret.ToString().Contains(nomClient) || md.Nom.ToLower().Contains(nomClient.ToLower()));

        }
    }
}

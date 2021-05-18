using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public abstract class Client
    {
        static private List<Client> ensemble = new List<Client>();

        private int id;
        private Adresse adresseClient;
        private Contact contactClient;
        private DateTime dateAdherance;

        public Client(int idAdresse, int idContact)
        {
            Adresse a = Adresse.Ensemble.Find(e => e.Id == idAdresse);
            if (a != null) this.AdresseClient = a;
            Contact c = Contact.Ensemble.Find(e => e.Id == idContact);
            if (c != null) this.ContactClient = c;

            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Adresse AdresseClient
        {
            get { return adresseClient; }
            set { adresseClient = value; }
        }

        public Contact ContactClient
        {
            get { return contactClient; }
            set { contactClient = value; }
        }

        public DateTime DateAdherance
        {
            get { return dateAdherance; }
            set { dateAdherance = value; }
        }

        public string Nom
        {
            get
            {
                string destinataire = "";
                ClientPart part = ClientPart.EnsembleParticuliers.Find(c => c.Id == this.Id);
                ClientPro pro = ClientPro.EnsemblePros.Find(c => c.Id == this.Id);
                if (part == null) destinataire = pro.NomEntreprise;
                else if (part != null) destinataire = part.ContactClient.FullName;
                return destinataire;
            }
        }

        public decimal MontantCumul
        {
            get
            {
                decimal prixCumul = 0;
                var co = Commande.Ensemble.FindAll(c => c.ClientCommande.Id == this.Id);
                foreach (Commande com in co)
                {
                    if (com.Statut != "Annulée") prixCumul += com.MontantCommandeAvecTVAAvecRemise;
                }
                return prixCumul;
            }
        }

        public override string ToString()
        {
            return $"{this.ContactClient}";
        }

        static public List<Client> Ensemble
        {
            get { return ensemble; }
        }

       
    }
}

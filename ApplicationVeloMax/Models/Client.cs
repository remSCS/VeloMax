using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Client
    {
        static private List<Client> ensemble = new List<Client>();

        private int id;
        private Adresse adresseClient;
        private Contact contactClient;
        private ClientPart clientPartClient;
        private ClientPro clientProClient;

        public Client(int idAdresse, int idContact, int idClientPart, int idClientPro)
        {
            Adresse a = Adresse.Ensemble.Find(e => e.Id == idAdresse);
            if (a != null) this.AdresseClient = a;
            Contact c = Contact.Ensemble.Find(e => e.Id == idContact);
            if (c != null) this.ContactClient = c;

            if(idClientPart == 0)
            {
                ClientPro cp = ClientPro.Ensemble.Find(e => e.Id == idClientPro);
                if (cp != null) this.clientProClient = cp;
            }
            else
            {
                ClientPart cp = ClientPart.Ensemble.Find(e => e.Id == idClientPart);
                if (cp != null) this.ClientPartClient = cp;
            }
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
        
        public ClientPart ClientPartClient
        {
            get { return clientPartClient; }
            set { clientPartClient = value; }
        }

        public ClientPro ClientProClient
        {
            get { return clientProClient; }
            set { clientProClient = value; }
        }

        static public List<Client> Ensemble
        {
            get { return ensemble; }
        }
    }
}

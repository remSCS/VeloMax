using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class ClientPart
    {
        static private List<ClientPart> ensemble = new List<ClientPart>();

        private int id;
        private Fidelio fidelioFournisseur;
        private DateTime dateDebutFidelo;

        public ClientPart()
        {
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Fidelio FidelioFournisseur
        {
            get { return fidelioFournisseur; }
            set { fidelioFournisseur = value; }
        }

        public DateTime DateDebutFidelio
        {
            get { return dateDebutFidelo; }
            set { dateDebutFidelo = value; }
        }

        static public List<ClientPart> Ensemble
        {
            get { return ensemble; }
        }
    }
}

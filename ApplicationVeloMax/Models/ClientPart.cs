using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class ClientPart : Client
    {
        static private List<ClientPart> ensembleParticuliers = new List<ClientPart>();

        private Fidelio fidelioClient;
        private DateTime dateDebutFidelo;

        public ClientPart(int idAdresse, int idContact, int idFidelio, DateTime debutFidelio) : base(idAdresse, idContact)
        {
            if (idFidelio == 0) this.FidelioClient = null;
            else
            {
                Fidelio f = Fidelio.Ensemble.Find(e => e.Id == idFidelio);
                if (f != null) this.FidelioClient = f;
            }
            if (ensembleParticuliers.Find(e => e.Id == this.Id) == null) ensembleParticuliers.Add(this);
        }

        public Fidelio FidelioClient
        {
            get { return fidelioClient; }
            set { fidelioClient = value; }
        }

        public DateTime DateDebutFidelio
        {
            get { return dateDebutFidelo; }
            set { dateDebutFidelo = value; }
        }

        static public List<ClientPart> EnsembleParticuliers
        {
            get { return ensembleParticuliers; }
        }
    }
}

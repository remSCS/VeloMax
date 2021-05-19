using Newtonsoft.Json;
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

        public ClientPart(int idAdresse, int idContact, int idFidelio) : base(idAdresse, idContact)
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

        public DateTime DateFinFidelio
        {
            get { return DateDebutFidelio.AddDays(FidelioClient.DureeJours); }
        }

        static public List<ClientPart> EnsembleParticuliers
        {
            get { return ensembleParticuliers; }
        }

        static public List<ClientPart> PartThatMatch(string nomClient)
        {
            return EnsembleParticuliers.FindAll(md => md.ContactClient.FullName.ToLower().Contains(nomClient.ToLower()) || md.Id.ToString().Contains(nomClient) || md.ContactClient.Tel.Contains(nomClient.ToLower()));
        }

        static public List<ClientPart> ProgrammeFidelioBientotExpired(int nbJoursRestant)
        {
            List<ClientPart> toReturn = new List<ClientPart>();
            foreach (var c in EnsembleParticuliers)
            {
                if (c.FidelioClient != null)
                {
                    int tempsRestant = (c.DateFinFidelio - DateTime.Today).Days;
                    if (tempsRestant <= nbJoursRestant) toReturn.Add(c);
                }
            }
            return toReturn;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class ClientPro : Client
    {
        static private List<ClientPro> ensemblePros = new List<ClientPro>();

        private string nomEntreprise;
        private decimal remise;

        public ClientPro(int idAdresse, int idContact) : base(idAdresse, idContact)
        {
            if (ensemblePros.Find(e => e.Id == this.Id) == null) ensemblePros.Add(this);
        }

        public string NomEntreprise
        {
            get { return nomEntreprise; }
            set { nomEntreprise = value; }
        }

        public decimal Remise
        {
            get { return remise; }
            set { remise = value; }
        }

        static public List<ClientPro> EnsemblePros
        {
            get { return ensemblePros; }
        }
    }
}

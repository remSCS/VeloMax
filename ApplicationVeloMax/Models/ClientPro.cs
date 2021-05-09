using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class ClientPro
    {
        static private List<ClientPro> ensemble = new List<ClientPro>();

        private int id;
        private string nomEntreprise;
        private decimal remise;

        public ClientPro()
        {
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        static public List<ClientPro> Ensemble
        {
            get { return ensemble; }
        }
    }
}

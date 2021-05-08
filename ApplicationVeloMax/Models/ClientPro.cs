using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class ClientPro
    {
        private int id;
        private string nomEntreprise;
        private decimal remise;

        public ClientPro()
        {

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
    }
}

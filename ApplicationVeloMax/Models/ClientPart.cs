using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class ClientPart
    {
        private int id;
        private Fidelio fidelioFournisseur;
        private DateTime dateDebutFidelo;

        public ClientPart()
        {

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
    }
}

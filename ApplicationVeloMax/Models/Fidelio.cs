using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Fidelio
    {
        static private List<Fidelio> ensemble = new List<Fidelio>();

        private int id;
        private string nom;
        private string description;
        private decimal cout;
        private decimal rabais;
        private int dureeJours;

        public Fidelio()
        {
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Cout
        {
            get { return cout; }
            set { cout = value; }
        }

        public decimal Rabais
        {
            get { return rabais; }
            set { rabais = value; }
        }

        public int DureeJours
        {
            get { return dureeJours; }
            set { dureeJours = value; }
        }

        public List<ClientPart> ClientsFid
        {
            get
            {
                var cl = ClientPart.EnsembleParticuliers.FindAll(cli => cli.FidelioClient !=null && cli.FidelioClient.Id==Id);
                return cl;
            }
        }

        static public List<Fidelio> Ensemble
        {
            get { return ensemble; }
        }
    }
}

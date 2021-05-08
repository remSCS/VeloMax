using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Fidelio
    {
        private int id;
        private string nom;
        private string description;
        private decimal cout;
        private decimal rabais;
        private int dureeJours;

        public Fidelio()
        {

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
    }
}

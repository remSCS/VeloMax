using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Commande
    {
        static private List<Commande> ensemble = new List<Commande>();
        static private List<Commande> ensemblePrep = new List<Commande>();
        static private List<Commande> ensembleAnnul = new List<Commande>();
        static private List<Commande> ensembleDone = new List<Commande>();

        private int id;
        private DateTime dateE;
        private DateTime dateS;
        private string statut;
        private Adresse adresseLivraison;
        private Client clientCommande;
        private List<PieceDetachee> piecesCommandes = new List<PieceDetachee>();
        private List<Modele> modelesCommande = new List<Modele>();

        public Commande() { }

        public Commande(int idAdresse, int idClient, int idStatut)
        {
            Adresse a = Adresse.Ensemble.Find(e => e.Id == idAdresse);
            if (a != null) this.AdresseLivraison = a;
            Client c = Client.Ensemble.Find(e => e.Id == idClient);
            if (c != null) this.ClientCommande = c;
            if (ensemble.Find(e => e.Id == this.Id) == null) ensemble.Add(this);
            switch (idStatut)
            {
                case 1: EnsemblePrep.Add(this); break;
                case 2: EnsembleDone.Add(this); break;
                case 3: EnsembleAnnul.Add(this); break;
            }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DateE
        {
            get { return dateE; }
            set { dateE = value; }
        }

        public DateTime DateS
        {
            get { return dateS; }
            set { dateS = value; }
        }

        public string Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        public decimal MontantCommandeSansRien
        {
            get
            {
                decimal output = 0;
                foreach (var p in PiecesCommande) output += p.PrixVente;
                foreach (var m in ModelesCommande) output += m.PrixUnitaire;
                return output;
            }
        }

        public decimal MontantCommandeAvecTVASansRemise(decimal TVAEnPourcentage)
        {
            return this.MontantCommandeSansRien + (this.MontantCommandeSansRien * TVAEnPourcentage / 100);
        }

        public decimal MontantCommandeAvecTVAAvecRemise(decimal TVAEnPourcentage)
        {
            decimal prix = this.MontantCommandeAvecTVASansRemise(TVAEnPourcentage);
            ClientPart part = ClientPart.EnsembleParticuliers.Find(c => c.Id == this.ClientCommande.Id);
            ClientPro pro = ClientPro.EnsemblePros.Find(c => c.Id == this.ClientCommande.Id);
            if (part == null) prix = prix + (prix * pro.Remise / 100);
            else if (part != null && part.FidelioClient != null) prix = prix + (prix * part.FidelioClient.Rabais / 100);
            return prix;
        }

        public Adresse AdresseLivraison
        {
            get { return adresseLivraison; }
            set { adresseLivraison = value; }
        }

        public Client ClientCommande
        {
            get { return clientCommande; }
            set { clientCommande = value; }
        }

        public List<PieceDetachee> PiecesCommande
        {
            get { return piecesCommandes; }
            set { piecesCommandes = value; }
        }

        public List<Modele> ModelesCommande
        {
            get { return modelesCommande; }
            set { modelesCommande = value; }
        }

        static public List<Commande> Ensemble
        {
            get { return ensemble; }
        }

        static public List<Commande> EnsemblePrep
        {
            get { return ensemblePrep; }
        }

        static public List<Commande> EnsembleAnnul
        {
            get { return ensembleAnnul; }
        }
               
        static public List<Commande> EnsembleDone
        {
            get { return ensembleDone; }
        }

        static public void ClearEnsembles()
        {
            Ensemble.Clear();
            EnsemblePrep.Clear();
            EnsembleAnnul.Clear();
            EnsembleDone.Clear();
        }
    }
}

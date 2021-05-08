using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class CompoCommandePieces
    {
        private Commande commandePiece;
        private PieceDetachee pieceCompoCommande;
        private int quantite;

        public CompoCommandePieces()
        {

        }

        public Commande CommandePiece
        {
            get { return commandePiece; }
            set { commandePiece = value; }
        }

        public PieceDetachee PieceCompoCommande
        {
            get { return pieceCompoCommande; }
            set { pieceCompoCommande = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
    }
}

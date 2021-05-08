using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Composition
    {
        private Modele modeleComposition;
        private PieceDetachee pieceDetacheeComposition;

        public Composition()
        {

        }

        public Modele ModeleComposition
        {
            get { return modeleComposition; }
            set { modeleComposition = value; }
        }

        public PieceDetachee PieceDetacheeComposition
        {
            get { return pieceDetacheeComposition; }
            set { pieceDetacheeComposition = value; }
        }
    }
}

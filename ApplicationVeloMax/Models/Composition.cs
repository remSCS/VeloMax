using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVeloMax.Models
{
    public class Composition
    {
        static private List<Composition> ensemble = new List<Composition>();

        private Modele modeleComposition;
        private PieceDetachee pieceDetacheeComposition;

        public Composition()
        {
            if (ensemble.Find(e =>
             e.ModeleComposition.Id == this.ModeleComposition.Id &&
             e.PieceDetacheeComposition.Id == this.PieceDetacheeComposition.Id) == null) ensemble.Add(this);
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

        static public List<Composition> Ensemble
        {
            get { return ensemble; }
        }
    }
}

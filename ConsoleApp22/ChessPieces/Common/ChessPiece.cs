using Lucene.Net.Support;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public abstract class ChessPiece : IStepMovement
    {

        protected String name = "";
        protected HashMap<KeyPadButton, List<KeyPadButton>> moves = null;
        protected Int32 fullNumbers = 0;
        protected Int32[] movesFrom = null;
        protected KeyPadButton[][] thePad = null;

        public abstract List<KeyPadButton> allowedMoves(KeyPadButton from);
        public abstract Boolean canMove(KeyPadButton from, KeyPadButton to);
        public abstract Int32 countAllowedMoves(KeyPadButton from);
        public abstract Int32 findNumbers(KeyPadButton start, int digits);
    }
}

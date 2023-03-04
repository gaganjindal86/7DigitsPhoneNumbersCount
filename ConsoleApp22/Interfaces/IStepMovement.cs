using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    interface IStepMovement
    {
        public Int32 findNumbers(KeyPadButton start, Int32 digits);
        public abstract Boolean canMove(KeyPadButton from, KeyPadButton to);
        public List<KeyPadButton> allowedMoves(KeyPadButton from);
        public Int32 countAllowedMoves(KeyPadButton from);
    }
}

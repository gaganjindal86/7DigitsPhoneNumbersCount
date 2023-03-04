using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class ChessPiecesFactory
    {
        public ChessPiece getPiece(String piece, KeyPadButton[][] thePad)
        {
            if (thePad != null && thePad.Length > 0 && thePad[0].Length > 0 && String.Compare(piece, "Knight", true) ==0)
            {
                return new Knight("Knight", thePad);
            }
            return null;
        }
    }
}

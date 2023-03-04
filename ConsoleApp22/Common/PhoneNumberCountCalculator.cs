using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public sealed class PhoneNumberCountCalculator   // Specific keypad 
    {
        private ChessPiece thePiece = null;
        private ChessPiecesFactory factory = null;

        public ChessPiece ThePiece()
        {
            return this.thePiece;
        }

        public PhoneNumberCountCalculator(KeyPadButton[][] thePad, String piece)
        {
            if (thePad != null && thePad.Length > -1 && thePad[0].Length > -1)
            {
                this.factory = new ChessPiecesFactory();
                this.thePiece = this.factory.getPiece(piece, thePad);
            }
        }

        public Int32 findPossibleDigits(KeyPadButton start, Int32 digits = 7)   //Default set t0 7 digit numbers. this variable can be abstracted further if needed.
        {   
            return thePiece.findNumbers(start, digits);
        }

        public Boolean isValidMove(KeyPadButton from, KeyPadButton to)
        {
            return this.thePiece.canMove(from, to);
        }

    }
}

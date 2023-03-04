using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Support;

namespace ConsoleApp22
{
    public sealed class Knight : ChessPiece, IStepMovement
    {
        private Int32 fullNumbers;
        public Knight(String name, KeyPadButton[][] thePad)
        {
            this.name = String.IsNullOrWhiteSpace(name) ? String.Empty : name;
            this.thePad = thePad;
            this.moves = new HashMap<KeyPadButton, List<KeyPadButton>>();
        }

        public override Int32 findNumbers(KeyPadButton start, Int32 digits)
        {
            if (start == null || start.getNumber() == "*" || start.getNumber() == "#")                      // End is reached
            {
                return 0;
            }

            if (start.getNumberAsNumber() == 5)     //Special case
            {
                return 0;
            }

            if (digits == 1)                        // Edge case
            {
                return 1;
            }

            //Initialise starting point
            this.movesFrom = new int[thePad.Length * thePad[0].Length];
            for (int i = 0; i < this.movesFrom.Length; i++)
                this.movesFrom[i] = -1;

            fullNumbers = 0;
            findNumbers(start, digits, 1);
            return fullNumbers;
        }

        private void findNumbers(KeyPadButton start, Int32 digits, Int32 currentDigits)
        {
            // bottom out is reached
            if (currentDigits == digits)
            {
                currentDigits = 1;
                fullNumbers++;
                return;
            }
            if (!this.moves.ContainsKey(start))
                allowedMoves(start);

            List<KeyPadButton> options;
            if (this.moves.TryGetValue(start, out options))
            {
                currentDigits++; //get further digits

                foreach (KeyPadButton keyPadButton in options)
                {
                    findNumbers(keyPadButton, digits, currentDigits);
                }
            }
        }

        public override Boolean canMove(KeyPadButton from, KeyPadButton to)
        {
            
            if (!this.moves.ContainsKey(from))
            {
                //No? Process.
                allowedMoves(from);
            }

            if (this.moves.TryGetValue(from, out List<KeyPadButton> options))
            {
                foreach (KeyPadButton option in options)
                {
                    if (option.getNumber() == (to.getNumber()))
                        return true;
                }
            }
            return false;
        }
        public override List<KeyPadButton> allowedMoves(KeyPadButton from)
        {
            //First encounter
            if (this.moves == null)
                this.moves = new HashMap<KeyPadButton, List<KeyPadButton>>();


            this.moves.TryGetValue(from, out List<KeyPadButton> value);
            if (value != null)
                return value;

            else
            {
                List<KeyPadButton> found = new List<KeyPadButton>();
                int row = from.getY();//rows
                int col = from.getX();//columns

                //Cases:
                //1. One horizontal move each way followed by two vertical moves each way
                if (col - 1 >= 0 && row - 2 >= 0)//valid
                {
                    if (thePad[row - 2][col - 1].getNumber() != "*" && thePad[row - 2][col - 1].getNumber() != "#")
                    {
                        found.Add(thePad[row - 2][col - 1]);
                        this.movesFrom[from.getNumberAsNumber()] = this.movesFrom[from.getNumberAsNumber()] + 1;
                    }

                }
                if (col - 1 >= 0 && row + 2 < thePad.Length)//valid
                {
                    if (thePad[row + 2][col - 1].getNumber() != "*" &&  thePad[row + 2][col - 1].getNumber() != "#")
                    {
                        found.Add(thePad[row + 2][col - 1]);
                        this.movesFrom[from.getNumberAsNumber()] = this.movesFrom[from.getNumberAsNumber()] + 1;
                    }
                }
                if (col + 1 < thePad[0].Length && row + 2 < thePad.Length)//valid
                {
                    if (thePad[row + 2][col + 1].getNumber() != "*" && thePad[row + 2][col + 1].getNumber() != "#")
                    {
                        found.Add(thePad[row + 2][col + 1]);
                        this.movesFrom[from.getNumberAsNumber()] = this.movesFrom[from.getNumberAsNumber()] + 1;
                    }
                }
                if (col + 1 < thePad[0].Length && row - 2 >= 0)//valid 
                {
                    if (thePad[row - 2][col + 1].getNumber() != "*" && thePad[row - 2][col + 1].getNumber() != "#")
                        found.Add(thePad[row - 2][col + 1]);
                }
                //Case 2. One vertical move each way follow by two horizontal moves each way

                if (col - 2 >= 0 && row - 1 >= 0)
                {
                    if (thePad[row - 1][col - 2].getNumber() != "*" && thePad[row - 1][col - 2].getNumber() != "#")
                        found.Add(thePad[row - 1][col - 2]);
                }
                if (col - 2 >= 0 && row + 1 < thePad.Length)
                {
                    if (thePad[row + 1][col - 2].getNumber() != "*" && thePad[row + 1][col - 2].getNumber() != "#")
                        found.Add(thePad[row + 1][col - 2]);
                }

                if (col + 2 < thePad[0].Length && row - 1 >= 0)
                {
                    if (thePad[row - 1][col + 2].getNumber() != "*" && thePad[row - 1][col + 2].getNumber() != "#")
                        found.Add(thePad[row - 1][col + 2]);
                }
                if (col + 2 < thePad[0].Length && row + 1 < thePad.Length)
                {
                    if (thePad[row + 1][col + 2].getNumber() != "*" && thePad[row + 1][col + 2].getNumber() != "#")
                        found.Add(thePad[row + 1][col + 2]);
                }

                if (found.Count > 0)
                {
                    this.moves.Add(from, found);
                    this.movesFrom[from.getNumberAsNumber()] = found.Count;
                }
                else
                {
                    this.moves.Add(from, null); //for example the Knight cannot move from 5 to anywhere
                    this.movesFrom[from.getNumberAsNumber()] = 0;
                }
            }
            this.moves.TryGetValue(from, out List<KeyPadButton> result);
            return result;
        }


        public override Int32 countAllowedMoves(KeyPadButton from)
        {
            int start = from.getNumberAsNumber();

            if (movesFrom[start] != -1)
                return movesFrom[start];
            else
            {
                movesFrom[start] = allowedMoves(from).Count;
            }
            return movesFrom[start];
        }

    }
}

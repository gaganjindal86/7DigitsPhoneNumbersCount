using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
namespace ConsoleApp22
{
    class Program
    {
        static void Main(String[] args)
        {
            /*Initialise Keypad design with invalid points in 2D*/
            List<Point> invalidPoints = new List<Point>()
            {
                new Point(){ X = 0, Y = 0},     //can not start with keypad digit 1
                new Point(){ X = 3, Y = 0},     //can not start with keypad digit *
                new Point(){ X = 3, Y = 1},      //can not start with keypad digit 0
                new Point(){ X = 3, Y = 2}      //can not start with keypad digit #
            };


            Keypad phoneKeypad = new Keypad(
                Constants.MobilePhoneKeyPadId,
                new Point()
                {
                    X = Constants.MobilePhoneKeyPadRows - 1,
                    Y = Constants.MobilePhoneKeyPadColumns - 1
                }, invalidPoints);

            //Keypad ChessbaordKeypad = new Keypad(2, new System.Drawing.Point() { X = 7, Y = 7 }, invalidPoints);   // Excample of Additional keypad for future needs
            /********/


            try
            {
                KeyPadButton[][] thePad = new KeyPadButton[phoneKeypad.getCoordinatesSize().X][];
                thePad[0] = new KeyPadButton[phoneKeypad.getCoordinatesSize().Y];
                thePad[1] = new KeyPadButton[phoneKeypad.getCoordinatesSize().Y];
                thePad[2] = new KeyPadButton[phoneKeypad.getCoordinatesSize().Y];
                thePad[3] = new KeyPadButton[phoneKeypad.getCoordinatesSize().Y];

                thePad = Utilities.MobilePhoneKeypadDesign.GetFormattedKeyPad(thePad);

                PhoneNumberCountCalculator phoneChess = new PhoneNumberCountCalculator(thePad, "Knight");
                long possible7digitPhoneNumbers = 0;

                //Scroll the keypad to get possible phone numbers starting with each digit
                for (Int32 x = 0; x <= phoneKeypad.getX(); x++)
                    for (Int32 y = 0; y <= phoneKeypad.getY(); y++)
                        if (phoneKeypad.GetInvalidPoints().Where(placeholder => placeholder.X == x && placeholder.Y == y).Count() == 0)
                            possible7digitPhoneNumbers += phoneChess.findPossibleDigits(thePad[x][y], Constants.phoneNumberLength);

                /* few people like to have curly braces in above code, I am happy to mingle with rest of the team on this.
                 * Just not using here so that code is more readable to you.
                 */

                Console.WriteLine($"Possible {Constants.phoneNumberLength} digit numbers count for standard Mobile keypad (dtabase id #1) With Chess piece Knight:{possible7digitPhoneNumbers}");
                

            }
            catch (Exception ex)
            {
                //Error handling here
                /*
                 * 
                 * Errors can be captured at deep insdie level but may be beyond the scrope of this test
                 
                 
                 */
            }
        }
    }

}
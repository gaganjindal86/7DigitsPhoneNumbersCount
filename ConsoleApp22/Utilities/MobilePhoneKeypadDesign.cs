using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22.Utilities
{
    public class MobilePhoneKeypadDesign
    {
        public static KeyPadButton[][] GetFormattedKeyPad(KeyPadButton[][] InputKeyPad)
        {
            /*Fall back cases needs input from business, what to do when invalid input*/

            if (InputKeyPad[0].Length == Constants.MobilePhoneKeyPadRows - 1 || InputKeyPad[1].Length == Constants.MobilePhoneKeyPadColumns - 1)
            {
                InputKeyPad[0][0] = new KeyPadButton("1", new Point(0, 0));
                InputKeyPad[0][1] = new KeyPadButton("2", new Point(1, 0));
                InputKeyPad[0][2] = new KeyPadButton("3", new Point(2, 0));
                InputKeyPad[1][0] = new KeyPadButton("4", new Point(0, 1));
                InputKeyPad[1][1] = new KeyPadButton("5", new Point(1, 1));
                InputKeyPad[1][2] = new KeyPadButton("6", new Point(2, 1));
                InputKeyPad[2][0] = new KeyPadButton("7", new Point(0, 2));
                InputKeyPad[2][1] = new KeyPadButton("8", new Point(1, 2));
                InputKeyPad[2][2] = new KeyPadButton("9", new Point(2, 2));
                InputKeyPad[3][0] = new KeyPadButton("*", new Point(0, 3));
                InputKeyPad[3][1] = new KeyPadButton("0", new Point(1, 3));
                InputKeyPad[3][2] = new KeyPadButton("#", new Point(2, 3));
            }
            return InputKeyPad;
        }
    }
}

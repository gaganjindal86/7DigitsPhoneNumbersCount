using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class KeyPadButton : IKeyPadButton
    {
        private String number = "";
        private Point coordinates;

        public KeyPadButton(String number, Point coordinates)
        {
            this.number = String.IsNullOrWhiteSpace(number) ? String.Empty : number;

            if (coordinates.X > -1 && coordinates.Y > -1)
            {
                this.coordinates = coordinates;
            }
        }

        public String getNumber()
        {
            return this.number;
        }
        public Int32 getNumberAsNumber()
        {
            Int32 value;
            return int.TryParse(this.number, out value) ? value : -1;
        }

        public Point getCoordinatesSize()
        {
            return this.coordinates;
        }
        public int getX()
        {
            return this.coordinates.X;
        }
        public int getY()
        {
            return this.coordinates.Y;
        }

    }

}

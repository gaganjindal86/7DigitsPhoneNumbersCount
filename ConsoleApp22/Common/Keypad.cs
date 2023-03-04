using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class Keypad : IKeypad      // Allows flexible keypad desgin, futureProof to allow new keypad designs in 2D plane
    {
        private Int32 keypadId = -1;
        private Point coordinateBoundry = new Point() { X = 0, Y = 0 };
        private List<Point> invalidPoints = new List<Point>() { };

        public Keypad(Int32 keypadId, Point coordinateBoundry, List<Point> invalidPoints)
        {
            this.keypadId = (keypadId > 0) ? keypadId : this.keypadId;

            if (coordinateBoundry.X >= 0 && coordinateBoundry.Y >= 0)
            {
                this.coordinateBoundry = coordinateBoundry;
            }

            foreach(Point invalidPoint in invalidPoints)
            {
                if (invalidPoint.X >= 0 && invalidPoint.Y >= 0)
                {
                    this.invalidPoints.Add(invalidPoint);
                }
            }
        }

        public Point getCoordinatesSize() // GetBoundery sizes not indexes
        {
            Point boundrySizes = coordinateBoundry;
            boundrySizes.X += 1;
            boundrySizes.Y += 1;

            return boundrySizes;
        }

        public List<Point> GetInvalidPoints()
        {
            return this.invalidPoints;
        }
        public int getNumberAsNumber()
        {
            return this.keypadId;
        }

        public int getX()
        {
            return coordinateBoundry.X;
        }

        public int getY()
        {
            return coordinateBoundry.Y;
        }
    }
}

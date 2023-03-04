using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public interface IKeypad : IKeyPadButton            //flexible Keypad, With invalid points identified
    {
        List<Point> GetInvalidPoints();

    }
}

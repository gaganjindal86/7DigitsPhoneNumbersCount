using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public static class Constants
    {
        public const Int32 phoneNumberLength = 7;

        //Phone Keypad
        public const Int32 MobilePhoneKeyPadId = 1;
        public const Int32 MobilePhoneKeyPadRows = 4;           // This can further be abstracted depending upon the scope of the project. Ideally needs to read from Database
        public const Int32 MobilePhoneKeyPadColumns = 3;

        //SomeOther Keypad
        public const Int32 TestKeyPadId = 2;
        public const Int32 TestKeyPadRows = 7;
        public const Int32 TestKeyPadColumns = 7;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v8
{
    public class PhoneNumber
    {
        public int Code, Number;
    }

    public class ExtendedPhoneNumber : PhoneNumber
    {
        public string Office;
    }
}

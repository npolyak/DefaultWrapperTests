using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.DefaultWrappersWithAttrsTest
{
    // IPersonDataVM interface
    public interface IPersonDataVM
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string FullName { get; }
    }

    // IPersonDataVM implementation
    public class PersonDataVM : IPersonDataVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // FullName is a calculated property
        public string FullName =>
            FirstName + " " + LastName;
    }


    // wrapper interface. 
    public interface IPersonDataWrapper
    {
        PersonDataVM ThePersonWrapper { get; }
    }
}

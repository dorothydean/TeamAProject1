using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationFinal
{
    public class Customer
    {
        #region Fields

        private int _CustomerID;
        private string _FirstName;
        private string _LastName;

        #endregion

        #region Constructors

        public Customer() { }

        #endregion

        //getters and setters
        public string Title { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName+" "+LastName;
        }
    }
}

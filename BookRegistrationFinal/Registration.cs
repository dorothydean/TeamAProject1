using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationFinal
{
    public class Registration
    {
        #region Constructors

        public Registration() { }

        public Registration(string _CustomerID, string _ISBN, DateTime _RegDate)
        {
            this.CustomerID = _CustomerID;
            this.ISBN = _ISBN;
            this.RegDate = _RegDate;
             
        }

        public Registration(string cid, string ISBN)
        {
            CustomerID = cid;
            this.ISBN = ISBN;
            
        }

        #endregion

        #region Properties
        //getters and setters
        public string CustomerID { get; set; }

        public string ISBN { get; set; }

        public DateTime RegDate { get; set; }

        #endregion
    }
}

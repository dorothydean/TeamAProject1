using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationFinal
{
    public class Book
    {
        #region Fields

        private string _ISBN;
        private decimal _price;
        private string _title;

        #endregion

        #region Constructors

        public Book() { }

        public Book(string _ISBN, decimal _price, string _title)
        {
            this._ISBN = _ISBN;
            this._price = _price;
            this._title = _title;
        }

        #endregion

        //properties
        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseForEcoCompany
{
    public class Record
    {
        public string Category;
        public string Title;
        public string Author;
        public string Price;

        public Record(string category, string title, string author, string price)
        {
            Category = category;
            Title = title;
            Author = author;
            Price = price;
        }
        /*public string[] RecordToStringArray()
        {
            string[] s={""};
            return s;
        }*/
    }
}

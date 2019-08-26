using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace QuoteBot
{
    public class QuoteBotLibrary
    {
        public const string LIBRARY = @"C:\likesdogs\Quotes.txt";

        IList<QuoteRecord> dictionary;

        public QuoteBotLibrary()
        {
            TextReader tr1 = new StreamReader(LIBRARY, true);

            var Data = tr1.ReadToEnd().Split('\n')
            .Where(l => l.Length > 0)  //nonempty strings
            .Skip(1)               // skip header 
            .Select(s => s.Trim())   // delete whitespace
            .Select(l => l.Split(';')) // get arrays of values
            .Select(l => new QuoteRecord(l[0], l[1], l[2]));

            dictionary = Data.ToList<QuoteRecord>();
        }

        public string GetRandomQuote()
        {
            int rowCount = dictionary.Count;
            QuoteRecord returnQuote = new QuoteRecord();
            int next;
            if(rowCount>0)
            {
                Random ran = new Random();
                next = ran.Next(0, rowCount - 1);
                returnQuote = dictionary[next];
            }
            string returnString = string.Format("\"{0}\"  - {1}", returnQuote.Quote, returnQuote.Author);
            return returnString;
        }

    }

    public struct QuoteRecord
    {
        public string Quote;
        public string Author;
        public string Category;
       

        public QuoteRecord(string p1, string p2, string p3) : this()
        {
            Quote = p1;
            Author = p2;
            Category = p3;
        }
    }
}

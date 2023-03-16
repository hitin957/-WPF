using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Бюджет
{
    internal class Data
    {
        public string Text { get; set; }//геттеры и сеттеры
        public string Money { get; set; }
        public bool Proch { get; set; }
        public string Type { get; set; }

        public DateTime Date { get; set; }
        //public int c { get; set; }
        public Data(string text,string money, string type, bool proch, DateTime date)//Конструктор
        {
            Text = text;
            Money = money;
            Type = type;
            Proch = proch;
            Date = date;
        }

    }
   
}

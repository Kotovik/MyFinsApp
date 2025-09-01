using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinsApp
{
    /// <summary>
    /// Абстрактный для транзакций
    /// </summary>
    public abstract class Transaction
    {
        public DateTime Data { get; protected set; }
        public int Value { get; protected set; }
        public string PlaceOperation { get; protected set; }

        protected Transaction(DateTime data, int value, string placeoperation)
        {
            Data = data;
            Value = value;
            PlaceOperation = placeoperation;
        }
        
      
    }
    public class RealTransaction : Transaction
    {
        public int MSS { get; set; }

        public RealTransaction(DateTime data, int value, string place_operation, int mss)
                : base(data, value, place_operation)
        {
            MSS = mss;
        }
        public DateTime GetData()
            { return Data; }
        public int GetValue()
            { return Value; }
        public string GetPlaceOperation()
            { return PlaceOperation; }
        public int GetMSS() 
        { return MSS; }
    }
}

   
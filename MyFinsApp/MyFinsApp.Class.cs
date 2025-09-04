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
        public string Data { get; protected set; }
        public double Value { get; protected set; }
        public string PlaceOperation { get; protected set; }

        protected Transaction(string data, double value, string placeoperation)
        {
            Data = data;
            Value = value;
            PlaceOperation = placeoperation;
        }
    }
    public class RealTransaction : Transaction
    {
        public string Category { get; set; }

        public string Comment { get; set; }
        

        public RealTransaction(string Data, double Value, string PlaceOperation, string Category, string Comment)
                : base(Data, Value, PlaceOperation)
        {
            this.Category = Category;
            this.Comment = Comment;
        }



        public string GetData() //дата операции
            { return Data; }
        public double GetValue() //Сумма операции 
            { return Value; }
        public string GetPlaceOperation() //Получатель
            { return PlaceOperation; }
        public string GetCategory() //Категория
            { return Category; }
        public string GetComment()
        { return Comment; }
    }
}

   
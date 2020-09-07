using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercises
{
    class InvoiceItem
    {
        public string Id { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public double UnitPrice { get; private set; }

        public InvoiceItem(string id, string description, int quantity, double unitPrice)
        {
            Id = id;
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public string GetId()
        {
            return Id;
        }

        public string GetDescription()
        {
            return Description;
        }

        public int GetQuantity()
        {
            return Quantity;
        }
        public void SetQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

        public double GetunitPrice()
        {
            return UnitPrice;
        }
        public void SetUnitPrice(double newUnitPrice)
        {
            UnitPrice = newUnitPrice;
        }

        public double GetTotalPrice()
        {
            return UnitPrice * Quantity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyLand.Domain.Abstract;


namespace JoyLand.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Sweet sweet, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Sweet.Id == sweet.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Sweet = sweet,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Sweet sweet)
        {
            lineCollection.RemoveAll(l => l.Sweet.Id == sweet.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Sweet.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Sweet Sweet { get; set; }
        public ShoppingDetails ShoppingDetails { get; set; }

        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using JoyLand.Domain.Entities;
using JoyLand.Domain.Abstract;

namespace JoyLand.Domain.Concrete
{
    public class EFShoppingDetailsRepository : ISDRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<ShoppingDetails> ShoppingDetails
        {
            get { return context.ShoppingDetails; }
        }

        public IEnumerable<Sweet> Sweets => throw new NotImplementedException();

        public void SaveShoppingDetails(Cart cart, ShoppingDetails shoppingDetails)
        {
            if (shoppingDetails.Id == 0)
                context.ShoppingDetails.Add(shoppingDetails);
            else
            {
                ShoppingDetails dbEntry = context.ShoppingDetails.Find(shoppingDetails.Id);
                if (dbEntry != null)
                {
                    dbEntry.NameUser = shoppingDetails.NameUser;
                    dbEntry.Quantity = shoppingDetails.Quantity;
                    dbEntry.Name = shoppingDetails.Name;
                    dbEntry.Price = shoppingDetails.Price;
                    dbEntry.Line1 = shoppingDetails.Line1;
                    dbEntry.NumCart = shoppingDetails.NumCart;
                    dbEntry.City = shoppingDetails.City;
                    dbEntry.Country = shoppingDetails.Country;
                }
            }
            context.SaveChanges();
        }

        public ShoppingDetails DeleteShoppingDetails(int Id)
        {
            ShoppingDetails dbEntry = context.ShoppingDetails.Find(Id);
            if (dbEntry != null)
            {
                context.ShoppingDetails.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        Sweet ISDRepository.DeleteShoppingDetails(int Id)
        {
            throw new NotImplementedException();
        }

    }
}



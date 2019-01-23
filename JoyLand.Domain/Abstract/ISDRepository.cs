using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyLand.Domain.Entities;

namespace JoyLand.Domain.Abstract
{
    public interface ISDRepository
    {
        IEnumerable<ShoppingDetails> ShoppingDetails { get; }
        void SaveShoppingDetails(Cart cart, ShoppingDetails shoppingDetails);
        Sweet DeleteShoppingDetails(int Id);

    }
}

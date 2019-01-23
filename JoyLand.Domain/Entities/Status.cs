using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoyLand.Domain.Entities

{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ShoppingDetails> ShoppingDetails { get; set; }
        public Status()
        {
            ShoppingDetails = new List<ShoppingDetails>();
        }
    }
}

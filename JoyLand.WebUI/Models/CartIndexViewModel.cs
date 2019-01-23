using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoyLand.Domain.Entities;

namespace JoyLand.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
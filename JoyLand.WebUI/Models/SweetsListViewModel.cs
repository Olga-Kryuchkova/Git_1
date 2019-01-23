using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoyLand.Domain.Entities;


namespace JoyLand.WebUI.Models
{
    public class SweetsListViewModel
    {
        public IEnumerable<Sweet> Sweets { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }


    }
}
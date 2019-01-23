using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoyLand.WebUI.Models
{
    public class PagingInfo
    {
        //Кол-во товаров
        public int TotalItens { get; set; }

        //Кол-во товаров на одной странице
        public int ItemsPerPage { get; set; }

        //Номер текущей страницы
        public int CurrentPage { get; set; }

        //Общее кол-во страниц
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItens / ItemsPerPage); }
        }
    }
}
using JoyLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoyLand.WebUI.Models
{
    public class CartCreateViewModel
    {
        public Cart Cart { get; set; }
        public ShoppingDetails ShoppingDetails { get; set; }
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string NameUser { get; set; }


        public int Quantity { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        [Display(Name = "Первый адрес")]
        public string Line1 { get; set; }

        [Display(Name = "Номер карты")]
        public string NumCart { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string ReturnUrl { get; set; }
        public Sweet Sweet { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JoyLand.Domain.Entities
{
    public class Sweet
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название игры")]
        public string Name { get; set; }

        [Display(Name = "Бренд")]
        [Required(ErrorMessage = "Пожалуйста, введите бренд товара")]
        public string Brand { get; set; }

        [Display(Name = "Страна производитель")]
        [Required(ErrorMessage = "Пожалуйста, введите страну производителя товара")]
        public string CountryOfOrigin { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите вкус товара")]
        public string Description { get; set; }

        [Display(Name = "Вес поштучно (г)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, укажите вес товара")]
        public string WeightByPiece { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию для игры")]
        public string Category { get; set; }

        [Display(Name = "Цена (грн)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JoyLand.WebUI.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage="Заполните имя!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Заполните фамилию!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email неверный")]
     //   [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}[0-9]{1,3})(\]?)$", ErrorMessage = "Введите правильную почту!")]   //станно работает
        public string Email { get; set; }

        [Required(ErrorMessage = "Ввдете имя пользователя!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароль неверный!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
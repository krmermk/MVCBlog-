using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Lütfen Email Adresi Alanını doldurunuz")]
        [EmailAddress(ErrorMessage ="Lütfen düzgün bir email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Lütfen Parola kısmını doldurunuz")]
        public string Password { get; set; }
    }
}
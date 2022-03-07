using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Username tidak boleh kosong")]
        [MinLength(5, ErrorMessage = "Username minimal 5 karakter")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password tidak boleh kosong")]
        [MinLength(5, ErrorMessage = "Password minimal 5 karakter")]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Roles Roles { get; set; }
    }
}

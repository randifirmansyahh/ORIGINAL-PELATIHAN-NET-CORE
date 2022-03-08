using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Models
{
    public class Blog
    {
        [Key]
        public string Id { get; set; }
        
        [Required(ErrorMessage ="Ini harus diisi loh")]
        [DisplayName("Judul")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Isinya")]
        public string Content { get; set; }

        [DisplayName("Tanggal Pembuatan")]
        public DateTime CreateDate { get; set; }

        public string Image { get; set; }
        public bool Status { get; set; }
        public User User { get; set; }
    }

    public class BlogDashBoard
    {
        public List<Blog> blog { get; set; }
        public List<User> user { get; set; }

        public BlogDashBoard()
        {
            blog = new List<Blog>();
            user = new List<User>();
        }
    }
}

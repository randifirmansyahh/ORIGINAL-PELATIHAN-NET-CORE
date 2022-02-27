using go_blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Services
{
    public interface IService
    {
        // Blog
        List<Blog> TampilSemuaData();
        Blog TampilBlogById(string id);
        bool BuatBlog(Blog datanya, string username);
        bool HapusBlog(string id);
        bool UbahBlog(Blog data);

        // User
        List<User> TampilSemuaUser();
    }
}

using go_blogs.Models;
using Microsoft.AspNetCore.Http;
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
        bool BuatBlog(Blog datanya, string username, IFormFile fotonya);
        bool HapusBlog(string id);
        bool UbahBlog(Blog data);

        // User
        List<User> TampilSemuaUser();
        User TampilUserByUsername(string usernamenya);
        User TampilUserByUsernameDanPassword(string usernamenya, string passwordnya);
        bool BuatUser(User datanya);

        // Roles
        List<Roles> TampilSemuaRoles();
        Roles TampilRolesById(string idnya);
    }
}

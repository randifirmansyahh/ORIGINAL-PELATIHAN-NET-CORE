using go_blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Repositories
{
    public interface IRepository
    {
        // CRUD
        Task<bool> BuatBlogAsync(Blog datanya);
        Task<List<Blog>> TampilSemuaBlogAsync();
        Task<Blog> TampilBlogByIDAsync(string id);
        Task<bool> UpdateBlogAsync(Blog datanya);
        Task<bool> HapusBlogAsync(Blog datanya);
        
        // User
        Task<List<User>> TampilSemuaUserAsync();
        Task<User> TampilUserByUsernameAsync(string usernamenya);
        Task<User> TampilUserByUsernameDanPasswordAsync(string usernamenya, string passwordnya);
        Task<bool> BuatUserAsync(User datanya);

        // Roles
        Task<List<Roles>> TampilSemuaRolesAsync();
        Task<Roles> TampilRolesByIdAsync(string idnya);
    }
}

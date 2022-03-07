using go_blogs.Data;
using go_blogs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Blog>> TampilSemuaBlogAsync()
        {
            // x.user.roles artinya join tb_user, join tb_roles
            var data = await _db.Tb_Blog.Include(x => x.User.Roles).ToListAsync(); // select *
            return data;
        }

        public async Task<Blog> TampilBlogByIDAsync(string id)
        {
            return await _db.Tb_Blog.Include(x => x.User.Roles).FirstOrDefaultAsync(x => x.Id == id); // select * from tb_blog where BlogId==id
        }

        public async Task<bool> BuatBlogAsync(Blog datanya)
        {
            _db.Tb_Blog.Add(datanya); // insert into tb_blog ...
            await _db.SaveChangesAsync(); // eksekusi
            return true;
        }

        public async Task<bool> HapusBlogAsync(Blog datanya)
        {
            _db.Tb_Blog.Remove(datanya); // delete from tb_blog
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBlogAsync(Blog datanya)
        {
            _db.Tb_Blog.Update(datanya); // update from tb_blog set ...
            await _db.SaveChangesAsync(); // eksekusi
            return true;
        }

        //
        // USER
        //
        public async Task<List<User>> TampilSemuaUserAsync()
        {
            // x.roles artinya join tb_roles
            return await _db.Tb_User.Include(x => x.Roles).ToListAsync();
        }

        public async Task<User> TampilUserByUsernameAsync(string usernamenya)
        {
            return await _db.Tb_User.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Username == usernamenya);
        }

        public async Task<User> TampilUserByUsernameDanPasswordAsync(string usernamenya, string passwordnya)
        {
            return await _db.Tb_User.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Username == usernamenya && x.Password == passwordnya);
        }

        public async Task<bool> BuatUserAsync(User datanya)
        {
            _db.Tb_User.Add(datanya);
            await _db.SaveChangesAsync();
            return true;
        }

        //
        // ROLES
        //
        public async Task<List<Roles>> TampilSemuaRolesAsync()
        {
            return await _db.Tb_Roles.ToListAsync();
        }

        public async Task<Roles> TampilRolesByIdAsync(string idnya)
        {
            return await _db.Tb_Roles.FirstOrDefaultAsync(x => x.Id == idnya);
        }
    }
}

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

        public async Task<bool> BuatBlogAsync(Blog datanya)
        {
            _db.Tb_Blog.Add(datanya); // insert into tb_blog ...
            await _db.SaveChangesAsync(); // eksekusi
            return true;
        }

        public async Task<User> CariUserByUsernameAsync(string username)
        {
            return await _db.Tb_User.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> HapusBlogAsync(Blog datanya)
        {
            _db.Tb_Blog.Remove(datanya); // delete from tb_blog
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Blog> TampilBlogByIDAsync(string id)
        {
            return await _db.Tb_Blog.FirstOrDefaultAsync(x => x.Id == id); // select * from tb_blog where BlogId==id
        }

        public async Task<List<Blog>> TampilSemuaBlogAsync()
        {
            var data = await _db.Tb_Blog.ToListAsync(); // select *
            return data;
        }

        public async Task<bool> UpdateBlogAsync(Blog datanya)
        {
            _db.Tb_Blog.Update(datanya); // update from tb_blog set ...
            await _db.SaveChangesAsync(); // eksekusi
            return true;
        }

        // USER
        public async Task<List<User>> TampilSemuaUserAsync()
        {
            return await _db.Tb_User.ToListAsync();
        }
    }
}

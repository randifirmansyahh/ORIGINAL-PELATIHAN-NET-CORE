using go_blogs.Helper;
using go_blogs.Models;
using go_blogs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Services
{
    public class Service : IService
    {
        private readonly IRepository _repo;

        public Service(IRepository r)
        {
            _repo = r;
        }

        public bool BuatBlog(Blog datanya, string username)
        {
            datanya.Id = BuatPrimary.buatPrimary();
            datanya.CreateDate = DateTime.Now;
            datanya.User = _repo.CariUserByUsernameAsync(username).Result;

            return _repo.BuatBlogAsync(datanya).Result;
        }

        public bool HapusBlog(string id)
        {
            var cari = _repo.TampilBlogByIDAsync(id).Result;
            _repo.HapusBlogAsync(cari);
            return true;
        }

        public Blog TampilBlogById(string id)
        {
            return _repo.TampilBlogByIDAsync(id).Result;
        }

        public List<Blog> TampilSemuaData()
        {
            return _repo.TampilSemuaBlogAsync().Result;
        }

        public bool UbahBlog(Blog data)
        {
            _repo.UpdateBlogAsync(data);
            return true;
        }

        public List<User> TampilSemuaUser()
        {
            return _repo.TampilSemuaUserAsync().Result;
        }
    }
}

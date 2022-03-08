﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Services
{
    public class FileService
    {
        IWebHostEnvironment _alat;
        public FileService(IWebHostEnvironment e)
        {
            _alat = e;
        }

        public async Task<string> SimpanFile(IFormFile filenya)
        {
            string namaFolder = "FOTO";

            // cek filenya
            if (filenya == null)
            {
                // return string kosong
                return string.Empty;
            }

            // set di wwwroot/namaFolder
            var alamatLengkap = Path.Combine(_alat.WebRootPath, namaFolder);

            // cek foldernya ada atau tidak
            if (!Directory.Exists(alamatLengkap))
            {
                // jika tidak maka dibuat foldernya
                Directory.CreateDirectory(alamatLengkap);
            }

            // set nama file
            var namaFilenya = filenya.FileName;
            // set alamat file
            var alamatFilenya = Path.Combine(alamatLengkap, namaFilenya);

            // proses copy file ke folder
            using (var fotonya = new FileStream(alamatFilenya, FileMode.Create))
            {
                await filenya.CopyToAsync(fotonya);
            }

            // full alamat
            string fullnya = alamatFilenya;

            // return alamat file
            return Path.Combine("/" + namaFolder + "/", namaFilenya);
        }
    }
}

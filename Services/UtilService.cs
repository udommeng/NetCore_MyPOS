using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MyPOS.Services
{
    public class UtilService
    {
        const string Folder = "files";

        private readonly IHttpContextAccessor HttpContextAccessor;
        private readonly IHostingEnvironment IHostingEnvironment;

        public UtilService(IHttpContextAccessor HttpContextAccessor, IHostingEnvironment IHostingEnvironment)
        {
            this.IHostingEnvironment = IHostingEnvironment;
            this.HttpContextAccessor = HttpContextAccessor;
        }

        public string GetPathfile()
        {
            return $"{GetHost(HttpContextAccessor.HttpContext)}/{Folder}/";
        }

        private string GetHost(Microsoft.AspNetCore.Http.HttpContext Context)
        {
            return $"{Context.Request.Scheme}://{Context.Request.Host}";
        }

        public async Task<List<string>> UploadFilesAjax()
        {
            var files = HttpContextAccessor.HttpContext.Request.Form.Files;

            List<string> urlImage = new List<string>();

            if (files.Count > 0)
            {
                //long sumSizeFiles = files.Sum(f => f.Length);

                string filePath = $"{IHostingEnvironment.WebRootPath}/{Folder}/";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                foreach (var formFile in files)
                {
                    string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(formFile.FileName); // unique name
                    string fullPath = filePath + fileName;

                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }

                    urlImage.Add(fileName);
                }
            }

            return urlImage;
        }
    }
}
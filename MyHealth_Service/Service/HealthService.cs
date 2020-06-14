using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using MyHealth_Data.Model;
using MyHealth_Data.Repository;
using MyHealth_Service.IService;


namespace MyHealth_Service.Service
{
    public class HealthService : IHealthService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository _repo;
        private readonly IHostingEnvironment _environment;
        private const string imageFolder = "UserImages";
        public HealthService(IUnitOfWork unit, IRepository repo, IHostingEnvironment environment)
        {
            _uow = unit;
            _repo = repo;
            _environment = environment;
        }

        public IEnumerable<Image> GetImageDetails()
        {
            foreach (var x in _repo.Get())
            {
                x.ImagePath = Path.Combine(_environment.ContentRootPath, imageFolder, $"{x.ImagePath}");
            }
             return _repo.Get();
        }

        public void AddImage(AddImageModel input) 
        {
            var file = input.ImagePath;
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //Assigning Unique Filename 
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
            //Getting file Extension
            var FileExtension = Path.GetExtension(fileName);
            // concating  FileName + FileExtension
           var newFileName = myUniqueFileName + FileExtension;
            // Combines two strings into a path.
            fileName = Path.Combine(_environment.ContentRootPath, imageFolder) + $@"\{newFileName}";
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            _repo.Add(input, newFileName);
        }

        public Image GetImageById(int imageId)
        {
            var imageDetails = _repo.GetById(imageId);
            if (imageDetails != null)
            {
                var path = Path.Combine(_environment.ContentRootPath, imageFolder, $"{imageDetails.ImagePath}");
                imageDetails.ImagePath = path;
                return imageDetails;
            }
            else
                return null;
        }
    }
}

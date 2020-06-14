using MyHealth_Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyHealth_Data.Repository
{
   public class Repository : IRepository
    {
        private readonly IUnitOfWork _unitOfWork;
    public Repository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(AddImageModel input, string fileName)
    {
            Image imageDetails = new Image();
            if (input != null)

            imageDetails.ImageId = input.ImageId;
            imageDetails.Title = input.Title;
            imageDetails.Description = input.Description;
            imageDetails.ImagePath = fileName;

            _unitOfWork.Context.Set<Image>().Add(imageDetails);
            _unitOfWork.Commit();
    }

   public Image GetById(int imageId)
   {
             var imagedetails = new Image();
             imagedetails = _unitOfWork.Context.Image.Find(imageId);
            if (imagedetails != null)
                return imagedetails;
            else
                return null;
   }

   public IEnumerable<Image> Get()
   {
        return _unitOfWork.Context.Set<Image>().AsEnumerable<Image>();
   }
   
}
}

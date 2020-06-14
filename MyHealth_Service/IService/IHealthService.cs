using MyHealth_Data.Model;
using System.Collections.Generic;


namespace MyHealth_Service.IService
{
   public interface IHealthService
    {
       IEnumerable<Image> GetImageDetails();
       void AddImage(AddImageModel input);
       Image GetImageById(int imageId);
    }
}

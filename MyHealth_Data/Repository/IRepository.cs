using MyHealth_Data.Model;
using System.Collections.Generic;


namespace MyHealth_Data.Repository
{
   public interface IRepository
    {
        IEnumerable<Image> Get();
        void Add(AddImageModel input, string fileName);
        Image GetById(int imageId);
    }
}

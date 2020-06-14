using Microsoft.AspNetCore.Http;



namespace MyHealth_Data.Model
{
   public class AddImageModel
    {
                
        public IFormFile ImagePath { get; set; }
        public int ImageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

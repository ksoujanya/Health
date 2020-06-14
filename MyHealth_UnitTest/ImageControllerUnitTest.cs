using Microsoft.AspNetCore.Mvc;
using Moq;
using MyHealth.Controllers;
using MyHealth_Data.Model;
using MyHealth_Service.IService;
using System.Collections.Generic;
using Xunit;

namespace MyHealth_UnitTest
{
   public class ImageControllerUnitTest
    {
        private Mock<IHealthService> _mockImageImpl = new Mock<IHealthService>();
        private ImageController _Controller;
        string imagePath= "C:\\Users\\souji\\source\\repos\\MyHealth\\MyHealth\\UserImages\\39cefa36-53f8-497d-8b25-cccf1f30edf2.jpg";

        public ImageControllerUnitTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _Controller = new ImageController(_mockImageImpl.Object);
        }


        [Fact]
        public void Controller_GetImageDetails_Valid_Test()
        {
            Image imageResult = new Image();

            imageResult.ImageId = 2;
            imageResult.Title = "hello";
            imageResult.Description = "fhg ghjhkj gjhhjjk fgjhjh";
            imageResult.ImagePath = imagePath;

            var fake = new List<Image>();
            fake.Add(imageResult);

            _mockImageImpl.Setup(x => x.GetImageDetails()).Returns(fake);
            IActionResult result = _Controller.GetImageDetails();
            Assert.IsType<JsonResult>(result);
            Assert.NotEmpty(((JsonResult)result).Value.ToString());
        }

        [Fact]
        public void Controller_AddImage_InValidInput_Test()
        {
            IActionResult result = _Controller.AddImage(null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Controller_GetImage_By_Id_ValidInput_Test()
        {
            Image imageResult = new Image();

            imageResult.ImageId = 4;
            imageResult.Title = "welcome";
            imageResult.Description = "dgffhggjh rtyiukj ghjnk dfvhjh";
            imageResult.ImagePath = imagePath;

            var fake = new Image();
          
            _mockImageImpl.Setup(x => x.GetImageById(2)).Returns(fake);
            IActionResult result = _Controller.GetImageById(2);
            Assert.IsType<JsonResult>(result);
            Assert.NotEmpty(((JsonResult)result).Value.ToString());
        }


        [Fact]
        public void Controller_GetImage_By_Id_InValidInput_Test()
        {
            Image imageResult = new Image();
            
            imageResult.ImageId = 3;
            imageResult.Title = "Test";
            imageResult.Description = "ghjjh gjhkjjlk fjhgjkhkj vnb";
            imageResult.ImagePath = imagePath;

            var fake = new Image();

            _mockImageImpl.Setup(x => x.GetImageById(-1)).Returns(fake);
            IActionResult result = _Controller.GetImageById(-1);
            Assert.IsType<BadRequestResult>(result);
        }

    }
}



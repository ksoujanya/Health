using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyHealth_Data.Model;
using MyHealth_Service.IService;


namespace MyHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        #region Private fields
        private readonly IHealthService _healthservice = null;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ImageController));
        #endregion

        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageController" /> class.
        /// </summary>
        /// <param name="healthservice"></param>
        public ImageController(IHealthService healthservice)
        {
            _healthservice = healthservice;

        }
        #endregion


        /// <summary>
        /// This Method will return all images from the database
        /// </summary>

        // GET: api/Image
        [HttpGet]
        public IActionResult GetImageDetails()
        {
            try
            {
                var imageList = _healthservice.GetImageDetails();
                return new JsonResult(imageList);
            }

            catch (Exception ex)
            {
                log.Info(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        /// <summary>
        /// This Method will return images from the database based on the Imageid
        /// </summary>

        // GET: api/Image/2
        [HttpGet("{imageId}")]
        public IActionResult GetImageById([FromRoute] int imageId)
        {

            if (imageId <= 0 || imageId > int.MaxValue)
            {
                return BadRequest();
            }
            try
            {
                var imageList = _healthservice.GetImageById(imageId);
                if (imageList != null)
                    return new JsonResult(imageList);
                else
                    return new JsonResult("No records found");
            }

            catch (Exception ex)
            {
                log.Info(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        /// <summary>
        /// This Method will create the images in the database
        /// </summary>

        // Post: api/Image
        [HttpPost]
        public IActionResult AddImage([FromForm] AddImageModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (input == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _healthservice.AddImage(input);
                return new JsonResult("Image inserted successfully");
            }
            catch (Exception ex)
            {
                log.Info(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

    }
}
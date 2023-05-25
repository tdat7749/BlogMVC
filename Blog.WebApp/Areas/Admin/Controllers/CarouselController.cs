using Blog.Application.System.CarouselService;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.Carousel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarouselController : Controller
    {
        private readonly ICarouselService _carouselService;
        public CarouselController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllCarousel([FromBody]PagingRequest request)
        {
            var result = await _carouselService.GetAllCarousel(request);
            return new JsonResult(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarousel([FromForm] CreateCarouselModel model)
        {
            var result = await _carouselService.CreateCarousel(model);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var carousel = await _carouselService.GetCarousel(id);
            if(carousel == null)
            {
                return NotFound();
            }
            return View(carousel);
        }

        [HttpPut]
        public async Task<IActionResult> EditCarousel([FromForm] UpdateCarouselModel model)
        {
            var result = await _carouselService.UpdateCarousel(model);
            return new JsonResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarousel([FromBody] int id)
        {
            var result = await _carouselService.DeleteCarouse(id);
            return new JsonResult(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCarouselStatus([FromBody] UpdateCarouselStatusModel model)
        {
            var result = await _carouselService.UpdateCarouselStatus(model);
            return new JsonResult(result);
        }
    }
}

using Blog.ViewModel.Common;
using Blog.ViewModel.System.Carousel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.CarouselService
{
    public interface ICarouselService
    {
        Task<PagingResponse<List<CarouselVm>>> GetAllCarousel(PagingRequest request);

        Task<JsonResponse> CreateCarousel(CreateCarouselModel model);
        Task<JsonResponse> UpdateCarousel(UpdateCarouselModel model);
        Task<JsonResponse> UpdateCarouselStatus(UpdateCarouselStatusModel model);
        Task<JsonResponse> DeleteCarouse(int id);



        Task<List<CarouselVm>> GetPublicCarousel();
    }
}

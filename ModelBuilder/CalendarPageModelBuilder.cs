using BreakfastCalendar.Business.Repository.Interface;
using BreakfastCalendar.Models.Pages;
using BreakfastCalendar.Models.ViewModels.Pages;

namespace BreakfastCalendar.Business.ModelBuilder
{
    public class CalendarPageModelBuilder : ICalendarPageModelBuilder
    {
        private readonly IProductRepository _productRepository;

        public CalendarPageModelBuilder(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public CalendarPageModel Create(CalendarPage currentPage)
        {
           
            var model = new CalendarPageModel();
            model.CurrentPage = currentPage;
            model.Products = _productRepository.GetProducts();
                       
            return model;
        }
    }
}

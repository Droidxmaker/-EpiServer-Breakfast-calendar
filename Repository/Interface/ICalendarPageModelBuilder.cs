using BreakfastCalendar.Models.Pages;
using BreakfastCalendar.Models.ViewModels.Pages;

namespace BreakfastCalendar.Business.Repository.Interface
{
    public interface ICalendarPageModelBuilder 
    {
        CalendarPageModel Create(CalendarPage currentPage);
    }
}

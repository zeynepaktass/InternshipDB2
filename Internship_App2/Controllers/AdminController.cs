using Internship_App2.AppDbContext;
using Internship_App2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Internship_App2.Controllers
{
	
	public class AdminController : Controller
	{
		public ActionResult Calendar()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Calendar(CalendarDto calendarDto)
		{
			if (ModelState.IsValid)
			{
				using (InternshipDb2Context db = new InternshipDb2Context())
				{
					var calendar = new AdminCalendar
					{
						StartDate = calendarDto.StartDate,
						EndDate = calendarDto.EndDate,
						Description = calendarDto.Description
					};
					db.AdminCalendars.Add(calendar);
					db.SaveChanges();
				}
				return RedirectToAction("Calendar");
			}
			return View(calendarDto);
		}


		public IActionResult CalendarList()
		{
			using (var db=new InternshipDb2Context())
			{
				var list=db.AdminCalendars.ToList();

				return View(list);
			}
		
		}

	}
}

using Cafe.Data;
using Cafe.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;

namespace Cafe.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _db;
		private readonly IToastNotification _toast;
		private readonly IWebHostEnvironment _he;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IToastNotification toast, IWebHostEnvironment he)
		{
			_logger = logger;
			_db = db;
			_toast = toast;
			_he = he;
		}

		public IActionResult Index()
		{
			var menu = _db.Menus.Where(i => i.Ozel).ToList();
			return View(menu);
		}
		public IActionResult CategoryDetails(int? id)
		{
			var menu = _db.Menus.Where(i => i.CategoryId == id).ToList();
			ViewBag.KategoriId = id;
			return View(menu);
		}
		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult Blog()
		{
			return View();
		}
		public IActionResult About()
		{
			var about = _db.Abouts.ToList();
			return View(about);
		}
		public IActionResult Galeri()
		{
			var galeri = _db.Galeris.ToList();
			return View(galeri);
		}
		public IActionResult Rezervasyon()
		{
			return View();
		}

		// POST: Admin/Rezervasyon/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Rezervasyon([Bind("Id,Name,Email,TelefonNo,Sayi,Saat,Tarih")] Rezervasyon rezervasyon)
		{
			if (ModelState.IsValid)
			{
				_db.Add(rezervasyon);
				await _db.SaveChangesAsync();
				_toast.AddSuccessToastMessage("Teşekkür Ederiz Rezervasyon İşleminiz başarıyla gerçekleşti...");
				return RedirectToAction(nameof(Index));
			}
			return View(rezervasyon);
		}
		public IActionResult Menu()
		{
			var menu = _db.Menus.ToList();
			return View(menu);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
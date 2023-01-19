using Freelancer_Deploy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace Freelancer_Deploy.Controllers {
	public class HomeController : Controller {
		
		private readonly ILogger<HomeController> _logger;
		public HomeController (ILogger<HomeController> logger) {
			_logger = logger;
		}
		[HttpPost]
		public dynamic Index (UsuarioModel model) {

			string _uuid = Guid.NewGuid().ToString();

			using (var context = new FreelancedbContext()) {

				var usuario = new UsuarioModel() {
					Id = _uuid,
					Name = model.Name,
					Currency = model.Currency,
					Title = model.Title,
					DocType = model.DocType,
					DocNumber = model.DocNumber,
					TotalAmmount = model.TotalAmmount,
					Address = model.Address,
					Logo = model.Logo,
				};
				context.Usuarios.Add(usuario);
				context.SaveChanges();
			}
			return View();
		}
		[HttpGet]
		public dynamic Create (UsuarioModel model) {

			if (model.Currency == "sol") {
				ViewData["currency"] = "S/.";
			} else if (model.Currency == "dolar") {
				ViewData["currency"] = "$";
			} else if (model.Currency == "euro") {
				ViewData["currency"] = "€";
			}

			ViewData["ammount"] = model.TotalAmmount;
			ViewData["title"] = model.Title; ;
			ViewData["description"] = model.Description;
			ViewData["address"] = model.Address;
			ViewData["name"] = model.Name;
			ViewData["docType"] = model.DocType;
			ViewData["docNumber"] = model.DocNumber;
			ViewData["logo"] = model.Logo;

			return new ViewAsPdf("Index", ViewData) { PageSize = Size.A4, PageOrientation = Orientation.Landscape };
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error () {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
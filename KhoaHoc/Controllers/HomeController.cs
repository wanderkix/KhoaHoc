using KhoaHoc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Bussiness1;
namespace KhoaHoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = ConnectDB.Instance.GetlistKhoaHoc();
            return View(data);
        }

        public IActionResult ViewMonHoc(int KhoaHocID = 0)
        {
            var res = new Model.Class1.KhoaHoc();
            if (KhoaHocID > 0)
            {
                var data = ConnectDB.Instance.GetlistKhoaHoc();
                if (data != null && data.Any())
                {
                    res = data.Find(x => x.ID == KhoaHocID);
                    if (res != null)
                    {
                        var lstkh = ConnectDB.Instance.GetlistMonHoc();
                        if (lstkh != null && lstkh.Any())
                        {
                            res.lstMonHoc = lstkh.FindAll(x => x.KhoaHocID == KhoaHocID);
                        }
                    }
                }
            }

            return PartialView(res);
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
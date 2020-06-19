using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityCore3._1.Models;
using Business.Services;
using Business.Services.UrunIslemleri;
using BusinessDto;
using System.Xml.Linq;
using System;

namespace EntityCore3._1.Controllers
{
    public class HomeController : Controller

    {
        private readonly IMenuService _menuservice;
        private readonly IUrunIslemleriService _urunIslemleriService;


        public HomeController(IMenuService menuService, IUrunIslemleriService urunIslemleriService)
        {
            _menuservice = menuService;
            _urunIslemleriService = urunIslemleriService;


        }
        public IActionResult Index(/*UrunDto model*/)
        {

            //var res = _menuservice.DeleteMenu(13);

            //var result = _urunIslemleriService.GetAllUrunToplamSiparis();
            //var siparisResult = _urunIslemleriService.SiparisVer(8);
            //var urunEkleResponse = _urunIslemleriService.UrunEkle(model);
            //var a = _urunIslemleriService.GetUrunSiparisIdGetir(7);
            //var result = _urunIslemleriService.SiparisDetayGetir(7);

            /// manuel ürün ekleme
            //var urunEkleResponse = _urunIslemleriService.UrunEkle(new   UrunDto
            //{
            //   Fiyat=4,
            //    InsertedDate = DateTime.Now,
            //    Name = "Kalem",
            //    StokAdet = 14,
            //    UrunTarihi = DateTime.Now
            //});

            return View(/*siparisResult*/);
        }
        public IActionResult Menu_Listele()
        {
            var a = _menuservice.GetMenus();
            return View(a);
        }
        public IActionResult DeleteMenu()
        {

            return View();
        }
        public IActionResult MenuSil(int id)
        {
            _menuservice.DeleteMenu(id);
             
            return RedirectToAction("Menu_Listele");
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

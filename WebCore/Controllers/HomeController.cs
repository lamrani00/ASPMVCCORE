using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ASPMVCCOREContext Context;
        private readonly IUnitOfWork uw;
        private readonly ILogger<HomeController> _logger;
        //   private readonly ProduitView produitView;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, ASPMVCCOREContext _Context)
        {

            Context = _Context;
            _logger = logger;
          uw =  unitOfWork;
   
            
        }

        public IActionResult Index()
        {
            
            var list = uw.Repository<Produit>().Listes();
            return View(list);
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
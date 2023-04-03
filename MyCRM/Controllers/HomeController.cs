using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCRM.Controllers{
    [Authorize]
    public class HomeController : Controller{

        private IAllUsers UsersRep;

        public HomeController(IAllUsers UsersRep) {
            this.UsersRep = UsersRep;
        }


        public IActionResult Home() {

            HomeViewModel model = new HomeViewModel();
            model.bill = UsersRep.GetUserByName(User.Identity.Name).bill;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument xml = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp?");

            model.USA = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value);
            model.EUR = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value);
            model.UAH = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "980").Elements("Value").FirstOrDefault().Value) / 10;

            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo.Web.Controllers
{
    public class ContactsController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}

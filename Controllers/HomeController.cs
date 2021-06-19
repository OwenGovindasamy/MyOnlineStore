using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyOnlineStore.Interfaces;
using MyOnlineStore.Logic;
using MyOnlineStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyOnlineStore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiMethods _apiMethods;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager, ILogger<HomeController> logger, IApiMethods apiMethods)
        {
            _userManager = userManager;
            _logger = logger;
            _apiMethods = apiMethods;
        }

        public async Task<ActionResult<List<StoreItems>>> Index()
        {
            var userToken = await _apiMethods.GetToken();
            
            if(!String.IsNullOrEmpty(userToken.Token))
            {
                return View(await _apiMethods.PostWithToken(userToken.Token));
            }
            throw new Exception("Invalid Token");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

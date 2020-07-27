using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameStore.Web.Models;
using IUnitOfWork = GameStore.Application.Interfaces.IUnitOfWork;

namespace GameStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameService _gameService;
        public HomeController(ILogger<HomeController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _gameService.GetListOfAllGamesAsync());
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

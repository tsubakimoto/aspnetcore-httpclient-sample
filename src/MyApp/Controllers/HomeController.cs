﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly DocsService docsService;

        public HomeController(IHttpClientFactory httpClientFactory, DocsService docsService)
        {
            this.httpClientFactory = httpClientFactory;
            this.docsService = docsService;
        }

        public async Task<IActionResult> Hoge()
        {
            // using directory
            var defaultClient = httpClientFactory.CreateClient();
            var defaultResult = await defaultClient.GetStringAsync("https://docs.microsoft.com/ja-jp/aspnet/");

            // using named clients
            var docsClient = httpClientFactory.CreateClient("docs");
            var docsResult = await docsClient.GetStringAsync("/ja-jp/aspnet/");

            // using typed clients
            var docsResult2 = await docsService.Client.GetStringAsync("/ja-jp/aspnet/");

            return Content(docsResult2);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

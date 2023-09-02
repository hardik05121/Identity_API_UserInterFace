using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {

            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        
    }
}
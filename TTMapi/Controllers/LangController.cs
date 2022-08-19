using TTMapi.Models;
using TTMapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using MongoDB.Bson;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TTMapi.Controllers
{
    [Authorize]
    [Route("api/langs")]
    [ApiController]
    public class LangController : ControllerBase
    {
        private readonly LangService _LangService;

        public LangController(LangService TagCatService)
        {
            _LangService = TagCatService;
        }

        [HttpGet]
        public ActionResult<List<Language>> Get()
        {
            return _LangService.Get();
        }
    }
}
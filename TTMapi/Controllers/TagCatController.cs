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
    [Route("api/tagcats")]
    [ApiController]
    public class TagCatController : ControllerBase
    {
        private readonly TagCatService _TagCatService;

        public TagCatController(TagCatService TagCatService)
        {
            _TagCatService = TagCatService;
        }

        [HttpGet]
        public ActionResult<List<TagCat>> Get()
        {
            return _TagCatService.Get();
        }
    }
}
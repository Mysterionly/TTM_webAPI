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
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TagService _TagService;

        public TagController(TagService TagService)
        {
            _TagService = TagService;
        }

        [HttpGet]
        public ActionResult<List<Tag>> Get()
        {
            return _TagService.Get();
        }
    }
}
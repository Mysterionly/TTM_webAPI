using TTMapi.Models;
using TTMapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;

namespace TTMapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DialsController : ControllerBase
    {
        private readonly DialService _DialService;

        public DialsController(DialService DialService)
        {
            _DialService = DialService;
        }

        [HttpGet]
        public ActionResult<List<Dial>> Get() =>
            _DialService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDial")]
        public ActionResult<Dial> Get(string id)
        {
            var Dial = _DialService.Get(id);

            if (Dial == null)
            {
                return NotFound();
            }

            return Dial;
        }

        //[HttpPost]
        //public ActionResult<Dial> Create(string uin)
        //{
        //    Dial Dial = JsonConvert.DeserializeObject<Dial>(uin);
        //    _DialService.Create(Dial);

        //    return CreatedAtRoute("GetDial", new { id = Dial.Id.ToString() }, Dial);
        //}
        
        [HttpPost("newDial")]
        public ActionResult<Dial> CreateDial(Dial dial)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string uid = identity.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                Dial dial_ = new Dial("", "test_tit", true, "eng", null, new DialUsr(uid, "anonymous"), null, "testTag");
                _DialService.Create(dial_);
                _DialService.newDialMsg(new DialMsg(dial_.Id, uid, System.DateTime.Now, "hello world!"));
                //return CreatedAtRoute("GetDial", new { id = dial_.Id.ToString() }, dial_);
                return GetNewDial(dial_.tagList[0], uid);
            }
            else return Unauthorized();
        }


        [HttpPost("getNew")]
        public ActionResult<Dial> GetNewDial(string tag, string uid)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var Dial = _DialService.GetByTag(tag, uid);
                if (Dial == null)
                {
                    return NotFound();
                }
                else return Dial;
            }
            else return Unauthorized();

        }


        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, string uin)
        //{
        //    Dial DialIn = JsonConvert.DeserializeObject<Dial>(uin);
        //    var Dial = _DialService.Get(id);

        //    if (Dial == null)
        //    {
        //        return NotFound();
        //    }

        //    _DialService.Update(id, DialIn);

        //    return CreatedAtRoute("GetDial", new { id = Dial.Id.ToString() }, Dial);
        //}

        //[HttpDelete("{id:length(24)}")]
        //public IActionResult Delete(string id)
        //{
        //    Dial Dial = _DialService.Get(id);

        //    if (Dial == null)
        //    {
        //        return NotFound();
        //    }

        //    _DialService.Remove(Dial.Id);

        //    return NoContent();
        //}

        //------------
    }
}
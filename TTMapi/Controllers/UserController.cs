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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _UserService;

        public UsersController(UserService UserService)
        {
            _UserService = UserService;
        }

        //[HttpGet]
        //public ActionResult<List<User>> GetAll()
        //{
        //    return _UserService.Get();
        //}

        [HttpGet]
        public ActionResult<User> Get()
        {
            string realId = "";
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null) realId = identity.FindFirst("Id").Value;
            else return BadRequest();

            return _UserService.Get(realId);
        }

        [AllowAnonymous]
        [HttpPost("authorize")]
        public ActionResult<UserCmd> SignUpGoogle(string gid)
        {
            if (gid != null)
            {
                try
                {
                    string id0 = _UserService.GetByGid(gid);
                    if (id0 != null)
                    {
                        User me = _UserService.Get(id0);
                        return new UserCmd(_UserService.GetToken(id0), me.Id, me.userName, null, null, me.email, me.langList, me.tagList, me.itemList, null);
                    }
                    else return NotFound();
                }
                catch
                {
                    return BadRequest();
                }
            }
            else return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public ActionResult<UserCmd> SignUp(User newUser)
        {
            try
            {
                _UserService.Create(newUser);
                User me = _UserService.Get(newUser.Id);
                return new UserCmd(_UserService.GetToken(newUser.Id), me.Id, me.userName, null, null, me.email, me.langList, me.tagList, me.itemList, null);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //[AllowAnonymous]
        //[HttpGet("token")]
        //public string Get(string id)
        //{
        //    return _UserService.GetToken(id);
        //}

        //[HttpGet("{id:length(24)}", Name = "GetUser")]
        //public ActionResult<User> Get(string id)
        //{
        //    var User = _UserService.Get(id);

        //    if (User == null)
        //    {
        //        return NotFound();
        //    }

        //    return User;
        //}

        [HttpPost]
        public ActionResult<User> Manage(UserCmd User)//string uin)
        {
            if (User != null)
            {
                string realId = "";
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null) realId = identity.FindFirst("Id").Value;

                User u = new User(realId, User.userName, User.googleId, User.password, User.email, User.langList, User.tagList, User.itemList, User.blockedList);
                switch (User.command)
                {
                    //case "getByGid":
                    //    {
                    //        try
                    //        {
                    //            string id0 = _UserService.GetByGid(u.googleId);
                    //            return _UserService.Get(id0);
                    //        }
                    //        catch (Exception e)
                    //        {
                    //            return BadRequest();
                    //        }
                    //    }
                    //case "create":
                    //    {
                    //        try
                    //        {
                    //            _UserService.Create(u);
                    //            return _UserService.Get(u.Id);
                    //            //return CreatedAtRoute("GetUser", new { id = u.Id.ToString() }, u);
                    //        }
                    //        catch (Exception e)
                    //        {
                    //            return BadRequest();
                    //        }
                    //    }
                    case "delete": //sending empty User with Id only
                        {
                            try
                            {
                                _UserService.Remove(User.Id);
                                return NoContent();
                            }
                            catch (Exception e)
                            {
                                return BadRequest();
                            }
                        }
                    case "editInfo": //sending User with Id, gid, email and password
                        {
                            User me = _UserService.Get(u.Id);
                            me.userName = u.userName;
                            me.password = u.password;
                            _UserService.Update(me.Id, me);
                            return me;
                        }
                    case "setInfo": //sending User with Id, gid, email and password
                        {
                            User me = _UserService.Get(u.Id);
                            me.userName = u.userName;
                            me.password = u.password;
                            me.langList = u.langList;
                            me.tagList = u.tagList;
                            //me.infoSet = true; //- запретим пользователю пользоваться, пока он не укажет данные
                            _UserService.Update(me.Id, me);
                            return me;
                        }
                    case "editTags": //sending empty User with Id and tagList only
                        {
                            User me = _UserService.Get(u.Id);
                            me.tagList = u.tagList;
                            _UserService.Update(me.Id, me);
                            return me;
                        }
                    case "editLangs": //sending empty User with Id and tagList only
                        {
                            User me = _UserService.Get(u.Id);
                            me.langList = u.langList;
                            _UserService.Update(me.Id, me);
                            return me;
                        }
                    case "editItems": //sending empty User with Id and itemList only
                        {
                            User me = _UserService.Get(u.Id);
                            me.itemList = u.itemList;
                            _UserService.Update(me.Id, me);
                            return me;
                        }
                    case "editBlocked": //sending empty User with Id and blockedList only
                        {
                            User me = _UserService.Get(u.Id);
                            me.blockedList = u.blockedList;
                            _UserService.Update(me.Id, me);
                            return me;
                        }
                    default:
                        {
                            return BadRequest();
                        }
                }
            }
            else return NotFound();
        }

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, User UserIn)
        //{
        //    var User = _UserService.Get(id);

        //    if (User == null)
        //    {
        //        return NotFound();
        //    }

        //    _UserService.Update(id, UserIn);
        //    return CreatedAtRoute("GetUser", new { id = User.Id.ToString() }, UserIn);
        //}


        //[HttpDelete("{id:length(24)}")]
        //public IActionResult Delete(string id)
        //{
        //    User User = _UserService.Get(id);

        //    if (User == null)
        //    {
        //        return NotFound();
        //    }

        //    _UserService.Remove(User.Id);

        //    return NoContent();
        //}
    }
}
using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;
using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using System.Net;
using System;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/public")]
    public class BookStoreController : ControllerBase
    {
        UserRepository _repository = new UserRepository();
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                User user = _repository.Login(model);
                if (user == null)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User not found");
                }
                else
                {
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                User user = _repository.Register(model);
                if (user == null)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User not found");
                }
                else
                {
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}

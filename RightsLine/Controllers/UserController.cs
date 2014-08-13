using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using RightsLine.Data.Facades;
using RightsLine.Data.Models;

namespace RightsLine.Controllers {
    public class UserController : ApiController {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade) {
            _userFacade = userFacade;
        }

        // GET api/values
        public IEnumerable<User> Get() {
            var users = _userFacade.GetUsers();
            return users;
        }

        // GET api/values/5
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]User user) {
            if (ModelState.IsValid) {
                _userFacade.CreateUser(user);

                return new HttpResponseMessage(HttpStatusCode.OK);
            } else {
                if (!user.Validated) {
                    var validationResults = user.Validate(new ValidationContext(user, null, null));
                    foreach (var error in validationResults) {
                        foreach (var memberName in error.MemberNames) {
                            ModelState.AddModelError(memberName, error.ErrorMessage);
                        }
                    }
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        public void Delete(int id) {
        }
    }
}
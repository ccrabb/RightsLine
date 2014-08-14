using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;
using MongoDB.Bson;
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
            return _userFacade.GetUsers();
        }

        // GET api/User/{ObjectId}
        public User Get(string id) {
            return _userFacade.GetUser(new ObjectId(id));
        }

        // POST api/User
        public HttpResponseMessage Post([FromBody]User user) {
            if (ModelState.IsValid) {
                _userFacade.CreateUser(user);

                return new HttpResponseMessage(HttpStatusCode.OK);
            } else {
                ValidateUser(user);

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/User/{ObjectId}
        public HttpResponseMessage Put(string id, [FromBody]User user) {
            if (ModelState.IsValid) {
                _userFacade.UpdateUser(user);

                return new HttpResponseMessage(HttpStatusCode.OK);
            } else {
                ValidateUser(user);

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/User/{ObjectId}
        public void Delete(ObjectId id) {
            _userFacade.DeleteUser(id);
        }

        /// <summary>
        /// This method forces IValidateableObject Validate() to be called even when Data Annotation validation fails
        /// </summary>
        /// <param name="user">The user to be validated</param>
        private void ValidateUser(User user) {
            if (!user.Validated) {
                var validationResults = user.Validate(new ValidationContext(user, null, null));
                foreach (var error in validationResults) {
                    foreach (var memberName in error.MemberNames) {
                        ModelState.AddModelError(memberName, error.ErrorMessage);
                    }
                }
            }
        }
    }
}
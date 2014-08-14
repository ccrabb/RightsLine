using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using RightsLine.Data.Facades;
using RightsLine.Data.Models;

namespace RightsLine.Controllers {
    // TODO: Implement an ObjectId JsonConverter
    public class UserController : ApiController {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade) {
            _userFacade = userFacade;
        }

        // GET api/values
        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>All Users</returns>
        public IEnumerable<User> Get() {
            return _userFacade.GetUsers();
        }

        // GET api/User/{ObjectId}
        /// <summary>
        /// Get a specific user
        /// </summary>
        /// <param name="id">Bson ObjectId</param>
        /// <returns>User</returns>
        public User Get(string id) {
            return _userFacade.GetUser(new ObjectId(id));
        }

        // POST api/User
        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="user">The created User with its ID set</param>
        /// <returns></returns>
        public User Post([FromBody]User user) {
            if (ModelState.IsValid) {
                _userFacade.CreateUser(user);

                return user;
            } else {
                ValidateUser(user);

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }
        }

        // PUT api/User/{ObjectId}
        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="id">Bson ObjectId</param>
        /// <param name="user">Updated User</param>
        /// <returns></returns>
        public User Put(string id, [FromBody]User user) {
            if (ModelState.IsValid) {
                _userFacade.UpdateUser(id, user);

                return user;
            } else {
                ValidateUser(user);

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }
        }

        // DELETE api/User/{ObjectId}
        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id">Bson ObjectId</param>
        public void Delete(string id) {
            _userFacade.DeleteUser(new ObjectId(id));
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
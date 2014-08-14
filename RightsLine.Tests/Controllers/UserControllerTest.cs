using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using RightsLine.Common;
using RightsLine.Data.Facades;
using RightsLine.Data.Models;

namespace RightsLine.Tests.Controllers {
    [TestClass]
    public class UserControllerTest {
        [TestMethod]
        public void GetAllUsers()
        {
            var userFacade = new UserFacadeMemory();
        }

        private IEnumerable<User> GetTestUsers() {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "Cory Crabb",
                    Email = "ccrabb@gmail.com",
                    Phone = "760-814-5053",
                    BirthDate = new DateTime(1986, 8, 18),
                    Gender = Gender.Male,
                    ID = new ObjectId(),
                    IsActive = true
                },
                new User()
                {
                    Name = "Walter White",
                    Email = "wwhite@gmail.com",
                    Phone = "555-814-5053",
                    BirthDate = new DateTime(1956, 3, 7),
                    Gender = Gender.Male,
                    ID = new ObjectId(),
                    IsActive = true
                },
                new User()
                {
                    Name = "Bill Gates",
                    Email = "bgates@bing.com",
                    Phone = "555-713-5823",
                    BirthDate = new DateTime(1955, 10, 28),
                    Gender = Gender.Male,
                    ID = new ObjectId(),
                    IsActive = true
                }
            };

            return users;
        }
    }
}

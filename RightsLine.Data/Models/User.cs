using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RightsLine.Common;

namespace RightsLine.Data.Models {
    [DataContract]
    public class User : IValidatableObject {
        [BsonIgnore]
        public bool Validated { get; set; }

        [DataMember]
        [BsonId]
        public ObjectId ID { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Email { get; set; }

        [DataMember]
        [Required]
        public string Phone { get; set; }

        [DataMember]
        [Required]
        public DateTime BirthDate { get; set; }

        [DataMember]
        [Required]
        public Gender Gender { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            this.Validated = true;
            if (!this.Email.Contains("@") || !this.Email.Contains(".")) {
                yield return new ValidationResult("Invalid Email", new List<string>() { "Email" });
            }
        }
    }
}
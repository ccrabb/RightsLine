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
        [RegularExpression(@"^(?:\([2-9]\d{2}\)\ ?|[2-9]\d{2}(?:\-?|\ ?))[2-9]\d{2}[- ]?\d{4}$")]
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
            // I'm in the anti-complex-regex for email validation club, see: http://stackoverflow.com/questions/201323/using-a-regular-expression-to-validate-an-email-address
            // This simple validation could and still should be done using a regex (like it is on the client)
            if (!this.Email.Contains("@") || !this.Email.Contains(".")) {
                yield return new ValidationResult("Invalid Email", new[] { "Email" });
            }

            if (this.Name == "John Doe") {
                yield return new ValidationResult("I don't think so", new[] { "Name" });
            }
        }
    }
}
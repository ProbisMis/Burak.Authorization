using Burak.Authorization.Models.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Authorization.Models.Responses
{
    public class UserResponse : ServiceAdaptorException
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string UserCode { get; set; } //TODO:  Unique number generated for Client  online-interactions (gift, invite)
        public string ParentCode { get; set; }
        public string FacebookGameId { get; set; }
        public string AndroidGameId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } //TODO: Convert to Password Model (hash,password,salt,updated,userid,id), Map to Passwords
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public string CustomValues { get; set; } //TODO: JToken converter
        public string Token { get; set; }
    }
}

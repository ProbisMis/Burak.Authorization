using Burak.Authorization.Models.BaseModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burak.Authorization.Data.EntityModels
{
    /// <summary>
    /// Appointment Migration DB Entity class
    /// </summary>
    public class User : IEntity<int>
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

        //[ForeignKey(nameof(TypeId))]
        //public virtual Type Type { get; set; }

        //[ForeignKey(nameof(StatusId))]
        //public virtual Status Status { get; set; }

        //[ForeignKey(nameof(SlotId))]
        //public virtual Slot Slot { get; set; }
    }
}

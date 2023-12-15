using Domain.Role;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [DataContract]
    public class Users : IdentityUser<Guid>
    {
        [DataMember]
        public override Guid Id { get; set; } = Guid.NewGuid();
        [DataMember]
        public string Name { get; set; } = null!;
        [DataMember]
        public string Address { get; set; } = null!;
        [DataMember]
        public string PhoneNumber { get; set; } = null!;
        [DataMember]
        public string Password { get; set; } = null!;
        [DataMember]
        public int RoleId { get; set; }
        public virtual Roles Role { get; set; }
        [DataMember]
        public string Image { get; set; } = null!;
    }
}

using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Role
{
    [DataContract]
    public class Roles
    {
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; } = string.Empty;
        public ICollection<Users>? Users { get; set; }
    }
}

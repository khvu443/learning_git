﻿using Domain.Entities.Tree;
using Domain.Entities.TreeType;
using System.Runtime.Serialization;

namespace Domain.Entities.Cultivar
{
    [DataContract]
    public class Cultivars
    {
        [DataMember]
        public Guid CultivarId { get; set; }

        [DataMember]
        public string CultivarName { get; set; }

        [DataMember]
        public Guid TreeTypeId { get; set; }

        public virtual TreeTypes? TreeTypes { get; set; }

        public ICollection<Trees>? Trees { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [DataMember]
        public string CreateBy { get; set; }

        [DataMember]
        public DateTime UpdateDate { get; set; }

        [DataMember]
        public string UpdateBy { get; set; }
    }
}
﻿using Domain.Entities.ScheduleGarbageCollect;
using Domain.Entities.Street;
using System.Runtime.Serialization;

namespace Domain.Entities.ScheduleGarbageCollect_street_map
{
    [DataContract]
    public class ScheduleGarbageCollect_street_maps
    {
        [DataMember]
        public Guid StreetId { get; set; }

        public virtual Streets? Street { get; set; }

        [DataMember]
        public Guid ScheduleGarbageCollectId { get; set; }

        public virtual ScheduleGarbageCollects? ScheduleGarbageCollect { get; set; }

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
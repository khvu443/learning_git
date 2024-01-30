﻿using Domain.Entities.ScheduleTreeTrim;
using Domain.Entities.User;
using System.Runtime.Serialization;

namespace Domain.Entities.ListTreeTrimmerTask
{
    [DataContract]
    public class User_scheduleTreeTrim_maps
    {
        [DataMember]
        public Guid UserId { get; set; }

        public virtual Users? Users { get; set; }

        [DataMember]
        public Guid ScheduleTreeTrimId { get; set; }

        public virtual ScheduleTreeTrims? ScheduleTreeTrims { get; set; }

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
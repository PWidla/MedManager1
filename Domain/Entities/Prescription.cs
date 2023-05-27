﻿using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Prescription")]
    public class Prescription : BaseEntity<int>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Medicines { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}

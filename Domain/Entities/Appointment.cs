﻿using Application.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Appointment")]
    public class Appointment : IIdentity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}

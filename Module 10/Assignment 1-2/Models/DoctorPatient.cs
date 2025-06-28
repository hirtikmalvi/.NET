using System;
using System.Collections.Generic;

namespace Assignment_1_2.Models;

public partial class DoctorPatient
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}

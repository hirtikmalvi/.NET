using System;
using System.Collections.Generic;

namespace Assignment_1_2.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? PatientName { get; set; }

    public virtual ICollection<DoctorPatient> DoctorPatients { get; set; } = new List<DoctorPatient>();

    public virtual ICollection<PatientDrug> PatientDrugs { get; set; } = new List<PatientDrug>();
}

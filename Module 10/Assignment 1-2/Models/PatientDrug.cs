using System;
using System.Collections.Generic;

namespace Assignment_1_2.Models;

public partial class PatientDrug
{
    public int PatientId { get; set; }

    public int DrugId { get; set; }

    public string? TimeOfDay { get; set; }

    public virtual Drug Drug { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}

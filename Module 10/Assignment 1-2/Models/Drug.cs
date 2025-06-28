using System;
using System.Collections.Generic;

namespace Assignment_1_2.Models;

public partial class Drug
{
    public int DrugId { get; set; }

    public string? DrugName { get; set; }

    public virtual ICollection<PatientDrug> PatientDrugs { get; set; } = new List<PatientDrug>();
}

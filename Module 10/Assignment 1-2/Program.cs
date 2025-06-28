using Assignment_1_2.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static void AddData()
    {
        try
        {
            using (var context = new HospitalManagementSystemContext())
            {
                //context.Departments.AddRange(new Department { DepartmentName = "Cardiology" },
                //  new Department { DepartmentName = "Neurology" },
                //  new Department { DepartmentName = "Orthopedics" });

                //context.SaveChanges();


                //context.Doctors.AddRange(
                //    new Doctor { DoctorName = "Dr. Ajay Mehta", DepartmentId = 1 },
                //    new Doctor { DoctorName = "Dr. Neha Sharma", DepartmentId = 2 },
                //    new Doctor { DoctorName = "Dr. Rahul Verma", DepartmentId = 3 });

                //context.SaveChanges();


                //context.Patients.AddRange(
                //    new Patient { PatientName = "Ravi Patel" },
                //    new Patient { PatientName = "Sonal Desai" },
                //    new Patient { PatientName = "Karan Joshi" }
                //);

                //context.SaveChanges();
                //context.DoctorPatients.AddRange(
                //    new DoctorPatient { DoctorId = 1, PatientId = 1 },
                //    new DoctorPatient { DoctorId = 2, PatientId = 2 },
                //    new DoctorPatient { DoctorId = 2, PatientId = 3 },
                //    new DoctorPatient { DoctorId = 3, PatientId = 3 } // Karan has 2 doctors
                //);

                //context.SaveChanges();

                //context.Drugs.AddRange(
                //    new Drug { DrugName = "Paracetamol" },
                //    new Drug { DrugName = "Aspirin" },
                //    new Drug { DrugName = "Metformin" }
                //);
                //context.SaveChanges();

                //context.PatientDrugs.AddRange(
                //    new PatientDrug { PatientId = 1, DrugId = 1, TimeOfDay = "Morning" },
                //    new PatientDrug { PatientId = 1, DrugId = 2, TimeOfDay = "Night" },
                //    new PatientDrug { PatientId = 2, DrugId = 3, TimeOfDay = "Afternoon" },
                //    new PatientDrug { PatientId = 3, DrugId = 1, TimeOfDay = "Morning" },
                //    new PatientDrug { PatientId = 3, DrugId = 3, TimeOfDay = "Night" }
                //);

                //context.SaveChanges();

                Console.WriteLine("Data Added...");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.InnerException}");
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("--------- Hospital Management System ---------");
        //AddData();

        try
        {
            using (var context = new HospitalManagementSystemContext())
            {
                var foundDoctor = context.Doctors.Find(1);
                if (foundDoctor != null)
                {
                    //foundDoctor.DoctorName = "Dr. Hirtik Malvi";
                    //context.Doctors.Remove(foundDoctor);
                }
                var doctorWithPatients = context.Doctors.Include(d => d.DoctorPatients).ThenInclude(dp => dp.Patient).FirstOrDefault(d => d.DoctorId == 2);

                if (doctorWithPatients != null)
                {
                    Console.WriteLine($"DoctorId: {doctorWithPatients.DoctorId} - Name: {doctorWithPatients.DoctorName}");
                    foreach (var dp in doctorWithPatients.DoctorPatients)
                    {
                        Console.WriteLine($"\tPatientId: {dp.Patient.PatientId} - PatientName: {dp.Patient.PatientName}");
                    }
                }

                var patientWithDrigs = context.Patients.Include(p => p.PatientDrugs).ThenInclude(pd => pd.Drug).FirstOrDefault(p => p.PatientId == 3);

                if (patientWithDrigs != null)
                {
                    Console.WriteLine($"PatientId: {patientWithDrigs.PatientId} - Name: {patientWithDrigs.PatientName}");
                    foreach (var pd in patientWithDrigs.PatientDrugs)
                    {
                        Console.WriteLine($"\tDrugId: {pd.Drug.DrugId} - DrugName: {pd.Drug.DrugName}");
                    }
                }

                //context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception Main Method: {e.Message} \n{e.InnerException}");
        }
    }
}
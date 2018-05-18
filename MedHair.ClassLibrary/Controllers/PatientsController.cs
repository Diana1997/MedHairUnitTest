using MedHair.ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedHair.ClassLibrary.Controllers
{
	public partial class MedHairController
    {
        public int CreatePatient(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
            return patient.PatientID;
        }
        public void EditPatient(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            db.Entry(patient.Contact).State = EntityState.Modified;
            db.SaveChanges();

            //ToDo update Images collection

        }

        public void DeletePatient(int id)
        {
            Patient patient = db.Patients
                   .Include(p => p.Contact).FirstOrDefault(x => x.PatientID == id);
            db.Contacts.Remove(patient.Contact);
            db.Images.RemoveRange(patient.Images);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

        public Patient GetPatient(int id)
        {
			//eager loading
			return db.Patients
				.Include(p => p.Contact).AsNoTracking().FirstOrDefault(x => x.PatientID == id);
        }

        public IList<Patient> GetPatient()
        {
			//eager loading
			return db.Patients
				.Include(p => p.Contact).AsNoTracking().ToList();
        }
    }
}

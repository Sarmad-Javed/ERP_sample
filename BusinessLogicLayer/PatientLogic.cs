using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAL_Logic.Patient.ManagePatient;
using ERPEntities.Models;

namespace BusinessLogicLayer
{
    public class PatientLogic
    {
        //Initializaton
        PatientDAL PatientDAL = new PatientDAL();
        List<PatientModel> PatientList = new List<PatientModel>();


        //add record
        public void addPatient(AddPatientModel patient)
        {
            PatientDAL.addPatient(patient);
        }

        //get Patient List
        public List<PatientModel> getPatientList()
        {
            PatientList = PatientDAL.getPatientsList();
            return PatientList;
        }

        public List<PatientModel> viewPatientListByID(int id)
        {
            PatientList = PatientDAL.viewPatientListByID(id);
            return PatientList;
        }

        //getItembyID
        public PatientModel viewPatientByID(int id)
        {
            PatientModel patient = new PatientModel();
            patient = PatientDAL.viewPatientByID(id);
            return patient;
        }

        //UpdateItem
        public void updatePatient(int id, PatientModel patient)
        {
            PatientDAL.updatePatient(id, patient);
        }

        //deleteItem
        public void deletePatient(int id)
        {
            PatientDAL.deletePatient(id);
        }

    }
}
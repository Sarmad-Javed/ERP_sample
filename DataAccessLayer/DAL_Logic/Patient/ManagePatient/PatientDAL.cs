using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;

namespace DataAccessLayer.DAL_Logic.Patient.ManagePatient
{
    public class PatientDAL
    {
        List<PatientModel> PatientList = new List<PatientModel>();
        PatientModel patient = new PatientModel();
        SqlConnection Sqlcon = new SqlConnection("Data Source=Ijlal07-PC;Initial Catalog=ERP;Integrated Security=True");
        public void addPatient(AddPatientModel patient)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Add_Patient", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                Sqlcmd.Parameters.AddWithValue("@PatientAddress", patient.PatientAddress);
                Sqlcmd.Parameters.AddWithValue("@PatientContact", patient.PatientContact);
                Sqlcmd.Parameters.AddWithValue("@PatientEmail", patient.PatientEmail);
                Sqlcmd.Parameters.AddWithValue("@ZIPCode", patient.ZIPCode);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public List<PatientModel> getPatientsList()
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Show_Patient", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                PatientModel patient = new PatientModel();
                patient.PatientID = Convert.ToInt32(dr["PatientID"]);
                patient.PatientName = Convert.ToString(dr["PatientName"]);
                patient.PatientAddress = Convert.ToString(dr["PatientAddress"]);
                patient.PatientContact = Convert.ToString(dr["PatientContact"]);
                patient.PatientEmail = Convert.ToString(dr["PatientEmail"]);
                patient.ZIPCode = Convert.ToInt32(dr["ZIPCode"]);

                PatientList.Add(patient);
            }
            Sqlcon.Close();
            return PatientList;
        }

        public List<PatientModel> viewPatientListByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_PatientbyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@PatientID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {

                patient.PatientID = Convert.ToInt32(dr["PatientID"]);
                patient.PatientName = Convert.ToString(dr["PatientName"]);
                patient.PatientAddress = Convert.ToString(dr["PatientAddress"]);
                patient.PatientContact = Convert.ToString(dr["PatientContact"]);
                patient.PatientEmail = Convert.ToString(dr["PatientEmail"]);
                patient.ZIPCode = Convert.ToInt32(dr["ZIPCode"]);
                PatientList.Add(patient);

            }
            Sqlcon.Close();
            return PatientList;
        }

        public PatientModel viewPatientByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_PatientbyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@PatientID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                patient.PatientID = Convert.ToInt32(dr["PatientID"]);
                patient.PatientName = Convert.ToString(dr["PatientName"]);
                patient.PatientAddress = Convert.ToString(dr["PatientAddress"]);
                patient.PatientContact = Convert.ToString(dr["PatientContact"]);
                patient.PatientEmail = Convert.ToString(dr["PatientEmail"]);
                patient.ZIPCode = Convert.ToInt32(dr["ZIPCode"]);

            }
            Sqlcon.Close();
            return patient;
        }

        public void updatePatient(int id, PatientModel patient)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Update_Patient", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@PatientID", id);
                Sqlcmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                Sqlcmd.Parameters.AddWithValue("@PatientAddress", patient.PatientAddress);
                Sqlcmd.Parameters.AddWithValue("@PatientContact", patient.PatientContact);
                Sqlcmd.Parameters.AddWithValue("@PatientEmail", patient.PatientEmail);
                Sqlcmd.Parameters.AddWithValue("@ZIPCode", patient.ZIPCode);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public void deletePatient(int id)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                SqlCommand Sqlcmd = new SqlCommand("SP_Delete_Patient", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@PatientID", id);
                Sqlcon.Open();
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }


    }
}

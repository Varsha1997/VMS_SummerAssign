using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VMS_SummerAssign.Models
{
    public class VolunteerDBhandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["volunteerconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW VOLUNTEER *********************
        public bool AddVolunteer(VolunteerModel vmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("InsertVolunteer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FName", vmodel.FName);
            cmd.Parameters.AddWithValue("@LName", vmodel.LName);
            cmd.Parameters.AddWithValue("@Email", vmodel.Email);
            cmd.Parameters.AddWithValue("@DriversLicense", vmodel.DriversLicense);
            cmd.Parameters.AddWithValue("@UserName", vmodel.UserName);
            cmd.Parameters.AddWithValue("@Password", vmodel.Password);
            cmd.Parameters.AddWithValue("@VolApprovStat", vmodel.VolApprovStat);
            cmd.Parameters.AddWithValue("@Centers", vmodel.Centers);
            cmd.Parameters.AddWithValue("@Skills", vmodel.Skills);
            cmd.Parameters.AddWithValue("@HomeAddress", vmodel.HomeAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", vmodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Education", vmodel.Education);
            cmd.Parameters.AddWithValue("@Licenses", vmodel.Licenses);
            cmd.Parameters.AddWithValue("@EmergContactName", vmodel.EmergContactName);
            cmd.Parameters.AddWithValue("@EmergContactPhone", vmodel.EmergContactPhone);
            cmd.Parameters.AddWithValue("@EmergContactAddress", vmodel.EmergContactAddress);
            cmd.Parameters.AddWithValue("@SocialSecurity", vmodel.SocialSecurity);
            cmd.Parameters.AddWithValue("@AvailabilityTimes", vmodel.AvailabilityTimes);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW VOLUNTEER DETAILS ********************
        public List<VolunteerModel> GetVolunteer()
        {
            connection();
            List<VolunteerModel> volunteerlist = new List<VolunteerModel>();

            SqlCommand cmd = new SqlCommand("GetVolunteer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                volunteerlist.Add(
                    new VolunteerModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FName = Convert.ToString(dr["FName"]),
                        LName = Convert.ToString(dr["LName"]),
                        Email = Convert.ToString(dr["Email"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        Password = Convert.ToString(dr["Password"]),
                        VolApprovStat = Convert.ToString(dr["VolApprovStat"]),
                        DriversLicense = Convert.ToString(dr["DriversLicense"]),
                        Centers = Convert.ToString(dr["Centers"]),
                        Skills = Convert.ToString(dr["Skills"]),
                        HomeAddress = Convert.ToString(dr["HomeAddress"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Education = Convert.ToString(dr["Education"]),
                        Licenses = Convert.ToString(dr["Licenses"]),
                        EmergContactName = Convert.ToString(dr["EmergContactName"]),
                        EmergContactPhone = Convert.ToString(dr["EmergContactPhone"]),
                        EmergContactAddress = Convert.ToString(dr["EmergContactAddress"]),
                        SocialSecurity = Convert.ToString(dr["SocialSecurity"]),
                        AvailabilityTimes = Convert.ToString(dr["AvailabilityTimes"])
                    });
            }
            return volunteerlist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(VolunteerModel vmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateVolunteerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VolId", vmodel.Id);
            cmd.Parameters.AddWithValue("@FName", vmodel.FName);
            cmd.Parameters.AddWithValue("@LName", vmodel.LName);
            cmd.Parameters.AddWithValue("@Email", vmodel.Email);
            cmd.Parameters.AddWithValue("@UserName", vmodel.UserName);
            cmd.Parameters.AddWithValue("@Password", vmodel.Password);
            cmd.Parameters.AddWithValue("@VolApprovStat", vmodel.VolApprovStat);
            cmd.Parameters.AddWithValue("@DriversLicense", vmodel.DriversLicense);
            cmd.Parameters.AddWithValue("@Centers", vmodel.Centers);
            cmd.Parameters.AddWithValue("@Skills", vmodel.Skills);
            cmd.Parameters.AddWithValue("@HomeAddress", vmodel.HomeAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", vmodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Education", vmodel.Education);
            cmd.Parameters.AddWithValue("@Licenses", vmodel.Licenses);
            cmd.Parameters.AddWithValue("@EmergContactName", vmodel.EmergContactName);
            cmd.Parameters.AddWithValue("@EmergContactPhone", vmodel.EmergContactPhone);
            cmd.Parameters.AddWithValue("@EmergContactAddress", vmodel.EmergContactAddress);
            cmd.Parameters.AddWithValue("@SocialSecurity", vmodel.SocialSecurity);
            cmd.Parameters.AddWithValue("@AvailabilityTimes", vmodel.AvailabilityTimes);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteVolunteer(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteVolunteer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VolId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
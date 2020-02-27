﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    ///
    /// This Class for accessing Adoption Applications data.
    /// </summary>
    public class HomeInspectorAccessor : IHomeInspectorAccessor
    {

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method used to get Customer first name and last name by Customer
        /// ID.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" CustomerID"></param>
        /// <returns>Customer Name</returns>
        private string GetCustomerNameByCustomerID(int CustomerID)
        {
            string customerName = null;
            // connection?
            var conn = DBConnection.GetConnection();
            // commands?
            var cmd = new SqlCommand("sp_select_CustomerName_by_CustomerID", conn);
            // command type?
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            try
            {
                string lastName = null;
                string firstName = null;
                // open the connection
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lastName = reader.GetString(1);
                    firstName = reader.GetString(0);
                    customerName = lastName;
                }
                else
                {
                    throw new ApplicationException("Record not found..");
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return customerName;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method used to get Animal name by Animal ID.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" AnimalID"></param>
        /// <returns>animal Name</returns>
        private string SelectAnimalNameByAnimalID(int AnimalID)
        {

            string animalName = null;
            // connection?
            var conn = DBConnection.GetConnection();
            // commands?
            var cmd = new SqlCommand("sp_select_AnimalName_by_AnimalID", conn);
            // command type?
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", AnimalID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        animalName = reader.GetString(0);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return animalName;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method used to get Adoption Applications where thier status
        /// is In-home Inspection.
        /// 
        /// </summary>      
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns>Adoption Applications list</returns>
        public List<AdoptionApplication> SelectAdoptionApplicationsByStatus()
        {
            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_AdoptionApplication_by_Status", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var adoptionApplication = new AdoptionApplication()
                        {
                            AdoptionApplicationID = reader.GetInt32(0),
                            AnimalName = SelectAnimalNameByAnimalID(reader.GetInt32(1)),
                            CustomerName = GetCustomerNameByCustomerID(reader.GetInt32(2)),
                            Status = reader.GetString(3),
                            RecievedDate = reader.GetDateTime(4)
                        };
                        adoptionApplications.Add(adoptionApplication);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return adoptionApplications;
        }
    }
}

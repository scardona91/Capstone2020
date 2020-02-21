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
    /// NAME:Lane Sandburg
    /// DATE: 02/05/2019
    /// CHECKED BY:Alex Diers
    /// 
    /// the shiftTime Data Accessor
    /// </summary>
    /// <remarks>
    /// UPDATED BY:NA
    /// UPDATED DATE:
    /// WHAT WAS CHANGED:
    /// </remarks> 
    public class ShiftTimeAccessor : IShiftTimeAccessor
    {

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2020
        /// Approver:Alex Diers
        /// 
        /// Opens DB Connection to Insert a new ShiftTime
        /// and sets parameters for insertion
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        /// <param name="shiftTime"></param>

        public int InsertShiftTime(PetUniverseShiftTime shiftTime)
        {
            int ShiftTimeID = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_ShiftTime", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@DepartmentID", shiftTime.DepartmentID);
            cmd.Parameters.AddWithValue("@StartTime", shiftTime.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", shiftTime.EndTime);

            try
            {
                conn.Open();
                ShiftTimeID = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }


            return ShiftTimeID;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2020
        /// Approver:Alex Diers
        /// 
        /// Opens DB Connection to select all shiftTimes
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>

        public List<PetUniverseShiftTime> SelectAllShiftTimes()
        {
            List<PetUniverseShiftTime> ShiftTimes = new List<PetUniverseShiftTime>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_ShiftTimes", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        var shiftTime = new PetUniverseShiftTime();
                        {
                            shiftTime.ShiftTimeID = Reader.GetInt32(0);
                            shiftTime.DepartmentID = Reader.GetString(1);
                            shiftTime.StartTime = Reader.GetString(2);
                            shiftTime.EndTime = Reader.GetString(3);

                            ShiftTimes.Add(shiftTime);
                        }
                    }
                }
                Reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ShiftTimes;
        }


        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/13/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Opens DB Connection to Update a shiftTime
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="newShiftTime"></param>
        /// <param name="oldShiftTime"></param>
        public int UpdateShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_shiftTime", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ShiftTimeID", oldShiftTime.ShiftTimeID);

            cmd.Parameters.AddWithValue("@NewDepartmentID", newShiftTime.DepartmentID);
            cmd.Parameters.AddWithValue("@NewStartTime", newShiftTime.StartTime);
            cmd.Parameters.AddWithValue("@NewEndTime", newShiftTime.EndTime);

            cmd.Parameters.AddWithValue("@OldDepartmentID", oldShiftTime.DepartmentID);
            cmd.Parameters.AddWithValue("@OldStartTime", oldShiftTime.StartTime);
            cmd.Parameters.AddWithValue("@OldEndTime", oldShiftTime.EndTime);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ApplicationException("record not found.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;

        }
    }
}

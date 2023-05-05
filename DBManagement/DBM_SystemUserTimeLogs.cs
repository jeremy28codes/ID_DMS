using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DMS.Models;


namespace DMS.DBManagement
{
    public class DBM_SystemUserTimeLogs
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<System_user_time_logs> ListAll()
        {
            List<System_user_time_logs> list = new List<System_user_time_logs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_user_time_logs_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_user_time_logs
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_user_id = Convert.ToInt32(dr["system_user_id"]),
                        log_date = dr["log_date"].ToString(),
                        log_in = dr["log_in"].ToString(),
                        log_out = dr["log_out"].ToString(),
                        created_by = dr["created_by"].ToString(),
                        created_at = Convert.ToDateTime(dr["created_at"]),
                        updated_by = dr["updated_by"].ToString(),
                        updated_at = Convert.ToDateTime(dr["updated_at"]),
                        deleted_by = dr["deleted_by"].ToString(),
                        deleted_at = Convert.ToDateTime(dr["deleted_at"]),
                    });
                }
            }

            return list;
        }

        ////GET BY ID
        //public System_User_TimeLogs GetBy_ID(int id)
        //{
        //    System_User_TimeLogs item = new System_User_TimeLogs();

        //    using (SqlConnection connection = new SqlConnection(sConnectionString))
        //    {
        //        SqlCommand command = connection.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "spSystem_User_TimeLogs_GetBy_ID";
        //        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        //        SqlDataAdapter sqlDA = new SqlDataAdapter(command);
        //        DataTable dt = new DataTable();

        //        connection.Open();
        //        sqlDA.Fill(dt);
        //        connection.Close();

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            item.id = Convert.ToInt32(dr["id"]);
        //            item.code = dr["code"].ToString();
        //            item.name = dr["name"].ToString();
        //            item.description = dr["description"].ToString();
        //            item.ctr = Convert.ToInt32(dr["ctr"]);
        //            item.created_by = dr["created_by"].ToString();
        //            item.created_at = Convert.ToDateTime(dr["created_at"]);
        //            item.updated_by = dr["updated_by"].ToString();
        //            item.updated_at = Convert.ToDateTime(dr["updated_at"]);
        //            item.deleted_by = dr["deleted_by"].ToString();
        //            item.deleted_at = Convert.ToDateTime(dr["deleted_at"]);
        //        }

        //    }

        //    return item;
        //}

        ////CREATE
        //public int Insert(System_User_TimeLogs item)
        //{
        //    int id = 0;
        //    using (SqlConnection connection = new SqlConnection(sConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("spSystem_User_TimeLogs_Insert", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
        //        command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
        //        command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
        //        command.Parameters.Add("@ctr", SqlDbType.Int).Value = item.ctr;
        //        command.Parameters.Add("@created_by", SqlDbType.VarChar).Value = item.created_by;
        //        command.Parameters.Add("@created_at", SqlDbType.DateTime).Value = item.created_at;

        //        connection.Open();
        //        id = Convert.ToInt32(command.ExecuteScalar());
        //        connection.Close();
        //    }

        //    if (id > 0)
        //    {
        //        return id;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

        ////UPDATE
        //public int Update(System_User_TimeLogs item)
        //{
        //    int id = 0;
        //    using (SqlConnection connection = new SqlConnection(sConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("spSystem_User_TimeLogs_Update", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
        //        command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
        //        command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
        //        command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
        //        command.Parameters.Add("@ctr", SqlDbType.Int).Value = item.ctr;
        //        command.Parameters.Add("@updated_by", SqlDbType.VarChar).Value = item.created_by;
        //        command.Parameters.Add("@updated_at", SqlDbType.DateTime).Value = item.created_at;

        //        connection.Open();
        //        id = Convert.ToInt32(command.ExecuteScalar());
        //        connection.Close();
        //    }

        //    if (id > 0)
        //    {
        //        return id;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

        ////DELETE
        //public int Delete(System_User_TimeLogs item)
        //{
        //    int id = 0;
        //    using (SqlConnection connection = new SqlConnection(sConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("spSystem_User_TimeLogs_Delete", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
        //        command.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = item.deleted_by;
        //        command.Parameters.Add("@deleted_at", SqlDbType.DateTime).Value = item.deleted_at;

        //        connection.Open();
        //        id = Convert.ToInt32(command.ExecuteScalar());
        //        connection.Close();
        //    }

        //    if (id > 0)
        //    {
        //        return id;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}
        #endregion

        #region Customized Functions
        public List<System_User_TimeLogs> ListBy_EmployeeName(string Employee_Name)
        {
            List<System_User_TimeLogs> list = new List<System_User_TimeLogs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_User_TimeLogs_ListBy_EmployeeName";
                command.Parameters.Add("@Employee_Name", SqlDbType.Int).Value = Employee_Name;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_User_TimeLogs
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Employee_Name = dr["Employee_Name"].ToString(),
                        Time_IN = dr["Time_IN"].ToString(),
                        Time_OUT = dr["Time_OUT"].ToString(),
                    });
                }
            }

            return list;
        }

        public List<System_user_time_logs> PrintBy_Employee(int system_user_id, string date_from, string date_to)
        {
            List<System_user_time_logs> list = new List<System_user_time_logs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_User_TimeLogs_PrintBy_Employee";
                command.Parameters.Add("@user_id", SqlDbType.Int).Value = system_user_id;
                command.Parameters.Add("@date_from", SqlDbType.VarChar).Value = date_from;
                command.Parameters.Add("@date_to", SqlDbType.VarChar).Value = date_to;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_user_time_logs
                    {
                        system_user_id = Convert.ToInt32(dr["system_user_id"]),
                        dt_day = Convert.ToInt32(dr["dt_day"]),
                        dtr_duration = dr["dtr_duration"].ToString(),
                        log_in = dr["time_in"].ToString(),
                        log_out = dr["time_out"].ToString(),
                        sAM_log_in = dr["sAM_in"].ToString(),
                        sAM_log_out = dr["sAM_out"].ToString(),
                        sPM_log_in = dr["sPM_in"].ToString(),
                        sPM_log_out = dr["sPM_out"].ToString(),
                        total_minutes_rendered = Convert.ToInt32(dr["total_minutes_rendered"]),
                        stotal_minutes_rendered = dr["stotal_minutes_rendered"].ToString(),
                        overtime = Convert.ToInt32(dr["overtime"]),
                        sovertime = dr["sovertime"].ToString(),
                        undertime = Convert.ToInt32(dr["undertime"]),
                        sundertime = dr["sundertime"].ToString(),
                        day_of_the_week = dr["day_of_the_week"].ToString(),
                        is_included = Convert.ToInt32(dr["is_included"]),
                    });
                }
            }

            return list;
        }

        //public List<System_User_TimeLogs> ListAll_EmployeeNames()
        //{
        //    List<System_User_TimeLogs> list = new List<System_User_TimeLogs>();

        //    using (SqlConnection connection = new SqlConnection(sConnectionString))
        //    {
        //        SqlCommand command = connection.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "spSystem_User_TimeLogs_ListAll_EmployeeNames";
        //        SqlDataAdapter sqlDA = new SqlDataAdapter(command);
        //        DataTable dt = new DataTable();

        //        connection.Open();
        //        sqlDA.Fill(dt);
        //        connection.Close();

        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            list.Add(new System_User_TimeLogs
        //            {
        //                ID = 0,
        //                Employee_Name = dr["Employee_Name"].ToString(),
        //                Time_IN = "",
        //                Time_OUT = "",
        //            });
        //        }
        //    }

        //    return list;
        //}

        public List<System_User_TimeLogs> ListAll_EmployeeNames()
        {
            List<System_User_TimeLogs> list = new List<System_User_TimeLogs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_User_TimeLogs_ListAll_EmployeeNames";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_User_TimeLogs
                    {
                        ID = 0,
                        Employee_Name = dr["Employee_Name"].ToString(),
                        DT = "",
                        Time_IN = "",
                        Time_OUT = "",
                    });
                }
            }

            return list;
        }
        #endregion
    }
}
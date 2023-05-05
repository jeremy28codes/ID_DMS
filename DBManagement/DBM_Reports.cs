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
    public class DBM_Reports
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<Reports> ListAll()
        {
            List<Reports> list = new List<Reports>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spReports_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Reports
                    {
                        id = Convert.ToInt32(dr["id"]),
                        reference_number = dr["reference_number"].ToString(),
                        date_received = dr["date_received"].ToString(),
                        time_received = dr["time_received"].ToString(),
                        rgv_report_type_id = Convert.ToInt32(dr["rgv_report_type_id"]),
                        rgv_report_type_code = dr["rgv_report_type_code"].ToString(),
                        rgv_report_type_name = dr["rgv_report_type_name"].ToString(),
                        rgv_report_type_description = dr["rgv_report_type_description"].ToString(),
                        rgv_report_category_id = Convert.ToInt32(dr["rgv_report_category_id"]),
                        rgv_report_category_code = dr["rgv_report_category_code"].ToString(),
                        rgv_report_category_name = dr["rgv_report_category_name"].ToString(),
                        rgv_report_category_description = dr["rgv_report_category_description"].ToString(),
                        started_at = dr["started_at"].ToString(),
                        completed_at = dr["completed_at"].ToString(),
                        description_of_incident = dr["description_of_incident"].ToString(),
                        is_spoofed_email = Convert.ToInt32(dr["is_spoofed_email"]),
                        is_similar_domain = Convert.ToInt32(dr["is_similar_domain"]),
                        is_email_intrusion = Convert.ToInt32(dr["is_email_intrusion"]),
                        is_others = Convert.ToInt32(dr["is_others"]),
                        others = dr["others"].ToString(),
                        digital_signature = dr["digital_signature"].ToString(),
                        created_by = dr["created_by"].ToString(),
                        created_at = Convert.ToDateTime(dr["created_at"]),
                        updated_by = dr["updated_by"].ToString(),
                        updated_at = Convert.ToDateTime(dr["updated_at"]),
                        deleted_by = dr["deleted_by"].ToString(),
                        deleted_at = Convert.ToDateTime(dr["deleted_at"]),
                        remarks = dr["remarks"].ToString(),
                    });
                }
            }

            return list;
        }

        //GET BY ID
        public Reports GetBy_ID(int id)
        {
            Reports item = new Reports();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spReports_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.reference_number = dr["reference_number"].ToString();
                    item.date_received = dr["date_received"].ToString();
                    item.time_received = dr["time_received"].ToString();
                    item.rgv_report_type_id = Convert.ToInt32(dr["rgv_report_type_id"]);
                    item.rgv_report_type_code = dr["rgv_report_type_code"].ToString();
                    item.rgv_report_type_name = dr["rgv_report_type_name"].ToString();
                    item.rgv_report_type_description = dr["rgv_report_type_description"].ToString();
                    item.rgv_report_category_id = Convert.ToInt32(dr["rgv_report_category_id"]);
                    item.rgv_report_category_code = dr["rgv_report_category_code"].ToString();
                    item.rgv_report_category_name = dr["rgv_report_category_name"].ToString();
                    item.rgv_report_category_description = dr["rgv_report_category_description"].ToString();
                    item.started_at = dr["started_at"].ToString();
                    item.completed_at = dr["completed_at"].ToString();
                    item.description_of_incident = dr["description_of_incident"].ToString();
                    item.is_spoofed_email = Convert.ToInt32(dr["is_spoofed_email"]);
                    item.is_similar_domain = Convert.ToInt32(dr["is_similar_domain"]);
                    item.is_email_intrusion = Convert.ToInt32(dr["is_email_intrusion"]);
                    item.is_others = Convert.ToInt32(dr["is_others"]);
                    item.others = dr["others"].ToString();
                    item.digital_signature = dr["digital_signature"].ToString();
                    item.created_by = dr["created_by"].ToString();
                    item.created_at = Convert.ToDateTime(dr["created_at"]);
                    item.updated_by = dr["updated_by"].ToString();
                    item.updated_at = Convert.ToDateTime(dr["updated_at"]);
                    item.deleted_by = dr["deleted_by"].ToString();
                    item.deleted_at = Convert.ToDateTime(dr["deleted_at"]);
                    item.remarks = dr["remarks"].ToString();
                }

            }

            return item;
        }

        //CREATE
        public int Insert(Reports item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spReports_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@reference_number", SqlDbType.VarChar).Value = item.reference_number;
                command.Parameters.Add("@date_received", SqlDbType.VarChar).Value = item.date_received;
                command.Parameters.Add("@time_received", SqlDbType.VarChar).Value = item.time_received;
                command.Parameters.Add("@rgv_report_type_id", SqlDbType.Int).Value = item.rgv_report_type_id;
                command.Parameters.Add("@rgv_report_category_id", SqlDbType.Int).Value = item.rgv_report_category_id;
                command.Parameters.Add("@started_at", SqlDbType.VarChar).Value = item.started_at;
                command.Parameters.Add("@completed_at", SqlDbType.VarChar).Value = item.completed_at;
                command.Parameters.Add("@description_of_incident", SqlDbType.NVarChar).Value = item.description_of_incident;
                command.Parameters.Add("@is_spoofed_email", SqlDbType.Int).Value = item.is_spoofed_email;
                command.Parameters.Add("@is_similar_domain", SqlDbType.Int).Value = item.is_similar_domain;
                command.Parameters.Add("@is_email_intrusion", SqlDbType.Int).Value = item.is_email_intrusion;
                command.Parameters.Add("@is_others", SqlDbType.Int).Value = item.is_others;
                command.Parameters.Add("@others", SqlDbType.VarChar).Value = item.others;
                command.Parameters.Add("@digital_signature", SqlDbType.VarChar).Value = item.digital_signature;
                command.Parameters.Add("@created_by", SqlDbType.VarChar).Value = item.created_by;
                command.Parameters.Add("@created_at", SqlDbType.DateTime).Value = item.created_at;
                command.Parameters.Add("@remarks", SqlDbType.NVarChar).Value = item.remarks;

                connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }

            if (id > 0)
            {
                return id;
            }
            else
            {
                return 0;
            }

        }

        //UPDATE
        public int Update(Reports item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spReports_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@reference_number", SqlDbType.VarChar).Value = item.reference_number;
                command.Parameters.Add("@date_received", SqlDbType.VarChar).Value = item.date_received;
                command.Parameters.Add("@time_received", SqlDbType.VarChar).Value = item.time_received;
                command.Parameters.Add("@rgv_report_type_id", SqlDbType.Int).Value = item.rgv_report_type_id;
                command.Parameters.Add("@rgv_report_category_id", SqlDbType.Int).Value = item.rgv_report_category_id;
                command.Parameters.Add("@started_at", SqlDbType.VarChar).Value = item.started_at;
                command.Parameters.Add("@completed_at", SqlDbType.VarChar).Value = item.completed_at;
                command.Parameters.Add("@description_of_incident", SqlDbType.NVarChar).Value = item.description_of_incident;
                command.Parameters.Add("@is_spoofed_email", SqlDbType.Int).Value = item.is_spoofed_email;
                command.Parameters.Add("@is_similar_domain", SqlDbType.Int).Value = item.is_similar_domain;
                command.Parameters.Add("@is_email_intrusion", SqlDbType.Int).Value = item.is_email_intrusion;
                command.Parameters.Add("@is_others", SqlDbType.Int).Value = item.is_others;
                command.Parameters.Add("@others", SqlDbType.VarChar).Value = item.others;
                command.Parameters.Add("@digital_signature", SqlDbType.VarChar).Value = item.digital_signature;
                command.Parameters.Add("@updated_by", SqlDbType.VarChar).Value = item.updated_by;
                command.Parameters.Add("@updated_at", SqlDbType.DateTime).Value = item.updated_at;
                command.Parameters.Add("@remarks", SqlDbType.NVarChar).Value = item.remarks;

                connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }

            if (id > 0)
            {
                return id;
            }
            else
            {
                return 0;
            }

        }

        //DELETE
        public int Delete(Reports item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spReports_Delete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = item.deleted_by;
                command.Parameters.Add("@deleted_at", SqlDbType.DateTime).Value = item.deleted_at;

                connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }

            if (id > 0)
            {
                return id;
            }
            else
            {
                return 0;
            }

        }
        #endregion

        #region Customized Functions
        
        public Reports GenerateReferenceNumber(int system_division_id, int rgv_report_type_id)
        {
            Reports item = new Reports();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spReport_GenerateReferenceNumber";
                command.Parameters.Add("@system_division_id", SqlDbType.Int).Value = system_division_id;
                command.Parameters.Add("@rgv_report_type_id", SqlDbType.Int).Value = rgv_report_type_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.reference_number = dr["reference_number"].ToString();
                }

            }

            return item;
        }

        public int Insert_ReferenceNumber(Report_reference_numbers item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spReport_reference_numbers_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = item.report_id;
                command.Parameters.Add("@rgv_report_type_id", SqlDbType.Int).Value = item.rgv_report_type_id;
                command.Parameters.Add("@system_division_id", SqlDbType.Int).Value = item.system_division_id;
                command.Parameters.Add("@created_by", SqlDbType.VarChar).Value = item.created_by;
                command.Parameters.Add("@created_at", SqlDbType.DateTime).Value = item.created_at;

                connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }

            if (id > 0)
            {
                return id;
            }
            else
            {
                return 0;
            }

        }

        #endregion
    }
}
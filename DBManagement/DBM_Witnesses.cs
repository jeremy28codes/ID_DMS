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
    public class DBM_Witnesses
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<Witnesses> ListAll()
        {
            List<Witnesses> list = new List<Witnesses>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spWitnesses_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Witnesses
                    {
                        id = Convert.ToInt32(dr["id"]),
                        report_id = Convert.ToInt32(dr["report_id"]),
                        full_name = dr["full_name"].ToString(),
                        rgv_age_bracket_id = Convert.ToInt32(dr["rgv_age_bracket_id"]),
                        rgv_age_bracket_code = dr["rgv_age_bracket_code"].ToString(),
                        rgv_age_bracket_name = dr["rgv_age_bracket_name"].ToString(),
                        rgv_age_bracket_description = dr["rgv_age_bracket_description"].ToString(),
                        rgv_marital_status_id = Convert.ToInt32(dr["rgv_marital_status_id"]),
                        rgv_marital_status_code = dr["rgv_marital_status_code"].ToString(),
                        rgv_marital_status_name = dr["rgv_marital_status_name"].ToString(),
                        rgv_marital_status_description = dr["rgv_marital_status_description"].ToString(),
                        email = dr["email"].ToString(),
                        mobile_number = dr["mobile_number"].ToString(),
                        full_address = dr["full_address"].ToString(),
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
        public Witnesses GetBy_ID(int id)
        {
            Witnesses item = new Witnesses();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spWitnesses_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.report_id = Convert.ToInt32(dr["report_id"]);
                    item.full_name = dr["full_name"].ToString();
                    item.rgv_age_bracket_id = Convert.ToInt32(dr["rgv_age_bracket_id"]);
                    item.rgv_age_bracket_code = dr["rgv_age_bracket_code"].ToString();
                    item.rgv_age_bracket_name = dr["rgv_age_bracket_name"].ToString();
                    item.rgv_age_bracket_description = dr["rgv_age_bracket_description"].ToString();
                    item.rgv_marital_status_id = Convert.ToInt32(dr["rgv_marital_status_id"]);
                    item.rgv_marital_status_code = dr["rgv_marital_status_code"].ToString();
                    item.rgv_marital_status_name = dr["rgv_marital_status_name"].ToString();
                    item.rgv_marital_status_description = dr["rgv_marital_status_description"].ToString();
                    item.email = dr["email"].ToString();
                    item.mobile_number = dr["mobile_number"].ToString();
                    item.full_address = dr["full_address"].ToString();
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
        public int Insert(Witnesses item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spWitnesses_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = item.report_id;
                command.Parameters.Add("@full_name", SqlDbType.VarChar).Value = item.full_name;
                command.Parameters.Add("@rgv_age_bracket_id", SqlDbType.Int).Value = item.rgv_age_bracket_id;
                command.Parameters.Add("@rgv_marital_status_id", SqlDbType.Int).Value = item.rgv_marital_status_id;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@full_address", SqlDbType.NVarChar).Value = item.full_address;
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
        public int Update(Witnesses item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spWitnesses_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = item.report_id;
                command.Parameters.Add("@full_name", SqlDbType.VarChar).Value = item.full_name;
                command.Parameters.Add("@rgv_age_bracket_id", SqlDbType.Int).Value = item.rgv_age_bracket_id;
                command.Parameters.Add("@rgv_marital_status_id", SqlDbType.Int).Value = item.rgv_marital_status_id;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@full_address", SqlDbType.NVarChar).Value = item.full_address;
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
        public int Delete(Witnesses item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spWitnesses_Delete", connection);
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
        //GET BY ID
        public Witnesses GetBy_ReportID(int report_id)
        {
            Witnesses item = new Witnesses();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spWitnesses_GetBy_ReportID";
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = report_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.report_id = Convert.ToInt32(dr["report_id"]);
                    item.full_name = dr["full_name"].ToString();
                    item.rgv_age_bracket_id = Convert.ToInt32(dr["rgv_age_bracket_id"]);
                    item.rgv_age_bracket_code = dr["rgv_age_bracket_code"].ToString();
                    item.rgv_age_bracket_name = dr["rgv_age_bracket_name"].ToString();
                    item.rgv_age_bracket_description = dr["rgv_age_bracket_description"].ToString();
                    item.rgv_marital_status_id = Convert.ToInt32(dr["rgv_marital_status_id"]);
                    item.rgv_marital_status_code = dr["rgv_marital_status_code"].ToString();
                    item.rgv_marital_status_name = dr["rgv_marital_status_name"].ToString();
                    item.rgv_marital_status_description = dr["rgv_marital_status_description"].ToString();
                    item.email = dr["email"].ToString();
                    item.mobile_number = dr["mobile_number"].ToString();
                    item.full_address = dr["full_address"].ToString();
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
        #endregion
    }
}
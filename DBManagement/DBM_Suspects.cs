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
    public class DBM_Suspects
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<Suspects> ListAll()
        {
            List<Suspects> list = new List<Suspects>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSuspects_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Suspects
                    {
                        id = Convert.ToInt32(dr["id"]),
                        report_id = Convert.ToInt32(dr["report_id"]),
                        full_name = dr["full_name"].ToString(),
                        business_name = dr["business_name"].ToString(),
                        email = dr["email"].ToString(),
                        mobile_number = dr["mobile_number"].ToString(),
                        address1 = dr["address1"].ToString(),
                        address2 = dr["address2"].ToString(),
                        country_id = Convert.ToInt32(dr["country_id"]),
                        country_code = dr["country_code"].ToString(),
                        country_name = dr["country_name"].ToString(),
                        country_description = dr["country_description"].ToString(),
                        province_id = Convert.ToInt32(dr["province_id"]),
                        province_code = dr["province_code"].ToString(),
                        province_name = dr["province_name"].ToString(),
                        province_description = dr["province_description"].ToString(),
                        city_id = Convert.ToInt32(dr["city_id"]),
                        city_code = dr["city_code"].ToString(),
                        city_name = dr["city_name"].ToString(),
                        city_description = dr["city_description"].ToString(),
                        zip_code = dr["zip_code"].ToString(),
                        website_link = dr["website_link"].ToString(),
                        ip_address = dr["ip_address"].ToString(),
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
        public Suspects GetBy_ID(int id)
        {
            Suspects item = new Suspects();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSuspects_GetBy_ID";
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
                    item.business_name = dr["business_name"].ToString();
                    item.email = dr["email"].ToString();
                    item.mobile_number = dr["mobile_number"].ToString();
                    item.address1 = dr["address1"].ToString();
                    item.address2 = dr["address2"].ToString();
                    item.country_id = Convert.ToInt32(dr["country_id"]);
                    item.country_code = dr["country_code"].ToString();
                    item.country_name = dr["country_name"].ToString();
                    item.country_description = dr["country_description"].ToString();
                    item.province_id = Convert.ToInt32(dr["province_id"]);
                    item.province_code = dr["province_code"].ToString();
                    item.province_name = dr["province_name"].ToString();
                    item.province_description = dr["province_description"].ToString();
                    item.city_id = Convert.ToInt32(dr["city_id"]);
                    item.city_code = dr["city_code"].ToString();
                    item.city_name = dr["city_name"].ToString();
                    item.city_description = dr["city_description"].ToString();
                    item.zip_code = dr["zip_code"].ToString();
                    item.website_link = dr["website_link"].ToString();
                    item.ip_address = dr["ip_address"].ToString();
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
        public int Insert(Suspects item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSuspects_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = item.report_id;
                command.Parameters.Add("@full_name", SqlDbType.VarChar).Value = item.full_name;
                command.Parameters.Add("@business_name", SqlDbType.NVarChar).Value = item.business_name;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@address1", SqlDbType.NVarChar).Value = item.address1;
                command.Parameters.Add("@address2", SqlDbType.NVarChar).Value = item.address2;
                command.Parameters.Add("@country_id", SqlDbType.Int).Value = item.country_id;
                command.Parameters.Add("@province_id", SqlDbType.Int).Value = item.province_id;
                command.Parameters.Add("@city_id", SqlDbType.Int).Value = item.city_id;
                command.Parameters.Add("@zip_code", SqlDbType.VarChar).Value = item.zip_code;
                command.Parameters.Add("@website_link", SqlDbType.VarChar).Value = item.website_link;
                command.Parameters.Add("@ip_address", SqlDbType.VarChar).Value = item.ip_address;
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
        public int Update(Suspects item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSuspects_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = item.report_id;
                command.Parameters.Add("@full_name", SqlDbType.VarChar).Value = item.full_name;
                command.Parameters.Add("@business_name", SqlDbType.NVarChar).Value = item.business_name;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@address1", SqlDbType.NVarChar).Value = item.address1;
                command.Parameters.Add("@address2", SqlDbType.NVarChar).Value = item.address2;
                command.Parameters.Add("@country_id", SqlDbType.Int).Value = item.country_id;
                command.Parameters.Add("@province_id", SqlDbType.Int).Value = item.province_id;
                command.Parameters.Add("@city_id", SqlDbType.Int).Value = item.city_id;
                command.Parameters.Add("@zip_code", SqlDbType.VarChar).Value = item.zip_code;
                command.Parameters.Add("@website_link", SqlDbType.VarChar).Value = item.website_link;
                command.Parameters.Add("@ip_address", SqlDbType.VarChar).Value = item.ip_address;
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
        public int Delete(Suspects item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSuspects_Delete", connection);
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
        public List<Suspects> ListBy_ReportID(int report_id)
        {
            List<Suspects> list = new List<Suspects>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSuspects_ListBy_ReportID";
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = report_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Suspects
                    {
                        id = Convert.ToInt32(dr["id"]),
                        report_id = Convert.ToInt32(dr["report_id"]),
                        full_name = dr["full_name"].ToString(),
                        business_name = dr["business_name"].ToString(),
                        email = dr["email"].ToString(),
                        mobile_number = dr["mobile_number"].ToString(),
                        address1 = dr["address1"].ToString(),
                        address2 = dr["address2"].ToString(),
                        country_id = Convert.ToInt32(dr["country_id"]),
                        country_code = dr["country_code"].ToString(),
                        country_name = dr["country_name"].ToString(),
                        country_description = dr["country_description"].ToString(),
                        province_id = Convert.ToInt32(dr["province_id"]),
                        province_code = dr["province_code"].ToString(),
                        province_name = dr["province_name"].ToString(),
                        province_description = dr["province_description"].ToString(),
                        city_id = Convert.ToInt32(dr["city_id"]),
                        city_code = dr["city_code"].ToString(),
                        city_name = dr["city_name"].ToString(),
                        city_description = dr["city_description"].ToString(),
                        zip_code = dr["zip_code"].ToString(),
                        website_link = dr["website_link"].ToString(),
                        ip_address = dr["ip_address"].ToString(),
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
        #endregion
    }
}
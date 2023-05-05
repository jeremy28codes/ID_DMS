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
    public class DBM_Victims
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<Victims> ListAll()
        {
            List<Victims> list = new List<Victims>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spVictims_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Victims
                    {
                        id = Convert.ToInt32(dr["id"]),
                        report_id = Convert.ToInt32(dr["report_id"]),
                        last_name = dr["last_name"].ToString(),
                        first_name = dr["first_name"].ToString(),
                        middle_name = dr["middle_name"].ToString(),
                        is_in_behalf_of_business = Convert.ToInt32(dr["is_in_behalf_of_business"]),
                        business_name = dr["business_name"].ToString(),
                        is_impacting_business_operations = Convert.ToInt32(dr["is_impacting_business_operations"]),
                        rgv_age_bracket_id = Convert.ToInt32(dr["rgv_age_bracket_id"]),
                        rgv_age_bracket_code = dr["rgv_age_bracket_code"].ToString(),
                        rgv_age_bracket_name = dr["rgv_age_bracket_name"].ToString(),
                        rgv_age_bracket_description = dr["rgv_age_bracket_description"].ToString(),
                        rgv_marital_status_id = Convert.ToInt32(dr["rgv_marital_status_id"]),
                        rgv_marital_status_code = dr["rgv_marital_status_code"].ToString(),
                        rgv_marital_status_name = dr["rgv_marital_status_name"].ToString(),
                        rgv_marital_status_description = dr["rgv_marital_status_description"].ToString(),
                        rgv_sex_id = Convert.ToInt32(dr["rgv_sex_id"]),
                        rgv_sex_code = dr["rgv_sex_code"].ToString(),
                        rgv_sex_name = dr["rgv_sex_name"].ToString(),
                        rgv_sex_description = dr["rgv_sex_description"].ToString(),
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
                        business_it_poc = dr["business_it_poc"].ToString(),
                        other_busines_poc = dr["other_busines_poc"].ToString(),
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
        public Victims GetBy_ID(int id)
        {
            Victims item = new Victims();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spVictims_GetBy_ID";
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
                    item.last_name = dr["last_name"].ToString();
                    item.first_name = dr["first_name"].ToString();
                    item.middle_name = dr["middle_name"].ToString();
                    item.is_in_behalf_of_business = Convert.ToInt32(dr["is_in_behalf_of_business"]);
                    item.business_name = dr["business_name"].ToString();
                    item.is_impacting_business_operations = Convert.ToInt32(dr["is_impacting_business_operations"]);
                    item.rgv_age_bracket_id = Convert.ToInt32(dr["rgv_age_bracket_id"]);
                    item.rgv_age_bracket_code = dr["rgv_age_bracket_code"].ToString();
                    item.rgv_age_bracket_name = dr["rgv_age_bracket_name"].ToString();
                    item.rgv_age_bracket_description = dr["rgv_age_bracket_description"].ToString();
                    item.rgv_marital_status_id = Convert.ToInt32(dr["rgv_marital_status_id"]);
                    item.rgv_marital_status_code = dr["rgv_marital_status_code"].ToString();
                    item.rgv_marital_status_name = dr["rgv_marital_status_name"].ToString();
                    item.rgv_marital_status_description = dr["rgv_marital_status_description"].ToString();
                    item.rgv_sex_id = Convert.ToInt32(dr["rgv_sex_id"]);
                    item.rgv_sex_code = dr["rgv_sex_code"].ToString();
                    item.rgv_sex_name = dr["rgv_sex_name"].ToString();
                    item.rgv_sex_description = dr["rgv_sex_description"].ToString();
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
                    item.business_it_poc = dr["business_it_poc"].ToString();
                    item.other_busines_poc = dr["other_busines_poc"].ToString();
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
        public int Insert(Victims item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spVictims_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = item.report_id;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = item.last_name;
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = item.first_name;
                command.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = item.middle_name;
                command.Parameters.Add("@is_in_behalf_of_business", SqlDbType.Int).Value = item.is_in_behalf_of_business;
                command.Parameters.Add("@business_name", SqlDbType.VarChar).Value = item.business_name;
                command.Parameters.Add("@is_impacting_business_operations", SqlDbType.Int).Value = item.is_impacting_business_operations;
                command.Parameters.Add("@rgv_age_bracket_id", SqlDbType.Int).Value = item.rgv_age_bracket_id;
                command.Parameters.Add("@rgv_marital_status_id", SqlDbType.Int).Value = item.rgv_marital_status_id;
                command.Parameters.Add("@rgv_sex_id", SqlDbType.Int).Value = item.rgv_sex_id;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@address1", SqlDbType.NVarChar).Value = item.address1;
                command.Parameters.Add("@address2", SqlDbType.NVarChar).Value = item.address2;
                command.Parameters.Add("@country_id", SqlDbType.Int).Value = item.country_id;
                command.Parameters.Add("@province_id", SqlDbType.Int).Value = item.province_id;
                command.Parameters.Add("@city_id", SqlDbType.Int).Value = item.city_id;
                command.Parameters.Add("@business_it_poc", SqlDbType.VarChar).Value = item.business_it_poc;
                command.Parameters.Add("@other_busines_poc", SqlDbType.VarChar).Value = item.other_busines_poc;
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
        public int Update(Victims item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spVictims_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@report_id", SqlDbType.Int).Value = item.report_id;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = item.last_name;
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = item.first_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = item.last_name;
                command.Parameters.Add("@is_in_behalf_of_business", SqlDbType.Int).Value = item.is_in_behalf_of_business;
                command.Parameters.Add("@business_name", SqlDbType.VarChar).Value = item.business_name;
                command.Parameters.Add("@is_impacting_business_operations", SqlDbType.Int).Value = item.is_impacting_business_operations;
                command.Parameters.Add("@rgv_age_bracket_id", SqlDbType.Int).Value = item.rgv_age_bracket_id;
                command.Parameters.Add("@rgv_marital_status_id", SqlDbType.Int).Value = item.rgv_marital_status_id;
                command.Parameters.Add("@rgv_sex_id", SqlDbType.Int).Value = item.rgv_sex_id;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@address1", SqlDbType.NVarChar).Value = item.address1;
                command.Parameters.Add("@address2", SqlDbType.NVarChar).Value = item.address2;
                command.Parameters.Add("@country_id", SqlDbType.Int).Value = item.country_id;
                command.Parameters.Add("@province_id", SqlDbType.Int).Value = item.province_id;
                command.Parameters.Add("@city_id", SqlDbType.Int).Value = item.city_id;
                command.Parameters.Add("@business_it_poc", SqlDbType.VarChar).Value = item.business_it_poc;
                command.Parameters.Add("@other_busines_poc", SqlDbType.VarChar).Value = item.other_busines_poc;
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
        public int Delete(Victims item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spVictims_Delete", connection);
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
        public Victims GetBy_ReportID(int report_id)
        {
            Victims item = new Victims();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spVictims_GetBy_ReportID";
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
                    item.last_name = dr["last_name"].ToString();
                    item.first_name = dr["first_name"].ToString();
                    item.middle_name = dr["middle_name"].ToString();
                    item.is_in_behalf_of_business = Convert.ToInt32(dr["is_in_behalf_of_business"]);
                    item.business_name = dr["business_name"].ToString();
                    item.is_impacting_business_operations = Convert.ToInt32(dr["is_impacting_business_operations"]);
                    item.rgv_age_bracket_id = Convert.ToInt32(dr["rgv_age_bracket_id"]);
                    item.rgv_age_bracket_code = dr["rgv_age_bracket_code"].ToString();
                    item.rgv_age_bracket_name = dr["rgv_age_bracket_name"].ToString();
                    item.rgv_age_bracket_description = dr["rgv_age_bracket_description"].ToString();
                    item.rgv_marital_status_id = Convert.ToInt32(dr["rgv_marital_status_id"]);
                    item.rgv_marital_status_code = dr["rgv_marital_status_code"].ToString();
                    item.rgv_marital_status_name = dr["rgv_marital_status_name"].ToString();
                    item.rgv_marital_status_description = dr["rgv_marital_status_description"].ToString();
                    item.rgv_sex_id = Convert.ToInt32(dr["rgv_sex_id"]);
                    item.rgv_sex_code = dr["rgv_sex_code"].ToString();
                    item.rgv_sex_name = dr["rgv_sex_name"].ToString();
                    item.rgv_sex_description = dr["rgv_sex_description"].ToString();
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
                    item.business_it_poc = dr["business_it_poc"].ToString();
                    item.other_busines_poc = dr["other_busines_poc"].ToString();
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
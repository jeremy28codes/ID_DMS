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
    public class DBM_VictimFinancialTransactions
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions

        //GET ALL
        public List<Victim_financial_transactions> ListAll()
        {
            List<Victim_financial_transactions> list = new List<Victim_financial_transactions>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spVictim_financial_transactions_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Victim_financial_transactions
                    {
                        id = Convert.ToInt32(dr["id"]),
                        victim_id = Convert.ToInt32(dr["victim_id"]),
                        transaction_date = dr["transaction_date"].ToString(),
                        rgv_transaction_type_id = Convert.ToInt32(dr["rgv_transaction_type_id"]),
                        is_others = Convert.ToInt32(dr["is_others"]),
                        others = dr["others"].ToString(),
                        amount = Convert.ToDouble(dr["amount"]),
                        is_sent = Convert.ToInt32(dr["is_sent"]),
                        victim_bank_name = dr["victim_bank_name"].ToString(),
                        victim_bank_address1 = dr["victim_bank_address1"].ToString(),
                        victim_bank_address2 = dr["victim_bank_address2"].ToString(),
                        victim_bank_country_id = Convert.ToInt32(dr["victim_bank_country_id"]),
                        victim_bank_country_code = dr["victim_bank_country_code"].ToString(),
                        victim_bank_country_name = dr["victim_bank_country_name"].ToString(),
                        victim_bank_country_description = dr["victim_bank_country_description"].ToString(),
                        victim_bank_province_id = Convert.ToInt32(dr["victim_bank_province_id"]),
                        victim_bank_province_code = dr["victim_bank_province_code"].ToString(),
                        victim_bank_province_name = dr["victim_bank_province_name"].ToString(),
                        victim_bank_province_description = dr["victim_bank_province_description"].ToString(),
                        victim_bank_city_id = Convert.ToInt32(dr["victim_bank_city_id"]),
                        victim_bank_city_code = dr["victim_bank_city_code"].ToString(),
                        victim_bank_city_name = dr["victim_bank_city_name"].ToString(),
                        victim_bank_city_description = dr["victim_bank_city_description"].ToString(),
                        victim_bank_zip_code = dr["victim_bank_zip_code"].ToString(),
                        victim_account_name = dr["victim_account_name"].ToString(),
                        victim_account_number = dr["victim_account_number"].ToString(),
                        receipient_bank_name = dr["receipient_bank_name"].ToString(),
                        receipient_bank_address1 = dr["receipient_bank_address1"].ToString(),
                        receipient_bank_address2 = dr["receipient_bank_address2"].ToString(),
                        receipient_bank_country_id = Convert.ToInt32(dr["receipient_bank_country_id"]),
                        receipient_bank_country_code = dr["receipient_bank_country_code"].ToString(),
                        receipient_bank_country_name = dr["receipient_bank_country_name"].ToString(),
                        receipient_bank_country_description = dr["receipient_bank_country_description"].ToString(),
                        receipient_bank_province_id = Convert.ToInt32(dr["receipient_bank_province_id"]),
                        receipient_bank_province_code = dr["receipient_bank_province_code"].ToString(),
                        receipient_bank_province_name = dr["receipient_bank_province_name"].ToString(),
                        receipient_bank_province_description = dr["receipient_bank_province_description"].ToString(),
                        receipient_bank_city_id = Convert.ToInt32(dr["receipient_bank_city_id"]),
                        receipient_bank_city_code = dr["receipient_bank_city_code"].ToString(),
                        receipient_bank_city_name = dr["receipient_bank_city_name"].ToString(),
                        receipient_bank_city_description = dr["receipient_bank_city_description"].ToString(),
                        receipient_bank_zip_code = dr["receipient_bank_zip_code"].ToString(),
                        receipient_account_name = dr["receipient_account_name"].ToString(),
                        receipient_account_number = dr["receipient_account_number"].ToString(),
                        receipient_bank_swift_code = dr["receipient_bank_swift_code"].ToString(),
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
        public Victim_financial_transactions GetBy_ID(int id)
        {
            Victim_financial_transactions item = new Victim_financial_transactions();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spVictim_financial_transactions_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.victim_id = Convert.ToInt32(dr["victim_id"]);
                    item.transaction_date = dr["transaction_date"].ToString();
                    item.rgv_transaction_type_id = Convert.ToInt32(dr["rgv_transaction_type_id"]);
                    item.is_others = Convert.ToInt32(dr["is_others"]);
                    item.others = dr["others"].ToString();
                    item.amount = Convert.ToDouble(dr["amount"]);
                    item.is_sent = Convert.ToInt32(dr["is_sent"]);
                    item.victim_bank_name = dr["victim_bank_name"].ToString();
                    item.victim_bank_address1 = dr["victim_bank_address1"].ToString();
                    item.victim_bank_address2 = dr["victim_bank_address2"].ToString();
                    item.victim_bank_country_id = Convert.ToInt32(dr["victim_bank_country_id"]);
                    item.victim_bank_province_id = Convert.ToInt32(dr["victim_bank_province_id"]);
                    item.victim_bank_city_id = Convert.ToInt32(dr["victim_bank_city_id"]);
                    item.victim_bank_zip_code = dr["victim_bank_zip_code"].ToString();
                    item.victim_account_name = dr["victim_account_name"].ToString();
                    item.victim_account_number = dr["victim_account_number"].ToString();
                    item.receipient_bank_name = dr["receipient_bank_name"].ToString();
                    item.receipient_bank_address1 = dr["receipient_bank_address1"].ToString();
                    item.receipient_bank_address2 = dr["receipient_bank_address2"].ToString();
                    item.receipient_bank_country_id = Convert.ToInt32(dr["receipient_bank_country_id"]);
                    item.receipient_bank_province_id = Convert.ToInt32(dr["receipient_bank_province_id"]);
                    item.receipient_bank_city_id = Convert.ToInt32(dr["receipient_bank_city_id"]);
                    item.receipient_bank_zip_code = dr["receipient_bank_zip_code"].ToString();
                    item.receipient_account_name = dr["receipient_account_name"].ToString();
                    item.receipient_account_number = dr["receipient_account_number"].ToString();
                    item.receipient_bank_swift_code = dr["receipient_bank_swift_code"].ToString();
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
        public int Insert(Victim_financial_transactions item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spVictim_financial_transactions_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@victim_id", SqlDbType.Int).Value = item.victim_id;
                command.Parameters.Add("@transaction_date", SqlDbType.VarChar).Value = item.transaction_date;
                command.Parameters.Add("@rgv_transaction_type_id", SqlDbType.Int).Value = item.rgv_transaction_type_id;
                command.Parameters.Add("@is_others", SqlDbType.Int).Value = item.is_others;
                command.Parameters.Add("@others", SqlDbType.NVarChar).Value = item.others;
                command.Parameters.Add("@amount", SqlDbType.Money).Value = item.amount;
                command.Parameters.Add("@is_sent", SqlDbType.Int).Value = item.is_sent;
                command.Parameters.Add("@victim_bank_name", SqlDbType.VarChar).Value = item.victim_bank_name;
                command.Parameters.Add("@victim_bank_address1", SqlDbType.NVarChar).Value = item.victim_bank_address1;
                command.Parameters.Add("@victim_bank_address2", SqlDbType.NVarChar).Value = item.victim_bank_address2;
                command.Parameters.Add("@victim_bank_country_id", SqlDbType.Int).Value = item.victim_bank_country_id;
                command.Parameters.Add("@victim_bank_province_id", SqlDbType.Int).Value = item.victim_bank_province_id;
                command.Parameters.Add("@victim_bank_city_id", SqlDbType.Int).Value = item.victim_bank_city_id;
                command.Parameters.Add("@victim_bank_zip_code", SqlDbType.VarChar).Value = item.victim_bank_zip_code;
                command.Parameters.Add("@victim_account_name", SqlDbType.VarChar).Value = item.victim_account_name;
                command.Parameters.Add("@victim_account_number", SqlDbType.VarChar).Value = item.victim_account_number;
                command.Parameters.Add("@receipient_bank_name", SqlDbType.VarChar).Value = item.receipient_bank_name;
                command.Parameters.Add("@receipient_bank_address1", SqlDbType.NVarChar).Value = item.receipient_bank_address1;
                command.Parameters.Add("@receipient_bank_address2", SqlDbType.NVarChar).Value = item.receipient_bank_address2;
                command.Parameters.Add("@receipient_bank_country_id", SqlDbType.Int).Value = item.receipient_bank_country_id;
                command.Parameters.Add("@receipient_bank_province_id", SqlDbType.Int).Value = item.receipient_bank_province_id;
                command.Parameters.Add("@receipient_bank_city_id", SqlDbType.Int).Value = item.receipient_bank_city_id;
                command.Parameters.Add("@receipient_bank_zip_code", SqlDbType.VarChar).Value = item.receipient_bank_zip_code;
                command.Parameters.Add("@receipient_account_name", SqlDbType.VarChar).Value = item.receipient_account_name;
                command.Parameters.Add("@receipient_account_number", SqlDbType.VarChar).Value = item.receipient_account_number;
                command.Parameters.Add("@receipient_bank_swift_code", SqlDbType.VarChar).Value = item.receipient_bank_swift_code;
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
        public int Update(Victim_financial_transactions item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spVictim_financial_transactions_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@victim_id", SqlDbType.Int).Value = item.victim_id;
                command.Parameters.Add("@transaction_date", SqlDbType.VarChar).Value = item.transaction_date;
                command.Parameters.Add("@rgv_transaction_type_id", SqlDbType.Int).Value = item.rgv_transaction_type_id;
                command.Parameters.Add("@is_others", SqlDbType.Int).Value = item.is_others;
                command.Parameters.Add("@others", SqlDbType.NVarChar).Value = item.others;
                command.Parameters.Add("@amount", SqlDbType.Money).Value = item.amount;
                command.Parameters.Add("@is_sent", SqlDbType.Int).Value = item.is_sent;
                command.Parameters.Add("@victim_bank_name", SqlDbType.VarChar).Value = item.victim_bank_name;
                command.Parameters.Add("@victim_bank_address1", SqlDbType.NVarChar).Value = item.victim_bank_address1;
                command.Parameters.Add("@victim_bank_address2", SqlDbType.NVarChar).Value = item.victim_bank_address2;
                command.Parameters.Add("@victim_bank_country_id", SqlDbType.Int).Value = item.victim_bank_country_id;
                command.Parameters.Add("@victim_bank_province_id", SqlDbType.Int).Value = item.victim_bank_province_id;
                command.Parameters.Add("@victim_bank_city_id", SqlDbType.Int).Value = item.victim_bank_city_id;
                command.Parameters.Add("@victim_bank_zip_code", SqlDbType.VarChar).Value = item.victim_bank_zip_code;
                command.Parameters.Add("@victim_account_name", SqlDbType.VarChar).Value = item.victim_account_name;
                command.Parameters.Add("@victim_account_number", SqlDbType.VarChar).Value = item.victim_account_number;
                command.Parameters.Add("@receipient_bank_name", SqlDbType.VarChar).Value = item.receipient_bank_name;
                command.Parameters.Add("@receipient_bank_address1", SqlDbType.NVarChar).Value = item.receipient_bank_address1;
                command.Parameters.Add("@receipient_bank_address2", SqlDbType.NVarChar).Value = item.receipient_bank_address2;
                command.Parameters.Add("@receipient_bank_country_id", SqlDbType.Int).Value = item.receipient_bank_country_id;
                command.Parameters.Add("@receipient_bank_province_id", SqlDbType.Int).Value = item.receipient_bank_province_id;
                command.Parameters.Add("@receipient_bank_city_id", SqlDbType.Int).Value = item.receipient_bank_city_id;
                command.Parameters.Add("@receipient_bank_zip_code", SqlDbType.VarChar).Value = item.receipient_bank_zip_code;
                command.Parameters.Add("@receipient_account_name", SqlDbType.VarChar).Value = item.receipient_account_name;
                command.Parameters.Add("@receipient_account_number", SqlDbType.VarChar).Value = item.receipient_account_number;
                command.Parameters.Add("@receipient_bank_swift_code", SqlDbType.VarChar).Value = item.receipient_bank_swift_code;
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
        public int Delete(Victim_financial_transactions item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spVictim_financial_transactions_Delete", connection);
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
        //GET ALL
        public List<Victim_financial_transactions> ListBy_VictimID(int victim_id)
        {
            List<Victim_financial_transactions> list = new List<Victim_financial_transactions>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spVictim_financial_transactions_ListBy_VictimID";
                command.Parameters.Add("@victim_id", SqlDbType.Int).Value = victim_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Victim_financial_transactions
                    {
                        id = Convert.ToInt32(dr["id"]),
                        victim_id = Convert.ToInt32(dr["victim_id"]),
                        transaction_date = dr["transaction_date"].ToString(),
                        rgv_transaction_type_id = Convert.ToInt32(dr["rgv_transaction_type_id"]),
                        is_others = Convert.ToInt32(dr["is_others"]),
                        others = dr["others"].ToString(),
                        amount = Convert.ToDouble(dr["amount"]),
                        is_sent = Convert.ToInt32(dr["is_sent"]),
                        victim_bank_name = dr["victim_bank_name"].ToString(),
                        victim_bank_address1 = dr["victim_bank_address1"].ToString(),
                        victim_bank_address2 = dr["victim_bank_address2"].ToString(),
                        victim_bank_country_id = Convert.ToInt32(dr["victim_bank_country_id"]),
                        victim_bank_country_code = dr["victim_bank_country_code"].ToString(),
                        victim_bank_country_name = dr["victim_bank_country_name"].ToString(),
                        victim_bank_country_description = dr["victim_bank_country_description"].ToString(),
                        victim_bank_province_id = Convert.ToInt32(dr["victim_bank_province_id"]),
                        victim_bank_province_code = dr["victim_bank_province_code"].ToString(),
                        victim_bank_province_name = dr["victim_bank_province_name"].ToString(),
                        victim_bank_province_description = dr["victim_bank_province_description"].ToString(),
                        victim_bank_city_id = Convert.ToInt32(dr["victim_bank_city_id"]),
                        victim_bank_city_code = dr["victim_bank_city_code"].ToString(),
                        victim_bank_city_name = dr["victim_bank_city_name"].ToString(),
                        victim_bank_city_description = dr["victim_bank_city_description"].ToString(),
                        victim_bank_zip_code = dr["victim_bank_zip_code"].ToString(),
                        victim_account_name = dr["victim_account_name"].ToString(),
                        victim_account_number = dr["victim_account_number"].ToString(),
                        receipient_bank_name = dr["receipient_bank_name"].ToString(),
                        receipient_bank_address1 = dr["receipient_bank_address1"].ToString(),
                        receipient_bank_address2 = dr["receipient_bank_address2"].ToString(),
                        receipient_bank_country_id = Convert.ToInt32(dr["receipient_bank_country_id"]),
                        receipient_bank_country_code = dr["receipient_bank_country_code"].ToString(),
                        receipient_bank_country_name = dr["receipient_bank_country_name"].ToString(),
                        receipient_bank_country_description = dr["receipient_bank_country_description"].ToString(),
                        receipient_bank_province_id = Convert.ToInt32(dr["receipient_bank_province_id"]),
                        receipient_bank_province_code = dr["receipient_bank_province_code"].ToString(),
                        receipient_bank_province_name = dr["receipient_bank_province_name"].ToString(),
                        receipient_bank_province_description = dr["receipient_bank_province_description"].ToString(),
                        receipient_bank_city_id = Convert.ToInt32(dr["receipient_bank_city_id"]),
                        receipient_bank_city_code = dr["receipient_bank_city_code"].ToString(),
                        receipient_bank_city_name = dr["receipient_bank_city_name"].ToString(),
                        receipient_bank_city_description = dr["receipient_bank_city_description"].ToString(),
                        receipient_bank_zip_code = dr["receipient_bank_zip_code"].ToString(),
                        receipient_account_name = dr["receipient_account_name"].ToString(),
                        receipient_account_number = dr["receipient_account_number"].ToString(),
                        receipient_bank_swift_code = dr["receipient_bank_swift_code"].ToString(),
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
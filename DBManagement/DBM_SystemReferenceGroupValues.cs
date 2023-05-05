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
    public class DBM_SystemReferenceGroupValues
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<System_reference_group_values> ListAll()
        {
            List<System_reference_group_values> list = new List<System_reference_group_values>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_reference_group_values_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_reference_group_values
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_reference_group_id = Convert.ToInt32(dr["system_reference_group_id"]),
                        system_reference_group_department_id = Convert.ToInt32(dr["system_reference_group_department_id"]),
                        system_reference_group_department_code = dr["system_reference_group_department_code"].ToString(),
                        system_reference_group_department_name = dr["system_reference_group_department_name"].ToString(),
                        system_reference_group_department_description = dr["system_reference_group_department_description"].ToString(),
                        system_reference_group_division_id = Convert.ToInt32(dr["system_reference_group_division_id"]),
                        system_reference_group_division_code = dr["system_reference_group_division_code"].ToString(),
                        system_reference_group_division_name = dr["system_reference_group_division_name"].ToString(),
                        system_reference_group_division_description = dr["system_reference_group_division_description"].ToString(),
                        system_reference_group_code = dr["system_reference_group_code"].ToString(),
                        system_reference_group_name = dr["system_reference_group_name"].ToString(),
                        system_reference_group_description = dr["system_reference_group_description"].ToString(),
                        system_reference_group_ctr = Convert.ToInt32(dr["system_reference_group_ctr"]),
                        code = dr["code"].ToString(),
                        name = dr["name"].ToString(),
                        description = dr["description"].ToString(),
                        ctr = Convert.ToInt32(dr["ctr"]),
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

        //GET BY ID
        public System_reference_group_values GetBy_ID(int id)
        {
            System_reference_group_values item = new System_reference_group_values();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_reference_group_values_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.system_reference_group_id = Convert.ToInt32(dr["system_reference_group_id"]);
                    item.system_reference_group_department_id = Convert.ToInt32(dr["system_reference_group_department_id"]);
                    item.system_reference_group_department_code = dr["system_reference_group_department_code"].ToString();
                    item.system_reference_group_department_name = dr["system_reference_group_department_name"].ToString();
                    item.system_reference_group_department_description = dr["system_reference_group_department_description"].ToString();
                    item.system_reference_group_division_id = Convert.ToInt32(dr["system_reference_group_division_id"]);
                    item.system_reference_group_division_code = dr["system_reference_group_division_code"].ToString();
                    item.system_reference_group_division_name = dr["system_reference_group_division_name"].ToString();
                    item.system_reference_group_division_description = dr["system_reference_group_division_description"].ToString();
                    item.system_reference_group_code = dr["system_reference_group_code"].ToString();
                    item.system_reference_group_name = dr["system_reference_group_name"].ToString();
                    item.system_reference_group_description = dr["system_reference_group_description"].ToString();
                    item.system_reference_group_ctr = Convert.ToInt32(dr["system_reference_group_ctr"]);
                    item.code = dr["code"].ToString();
                    item.name = dr["name"].ToString();
                    item.description = dr["description"].ToString();
                    item.ctr = Convert.ToInt32(dr["ctr"]);
                    item.created_by = dr["created_by"].ToString();
                    item.created_at = Convert.ToDateTime(dr["created_at"]);
                    item.updated_by = dr["updated_by"].ToString();
                    item.updated_at = Convert.ToDateTime(dr["updated_at"]);
                    item.deleted_by = dr["deleted_by"].ToString();
                    item.deleted_at = Convert.ToDateTime(dr["deleted_at"]);
                }

            }

            return item;
        }

        //CREATE
        public int Insert(System_reference_group_values item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_reference_group_values_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@system_reference_group_id", SqlDbType.Int).Value = item.system_reference_group_id;
                command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
                command.Parameters.Add("@ctr", SqlDbType.Int).Value = item.ctr;
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

        //UPDATE
        public int Update(System_reference_group_values item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_reference_group_values_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@system_reference_group_id", SqlDbType.Int).Value = item.system_reference_group_id;
                command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
                command.Parameters.Add("@ctr", SqlDbType.Int).Value = item.ctr;
                command.Parameters.Add("@updated_by", SqlDbType.VarChar).Value = item.updated_by;
                command.Parameters.Add("@updated_at", SqlDbType.DateTime).Value = item.updated_at;

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
        public int Delete(System_reference_group_values item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_reference_group_values_Delete", connection);
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
        public List<System_reference_group_values> ListBy_GroupCodeDepartmentDivisionID(string reference_group_code, int department_id, int division_id)
        {
            List<System_reference_group_values> list = new List<System_reference_group_values>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_reference_group_values_ListBy_GroupCodeDepartmentDivisionID";
                command.Parameters.Add("@reference_group_code", SqlDbType.VarChar).Value = reference_group_code;
                command.Parameters.Add("@department_id", SqlDbType.Int).Value = department_id;
                command.Parameters.Add("@division_id", SqlDbType.Int).Value = division_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_reference_group_values
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_reference_group_id = Convert.ToInt32(dr["system_reference_group_id"]),
                        system_reference_group_department_id = Convert.ToInt32(dr["system_reference_group_department_id"]),
                        system_reference_group_department_code = dr["system_reference_group_department_code"].ToString(),
                        system_reference_group_department_name = dr["system_reference_group_department_name"].ToString(),
                        system_reference_group_department_description = dr["system_reference_group_department_description"].ToString(),
                        system_reference_group_division_id = Convert.ToInt32(dr["system_reference_group_division_id"]),
                        system_reference_group_division_code = dr["system_reference_group_division_code"].ToString(),
                        system_reference_group_division_name = dr["system_reference_group_division_name"].ToString(),
                        system_reference_group_division_description = dr["system_reference_group_division_description"].ToString(),
                        system_reference_group_code = dr["system_reference_group_code"].ToString(),
                        system_reference_group_name = dr["system_reference_group_name"].ToString(),
                        system_reference_group_description = dr["system_reference_group_description"].ToString(),
                        system_reference_group_ctr = Convert.ToInt32(dr["system_reference_group_ctr"]),
                        code = dr["code"].ToString(),
                        name = dr["name"].ToString(),
                        description = dr["description"].ToString(),
                        ctr = Convert.ToInt32(dr["ctr"]),
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
        #endregion
    }
}
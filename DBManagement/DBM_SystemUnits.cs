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
    public class DBM_SystemUnits
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<System_units> ListAll()
        {
            List<System_units> list = new List<System_units>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_units_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_units
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_department_id = Convert.ToInt32(dr["system_department_id"]),
                        system_department_code = dr["system_department_code"].ToString(),
                        system_department_name = dr["system_department_name"].ToString(),
                        system_department_description = dr["system_department_description"].ToString(),
                        system_department_ctr = Convert.ToInt32(dr["system_department_ctr"]),
                        system_division_id = Convert.ToInt32(dr["system_division_id"]),
                        system_division_code = dr["system_division_code"].ToString(),
                        system_division_name = dr["system_division_name"].ToString(),
                        system_division_description = dr["system_division_description"].ToString(),
                        system_division_ctr = Convert.ToInt32(dr["system_division_ctr"]),
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
        public System_units GetBy_ID(int id)
        {
            System_units item = new System_units();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_units_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.system_department_id = Convert.ToInt32(dr["system_department_id"]);
                    item.system_department_code = dr["system_department_code"].ToString();
                    item.system_department_name = dr["system_department_name"].ToString();
                    item.system_department_description = dr["system_department_description"].ToString();
                    item.system_department_ctr = Convert.ToInt32(dr["system_department_ctr"]);
                    item.system_division_id = Convert.ToInt32(dr["system_division_id"]);
                    item.system_division_code = dr["system_division_code"].ToString();
                    item.system_division_name = dr["system_division_name"].ToString();
                    item.system_division_description = dr["system_division_description"].ToString();
                    item.system_division_ctr = Convert.ToInt32(dr["system_division_ctr"]);
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
        public int Insert(System_units item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_units_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@system_division_id", SqlDbType.Int).Value = item.system_division_id;
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
        public int Update(System_units item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_units_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@system_division_id", SqlDbType.Int).Value = item.system_division_id;
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
        public int Delete(System_units item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_units_Delete", connection);
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
        public List<System_units> ListBy_SystemDepartmentDivisionID(int system_department_id, int system_division_id)
        {
            List<System_units> list = new List<System_units>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_units_ListBy_SystemDepartmentDivisionID";
                command.Parameters.Add("@system_department_id", SqlDbType.Int).Value = system_department_id;
                command.Parameters.Add("@system_division_id", SqlDbType.Int).Value = system_division_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_units
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_department_id = Convert.ToInt32(dr["system_department_id"]),
                        system_department_code = dr["system_department_code"].ToString(),
                        system_department_name = dr["system_department_name"].ToString(),
                        system_department_description = dr["system_department_description"].ToString(),
                        system_department_ctr = Convert.ToInt32(dr["system_department_ctr"]),
                        system_division_id = Convert.ToInt32(dr["system_division_id"]),
                        system_division_code = dr["system_division_code"].ToString(),
                        system_division_name = dr["system_division_name"].ToString(),
                        system_division_description = dr["system_division_description"].ToString(),
                        system_division_ctr = Convert.ToInt32(dr["system_division_ctr"]),
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
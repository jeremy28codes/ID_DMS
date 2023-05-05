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
    public class DBM_SystemWebSections
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<System_web_sections> ListAll()
        {
            List<System_web_sections> list = new List<System_web_sections>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_web_sections_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_web_sections
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]),
                        system_web_module_code = dr["system_web_module_code"].ToString(),
                        system_web_module_name = dr["system_web_module_name"].ToString(),
                        system_web_module_description = dr["system_web_module_description"].ToString(),
                        system_web_module_link = dr["system_web_module_link"].ToString(),
                        system_web_module_icon = dr["system_web_module_icon"].ToString(),
                        system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]),
                        system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]),
                        code = dr["code"].ToString(),
                        name = dr["name"].ToString(),
                        description = dr["description"].ToString(),
                        link = dr["link"].ToString(),
                        icon = dr["icon"].ToString(),
                        ctr = Convert.ToInt32(dr["ctr"]),
                        created_by = dr["created_by"].ToString(),
                        created_at = Convert.ToDateTime(dr["created_at"]),
                        updated_by = dr["updated_by"].ToString(),
                        updated_at = Convert.ToDateTime(dr["updated_at"]),
                        deleted_by = dr["deleted_by"].ToString(),
                        deleted_at = Convert.ToDateTime(dr["deleted_at"]),
                        is_active = Convert.ToInt32(dr["is_active"]),
                    });
                }
            }

            return list;
        }

        //GET BY ID
        public System_web_sections GetBy_ID(int id)
        {
            System_web_sections item = new System_web_sections();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_web_sections_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]);
                    item.code = dr["code"].ToString();
                    item.name = dr["name"].ToString();
                    item.description = dr["description"].ToString();
                    item.link = dr["link"].ToString();
                    item.icon = dr["icon"].ToString();
                    item.ctr = Convert.ToInt32(dr["ctr"]);
                    item.created_by = dr["created_by"].ToString();
                    item.created_at = Convert.ToDateTime(dr["created_at"]);
                    item.updated_by = dr["updated_by"].ToString();
                    item.updated_at = Convert.ToDateTime(dr["updated_at"]);
                    item.deleted_by = dr["deleted_by"].ToString();
                    item.deleted_at = Convert.ToDateTime(dr["deleted_at"]);
                    item.is_active = Convert.ToInt32(dr["is_active"]);
                }

            }

            return item;
        }

        //CREATE
        public int Insert(System_web_sections item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_web_sections_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@system_web_module_id", SqlDbType.Int).Value = item.system_web_module_id;
                command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
                command.Parameters.Add("@link", SqlDbType.VarChar).Value = item.link;
                command.Parameters.Add("@icon", SqlDbType.VarChar).Value = item.icon;
                command.Parameters.Add("@ctr", SqlDbType.Int).Value = item.ctr;
                command.Parameters.Add("@created_by", SqlDbType.VarChar).Value = item.created_by;
                command.Parameters.Add("@created_at", SqlDbType.DateTime).Value = item.created_at;
                command.Parameters.Add("@is_active", SqlDbType.Int).Value = item.is_active;

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
        public int Update(System_web_sections item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_web_sections_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@system_web_module_id", SqlDbType.Int).Value = item.system_web_module_id;
                command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
                command.Parameters.Add("@link", SqlDbType.VarChar).Value = item.link;
                command.Parameters.Add("@icon", SqlDbType.VarChar).Value = item.icon;
                command.Parameters.Add("@ctr", SqlDbType.Int).Value = item.ctr;
                command.Parameters.Add("@updated_by", SqlDbType.VarChar).Value = item.updated_by;
                command.Parameters.Add("@updated_at", SqlDbType.DateTime).Value = item.updated_at;
                command.Parameters.Add("@is_active", SqlDbType.Int).Value = item.is_active;

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
        public int Delete(System_web_sections item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_web_sections_Delete", connection);
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
        public List<System_web_sections> ListBy_ModuleID(int system_web_module_id)
        {
            List<System_web_sections> list = new List<System_web_sections>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_web_sections_ListBy_ModuleID";
                command.Parameters.Add("@system_web_module_id", SqlDbType.Int).Value = system_web_module_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_web_sections
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]),
                        system_web_module_code = dr["system_web_module_code"].ToString(),
                        system_web_module_name = dr["system_web_module_name"].ToString(),
                        system_web_module_description = dr["system_web_module_description"].ToString(),
                        system_web_module_link = dr["system_web_module_link"].ToString(),
                        system_web_module_icon = dr["system_web_module_icon"].ToString(),
                        system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]),
                        system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]),
                        code = dr["code"].ToString(),
                        name = dr["name"].ToString(),
                        description = dr["description"].ToString(),
                        link = dr["link"].ToString(),
                        icon = dr["icon"].ToString(),
                        ctr = Convert.ToInt32(dr["ctr"]),
                        created_by = dr["created_by"].ToString(),
                        created_at = Convert.ToDateTime(dr["created_at"]),
                        updated_by = dr["updated_by"].ToString(),
                        updated_at = Convert.ToDateTime(dr["updated_at"]),
                        deleted_by = dr["deleted_by"].ToString(),
                        deleted_at = Convert.ToDateTime(dr["deleted_at"]),
                        is_active = Convert.ToInt32(dr["is_active"]),
                    });
                }
            }

            return list;
        }

        public List<System_web_sections> ListAll_NotExistsRole(int system_role_id, int system_web_module_id)
        {
            List<System_web_sections> list = new List<System_web_sections>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_web_sections_ListAll_NotExistsRole";
                command.Parameters.Add("@system_role_id", SqlDbType.Int).Value = system_role_id;
                command.Parameters.Add("@system_web_module_id", SqlDbType.Int).Value = system_web_module_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_web_sections
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]),
                        system_web_module_code = dr["system_web_module_code"].ToString(),
                        system_web_module_name = dr["system_web_module_name"].ToString(),
                        system_web_module_description = dr["system_web_module_description"].ToString(),
                        system_web_module_link = dr["system_web_module_link"].ToString(),
                        system_web_module_icon = dr["system_web_module_icon"].ToString(),
                        system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]),
                        system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]),
                        code = dr["code"].ToString(),
                        name = dr["name"].ToString(),
                        description = dr["description"].ToString(),
                        link = dr["link"].ToString(),
                        icon = dr["icon"].ToString(),
                        ctr = Convert.ToInt32(dr["ctr"]),
                        created_by = dr["created_by"].ToString(),
                        created_at = Convert.ToDateTime(dr["created_at"]),
                        updated_by = dr["updated_by"].ToString(),
                        updated_at = Convert.ToDateTime(dr["updated_at"]),
                        deleted_by = dr["deleted_by"].ToString(),
                        deleted_at = Convert.ToDateTime(dr["deleted_at"]),
                        is_active = Convert.ToInt32(dr["is_active"]),
                    });
                }
            }

            return list;
        }
        #endregion
    }
}
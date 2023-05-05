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
    public class DBM_SystemUserRoleModuleAccess
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<System_user_role_module_access> ListAll()
        {
            List<System_user_role_module_access> list = new List<System_user_role_module_access>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_user_role_module_access_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_user_role_module_access
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_role_id = Convert.ToInt32(dr["system_role_id"]),
                        system_role_code = dr["system_role_code"].ToString(),
                        system_role_name = dr["system_role_name"].ToString(),
                        system_role_description = dr["system_role_description"].ToString(),
                        system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]),
                        system_web_module_code = dr["system_web_module_code"].ToString(),
                        system_web_module_name = dr["system_web_module_name"].ToString(),
                        system_web_module_description = dr["system_web_module_description"].ToString(),
                        system_web_module_link = dr["system_web_module_link"].ToString(),
                        system_web_module_icon = dr["system_web_module_icon"].ToString(),
                        system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]),
                        system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]),
                        can_access = Convert.ToInt32(dr["can_access"]),
                        can_view = Convert.ToInt32(dr["can_view"]),
                        can_create = Convert.ToInt32(dr["can_create"]),
                        can_edit = Convert.ToInt32(dr["can_edit"]),
                        can_delete = Convert.ToInt32(dr["can_delete"]),
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
        public System_user_role_module_access GetBy_ID(int id)
        {
            System_user_role_module_access item = new System_user_role_module_access();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_user_role_module_access_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.system_role_id = Convert.ToInt32(dr["system_role_id"]);
                    item.system_role_code = dr["system_role_code"].ToString();
                    item.system_role_name = dr["system_role_name"].ToString();
                    item.system_role_description = dr["system_role_description"].ToString();
                    item.system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]);
                    item.system_web_module_code = dr["system_web_module_code"].ToString();
                    item.system_web_module_name = dr["system_web_module_name"].ToString();
                    item.system_web_module_description = dr["system_web_module_description"].ToString();
                    item.system_web_module_link = dr["system_web_module_link"].ToString();
                    item.system_web_module_icon = dr["system_web_module_icon"].ToString();
                    item.system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]);
                    item.system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]);
                    item.can_access = Convert.ToInt32(dr["can_access"]);
                    item.can_view = Convert.ToInt32(dr["can_view"]);
                    item.can_create = Convert.ToInt32(dr["can_create"]);
                    item.can_edit = Convert.ToInt32(dr["can_edit"]);
                    item.can_delete = Convert.ToInt32(dr["can_delete"]);
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
        public int Insert(System_user_role_module_access item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_user_role_module_access_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@system_role_id", SqlDbType.Int).Value = item.system_role_id;
                command.Parameters.Add("@system_web_module_id", SqlDbType.Int).Value = item.system_web_module_id;
                command.Parameters.Add("@can_access", SqlDbType.Int).Value = item.can_access;
                command.Parameters.Add("@can_view", SqlDbType.Int).Value = item.can_view;
                command.Parameters.Add("@can_create", SqlDbType.Int).Value = item.can_create;
                command.Parameters.Add("@can_edit", SqlDbType.Int).Value = item.can_edit;
                command.Parameters.Add("@can_delete", SqlDbType.Int).Value = item.can_delete;
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
        public int Update(System_user_role_module_access item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_user_role_module_access_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@system_role_id", SqlDbType.Int).Value = item.system_role_id;
                command.Parameters.Add("@system_web_module_id", SqlDbType.Int).Value = item.system_web_module_id;
                command.Parameters.Add("@can_access", SqlDbType.Int).Value = item.can_access;
                command.Parameters.Add("@can_view", SqlDbType.Int).Value = item.can_view;
                command.Parameters.Add("@can_create", SqlDbType.Int).Value = item.can_create;
                command.Parameters.Add("@can_edit", SqlDbType.Int).Value = item.can_edit;
                command.Parameters.Add("@can_delete", SqlDbType.Int).Value = item.can_delete;
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
        public int Delete(System_user_role_module_access item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_user_role_module_access_Delete", connection);
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
        
        public List<System_user_role_module_access> ListBy_SystemRoleID(int system_role_id)
        {
            List<System_user_role_module_access> list = new List<System_user_role_module_access>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_user_role_module_access_ListBy_SystemRoleID";
                command.Parameters.Add("@system_role_id", SqlDbType.Int).Value = system_role_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_user_role_module_access
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_role_id = Convert.ToInt32(dr["system_role_id"]),
                        system_role_code = dr["system_role_code"].ToString(),
                        system_role_name = dr["system_role_name"].ToString(),
                        system_role_description = dr["system_role_description"].ToString(),
                        system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]),
                        system_web_module_code = dr["system_web_module_code"].ToString(),
                        system_web_module_name = dr["system_web_module_name"].ToString(),
                        system_web_module_description = dr["system_web_module_description"].ToString(),
                        system_web_module_link = dr["system_web_module_link"].ToString(),
                        system_web_module_icon = dr["system_web_module_icon"].ToString(),
                        system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]),
                        system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]),
                        can_access = Convert.ToInt32(dr["can_access"]),
                        can_view = Convert.ToInt32(dr["can_view"]),
                        can_create = Convert.ToInt32(dr["can_create"]),
                        can_edit = Convert.ToInt32(dr["can_edit"]),
                        can_delete = Convert.ToInt32(dr["can_delete"]),
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

        public List<System_user_role_module_access> ListAll_SystemRoleID(int system_role_id)
        {
            List<System_user_role_module_access> list = new List<System_user_role_module_access>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_user_role_module_access_ListAll_SystemRoleID";
                command.Parameters.Add("@system_role_id", SqlDbType.Int).Value = system_role_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_user_role_module_access
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_role_id = Convert.ToInt32(dr["system_role_id"]),
                        system_role_code = dr["system_role_code"].ToString(),
                        system_role_name = dr["system_role_name"].ToString(),
                        system_role_description = dr["system_role_description"].ToString(),
                        system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]),
                        system_web_module_code = dr["system_web_module_code"].ToString(),
                        system_web_module_name = dr["system_web_module_name"].ToString(),
                        system_web_module_description = dr["system_web_module_description"].ToString(),
                        system_web_module_link = dr["system_web_module_link"].ToString(),
                        system_web_module_icon = dr["system_web_module_icon"].ToString(),
                        system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]),
                        system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]),
                        can_access = Convert.ToInt32(dr["can_access"]),
                        can_view = Convert.ToInt32(dr["can_view"]),
                        can_create = Convert.ToInt32(dr["can_create"]),
                        can_edit = Convert.ToInt32(dr["can_edit"]),
                        can_delete = Convert.ToInt32(dr["can_delete"]),
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

        public List<System_user_role_module_access> ListBy_RoleID(int system_role_id, int system_web_module_id)
        {
            List<System_user_role_module_access> list = new List<System_user_role_module_access>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_user_role_section_access_ListBy_RoleID";
                command.Parameters.Add("@system_role_id", SqlDbType.Int).Value = system_role_id;
                command.Parameters.Add("@system_web_module_id", SqlDbType.Int).Value = system_web_module_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_user_role_module_access
                    {
                        id = Convert.ToInt32(dr["id"]),
                        system_role_id = Convert.ToInt32(dr["system_role_id"]),
                        system_role_code = dr["system_role_code"].ToString(),
                        system_role_name = dr["system_role_name"].ToString(),
                        system_role_description = dr["system_role_description"].ToString(),
                        system_web_module_id = Convert.ToInt32(dr["system_web_module_id"]),
                        system_web_module_code = dr["system_web_module_code"].ToString(),
                        system_web_module_name = dr["system_web_module_name"].ToString(),
                        system_web_module_description = dr["system_web_module_description"].ToString(),
                        system_web_module_link = dr["system_web_module_link"].ToString(),
                        system_web_module_icon = dr["system_web_module_icon"].ToString(),
                        system_web_module_ctr = Convert.ToInt32(dr["system_web_module_ctr"]),
                        system_web_module_is_active = Convert.ToInt32(dr["system_web_module_is_active"]),
                        can_access = Convert.ToInt32(dr["can_access"]),
                        can_view = Convert.ToInt32(dr["can_view"]),
                        can_create = Convert.ToInt32(dr["can_create"]),
                        can_edit = Convert.ToInt32(dr["can_edit"]),
                        can_delete = Convert.ToInt32(dr["can_delete"]),
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
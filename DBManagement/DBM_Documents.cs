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
    public class DBM_Documents
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<Documents> ListAll()
        {
            List<Documents> list = new List<Documents>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocuments_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Documents
                    {
                        id = Convert.ToInt32(dr["id"]),
                        reference_number = dr["reference_number"].ToString(),
                        routing_number = dr["routing_number"].ToString(),
                        title = dr["title"].ToString(),
                        rgv_document_particular_id = Convert.ToInt32(dr["rgv_document_particular_id"]),
                        rgv_document_particular_code = dr["rgv_document_particular_code"].ToString(),
                        rgv_document_particular_name = dr["rgv_document_particular_name"].ToString(),
                        rgv_document_particular_description = dr["rgv_document_particular_description"].ToString(),
                        rgv_document_particular_ctr = Convert.ToInt32(dr["rgv_document_particular_ctr"]),
                        rgv_document_type_id = Convert.ToInt32(dr["rgv_document_type_id"]),
                        rgv_document_type_code = dr["rgv_document_type_code"].ToString(),
                        rgv_document_type_name = dr["rgv_document_type_name"].ToString(),
                        rgv_document_type_description = dr["rgv_document_type_description"].ToString(),
                        rgv_document_type_ctr = Convert.ToInt32(dr["rgv_document_type_ctr"]),
                        rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]),
                        rgv_document_status_code = dr["rgv_document_status_code"].ToString(),
                        rgv_document_status_name = dr["rgv_document_status_name"].ToString(),
                        rgv_document_status_description = dr["rgv_document_status_description"].ToString(),
                        rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]),
                        completed_at = dr["completed_at"].ToString(),
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
        public Documents GetBy_ID(int id)
        {
            Documents item = new Documents();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocuments_GetBy_ID";
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
                    item.routing_number = dr["routing_number"].ToString();
                    item.title = dr["title"].ToString();
                    item.rgv_document_particular_id = Convert.ToInt32(dr["rgv_document_particular_id"]);
                    item.rgv_document_particular_code = dr["rgv_document_particular_code"].ToString();
                    item.rgv_document_particular_name = dr["rgv_document_particular_name"].ToString();
                    item.rgv_document_particular_description = dr["rgv_document_particular_description"].ToString();
                    item.rgv_document_particular_ctr = Convert.ToInt32(dr["rgv_document_particular_ctr"]);
                    item.rgv_document_type_id = Convert.ToInt32(dr["rgv_document_type_id"]);
                    item.rgv_document_type_code = dr["rgv_document_type_code"].ToString();
                    item.rgv_document_type_name = dr["rgv_document_type_name"].ToString();
                    item.rgv_document_type_description = dr["rgv_document_type_description"].ToString();
                    item.rgv_document_type_ctr = Convert.ToInt32(dr["rgv_document_type_ctr"]);
                    item.rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]);
                    item.rgv_document_status_code = dr["rgv_document_status_code"].ToString();
                    item.rgv_document_status_name = dr["rgv_document_status_name"].ToString();
                    item.rgv_document_status_description = dr["rgv_document_status_description"].ToString();
                    item.rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]);
                    item.completed_at = dr["completed_at"].ToString();
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
        public int Insert(Documents item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocuments_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@reference_number", SqlDbType.VarChar).Value = item.reference_number;
                command.Parameters.Add("@routing_number", SqlDbType.VarChar).Value = item.routing_number;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = item.title;
                command.Parameters.Add("@rgv_document_particular_id", SqlDbType.Int).Value = item.rgv_document_particular_id;
                command.Parameters.Add("@rgv_document_type_id", SqlDbType.Int).Value = item.rgv_document_type_id;
                command.Parameters.Add("@completed_at", SqlDbType.VarChar).Value = item.completed_at;
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
        public int Update(Documents item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocuments_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@reference_number", SqlDbType.VarChar).Value = item.reference_number;
                command.Parameters.Add("@routing_number", SqlDbType.VarChar).Value = item.routing_number;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = item.title;
                command.Parameters.Add("@rgv_document_particular_id", SqlDbType.Int).Value = item.rgv_document_particular_id;
                command.Parameters.Add("@rgv_document_type_id", SqlDbType.Int).Value = item.rgv_document_type_id;
                command.Parameters.Add("@completed_at", SqlDbType.VarChar).Value = item.completed_at;
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
        public int Delete(Documents item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocuments_Delete", connection);
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
        public List<Documents> ListAll_Incoming()
        {
            List<Documents> list = new List<Documents>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocuments_ListAll_Incoming";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Documents
                    {
                        id = Convert.ToInt32(dr["id"]),
                        reference_number = dr["reference_number"].ToString(),
                        routing_number = dr["routing_number"].ToString(),
                        title = dr["title"].ToString(),
                        rgv_document_particular_id = Convert.ToInt32(dr["rgv_document_particular_id"]),
                        rgv_document_particular_code = dr["rgv_document_particular_code"].ToString(),
                        rgv_document_particular_name = dr["rgv_document_particular_name"].ToString(),
                        rgv_document_particular_description = dr["rgv_document_particular_description"].ToString(),
                        rgv_document_particular_ctr = Convert.ToInt32(dr["rgv_document_particular_ctr"]),
                        rgv_document_type_id = Convert.ToInt32(dr["rgv_document_type_id"]),
                        rgv_document_type_code = dr["rgv_document_type_code"].ToString(),
                        rgv_document_type_name = dr["rgv_document_type_name"].ToString(),
                        rgv_document_type_description = dr["rgv_document_type_description"].ToString(),
                        rgv_document_type_ctr = Convert.ToInt32(dr["rgv_document_type_ctr"]),
                        rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]),
                        rgv_document_status_code = dr["rgv_document_status_code"].ToString(),
                        rgv_document_status_name = dr["rgv_document_status_name"].ToString(),
                        rgv_document_status_description = dr["rgv_document_status_description"].ToString(),
                        rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]),
                        completed_at = dr["completed_at"].ToString(),
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

        public List<Documents> ListAll_Outgoing()
        {
            List<Documents> list = new List<Documents>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocuments_ListAll_Outgoing";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Documents
                    {
                        id = Convert.ToInt32(dr["id"]),
                        reference_number = dr["reference_number"].ToString(),
                        routing_number = dr["routing_number"].ToString(),
                        title = dr["title"].ToString(),
                        rgv_document_particular_id = Convert.ToInt32(dr["rgv_document_particular_id"]),
                        rgv_document_particular_code = dr["rgv_document_particular_code"].ToString(),
                        rgv_document_particular_name = dr["rgv_document_particular_name"].ToString(),
                        rgv_document_particular_description = dr["rgv_document_particular_description"].ToString(),
                        rgv_document_particular_ctr = Convert.ToInt32(dr["rgv_document_particular_ctr"]),
                        rgv_document_type_id = Convert.ToInt32(dr["rgv_document_type_id"]),
                        rgv_document_type_code = dr["rgv_document_type_code"].ToString(),
                        rgv_document_type_name = dr["rgv_document_type_name"].ToString(),
                        rgv_document_type_description = dr["rgv_document_type_description"].ToString(),
                        rgv_document_type_ctr = Convert.ToInt32(dr["rgv_document_type_ctr"]),
                        rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]),
                        rgv_document_status_code = dr["rgv_document_status_code"].ToString(),
                        rgv_document_status_name = dr["rgv_document_status_name"].ToString(),
                        rgv_document_status_description = dr["rgv_document_status_description"].ToString(),
                        rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]),
                        completed_at = dr["completed_at"].ToString(),
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

        public List<Documents> ListAll_Completed()
        {
            List<Documents> list = new List<Documents>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocuments_ListAll_Completed";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Documents
                    {
                        id = Convert.ToInt32(dr["id"]),
                        reference_number = dr["reference_number"].ToString(),
                        routing_number = dr["routing_number"].ToString(),
                        title = dr["title"].ToString(),
                        rgv_document_particular_id = Convert.ToInt32(dr["rgv_document_particular_id"]),
                        rgv_document_particular_code = dr["rgv_document_particular_code"].ToString(),
                        rgv_document_particular_name = dr["rgv_document_particular_name"].ToString(),
                        rgv_document_particular_description = dr["rgv_document_particular_description"].ToString(),
                        rgv_document_particular_ctr = Convert.ToInt32(dr["rgv_document_particular_ctr"]),
                        rgv_document_type_id = Convert.ToInt32(dr["rgv_document_type_id"]),
                        rgv_document_type_code = dr["rgv_document_type_code"].ToString(),
                        rgv_document_type_name = dr["rgv_document_type_name"].ToString(),
                        rgv_document_type_description = dr["rgv_document_type_description"].ToString(),
                        rgv_document_type_ctr = Convert.ToInt32(dr["rgv_document_type_ctr"]),
                        rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]),
                        rgv_document_status_code = dr["rgv_document_status_code"].ToString(),
                        rgv_document_status_name = dr["rgv_document_status_name"].ToString(),
                        rgv_document_status_description = dr["rgv_document_status_description"].ToString(),
                        rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]),
                        completed_at = dr["completed_at"].ToString(),
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

        public Documents Generate_ReferenceNumber(int system_division_id, int rgv_action_type_id)
        {
            Documents item = new Documents();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spReferenceNumber_GetBy_DivisionActionType";
                command.Parameters.Add("@system_division_id", SqlDbType.Int).Value = system_division_id;
                command.Parameters.Add("@rgv_action_type_id", SqlDbType.Int).Value = rgv_action_type_id;
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

        public int Insert_ReferenceNumber(Document_reference_numbers item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocument_reference_numbers_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = item.document_id;
                command.Parameters.Add("@rgv_action_type_id", SqlDbType.Int).Value = item.rgv_action_type_id;
                command.Parameters.Add("@system_department_id", SqlDbType.Int).Value = item.system_department_id;
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
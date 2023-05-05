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
    public class DBM_DocumentAttachments
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<Document_attachments> ListAll()
        {
            List<Document_attachments> list = new List<Document_attachments>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_attachments_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Document_attachments
                    {
                        id = Convert.ToInt32(dr["id"]),
                        document_id = Convert.ToInt32(dr["document_id"]),
                        document_route_log_id = Convert.ToInt32(dr["document_route_log_id"]),
                        file_name = dr["file_name"].ToString(),
                        file_type = dr["file_type"].ToString(),
                        file_size = dr["file_size"].ToString(),
                        file_path = dr["file_path"].ToString(),
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
        public Document_attachments GetBy_ID(int id)
        {
            Document_attachments item = new Document_attachments();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_attachments_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.document_id = Convert.ToInt32(dr["document_id"]);
                    item.document_route_log_id = Convert.ToInt32(dr["document_route_log_id"]);
                    item.file_name = dr["file_name"].ToString();
                    item.file_type = dr["file_type"].ToString();
                    item.file_size = dr["file_size"].ToString();
                    item.file_path = dr["file_path"].ToString();
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
        public int Insert(Document_attachments item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocument_attachments_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = item.document_id;
                command.Parameters.Add("@document_route_log_id", SqlDbType.Int).Value = item.document_route_log_id;
                command.Parameters.Add("@file_name", SqlDbType.NVarChar).Value = item.file_name;
                command.Parameters.Add("@file_type", SqlDbType.NVarChar).Value = item.file_type;
                command.Parameters.Add("@file_size", SqlDbType.NVarChar).Value = item.file_size;
                command.Parameters.Add("@file_path", SqlDbType.NVarChar).Value = item.file_path;
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
        public int Update(Document_attachments item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocument_attachments_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = item.document_id;
                command.Parameters.Add("@document_route_log_id", SqlDbType.Int).Value = item.document_route_log_id;
                command.Parameters.Add("@file_name", SqlDbType.NVarChar).Value = item.file_name;
                command.Parameters.Add("@file_type", SqlDbType.NVarChar).Value = item.file_type;
                command.Parameters.Add("@file_size", SqlDbType.NVarChar).Value = item.file_size;
                command.Parameters.Add("@file_path", SqlDbType.NVarChar).Value = item.file_path;
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
        public int Delete(Document_attachments item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocument_attachments_Delete", connection);
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
        public List<Document_attachments> ListBy_DocumentID(int document_id)
        {
            List<Document_attachments> list = new List<Document_attachments>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_attachments_ListBy_DocumentID";
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = document_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Document_attachments
                    {
                        id = Convert.ToInt32(dr["id"]),
                        document_id = Convert.ToInt32(dr["document_id"]),
                        document_route_log_id = Convert.ToInt32(dr["document_route_log_id"]),
                        file_name = dr["file_name"].ToString(),
                        file_type = dr["file_type"].ToString(),
                        file_size = dr["file_size"].ToString(),
                        file_path = dr["file_path"].ToString(),
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

        public List<Document_attachments> ListBy_DocumentRouteLogID(int document_route_log_id)
        {
            List<Document_attachments> list = new List<Document_attachments>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_attachments_ListBy_DocumentRouteLogID";
                command.Parameters.Add("@document_route_log_id", SqlDbType.Int).Value = document_route_log_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Document_attachments
                    {
                        id = Convert.ToInt32(dr["id"]),
                        document_id = Convert.ToInt32(dr["document_id"]),
                        document_route_log_id = Convert.ToInt32(dr["document_route_log_id"]),
                        file_name = dr["file_name"].ToString(),
                        file_type = dr["file_type"].ToString(),
                        file_size = dr["file_size"].ToString(),
                        file_path = dr["file_path"].ToString(),
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
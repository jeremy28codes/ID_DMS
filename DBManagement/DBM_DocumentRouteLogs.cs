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
    public class DBM_DocumentRouteLogs
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<Document_route_logs> ListAll()
        {
            List<Document_route_logs> list = new List<Document_route_logs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_route_logs_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Document_route_logs
                    {
                        id = Convert.ToInt32(dr["id"]),
                        document_id = Convert.ToInt32(dr["document_id"]),
                        route_date = Convert.ToDateTime(dr["route_date"]).ToString("MM-dd-yyyy"),
                        route_time = Convert.ToDateTime(dr["route_time"]).ToString("HH:mm"),
                        from_system_department_id = Convert.ToInt32(dr["from_system_department_id"]),
                        from_system_department_code = dr["from_system_department_code"].ToString(),
                        from_system_department_name = dr["from_system_department_name"].ToString(),
                        from_system_department_description = dr["from_system_department_description"].ToString(),
                        from_system_department_ctr = Convert.ToInt32(dr["from_system_department_ctr"]),
                        from_system_division_id = Convert.ToInt32(dr["from_system_division_id"]),
                        from_system_division_code = dr["from_system_division_code"].ToString(),
                        from_system_division_name = dr["from_system_division_name"].ToString(),
                        from_system_division_description = dr["from_system_division_description"].ToString(),
                        from_system_division_ctr = Convert.ToInt32(dr["from_system_division_ctr"]),
                        from_system_unit_id = Convert.ToInt32(dr["from_system_unit_id"]),
                        from_system_unit_code = dr["from_system_unit_code"].ToString(),
                        from_system_unit_name = dr["from_system_unit_name"].ToString(),
                        from_system_unit_description = dr["from_system_unit_description"].ToString(),
                        from_system_unit_ctr = Convert.ToInt32(dr["from_system_unit_ctr"]),
                        from_name = dr["from_name"].ToString(),
                        to_system_department_id = Convert.ToInt32(dr["to_system_department_id"]),
                        to_system_department_code = dr["to_system_department_code"].ToString(),
                        to_system_department_name = dr["to_system_department_name"].ToString(),
                        to_system_department_description = dr["to_system_department_description"].ToString(),
                        to_system_department_ctr = Convert.ToInt32(dr["to_system_department_ctr"]),
                        to_system_division_id = Convert.ToInt32(dr["to_system_division_id"]),
                        to_system_division_code = dr["to_system_division_code"].ToString(),
                        to_system_division_name = dr["to_system_division_name"].ToString(),
                        to_system_division_description = dr["to_system_division_description"].ToString(),
                        to_system_division_ctr = Convert.ToInt32(dr["to_system_division_ctr"]),
                        to_system_unit_id = Convert.ToInt32(dr["to_system_unit_id"]),
                        to_system_unit_code = dr["to_system_unit_code"].ToString(),
                        to_system_unit_name = dr["to_system_unit_name"].ToString(),
                        to_system_unit_description = dr["to_system_unit_description"].ToString(),
                        to_system_unit_ctr = Convert.ToInt32(dr["to_system_unit_ctr"]),
                        to_name = dr["to_name"].ToString(),
                        rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]),
                        rgv_document_status_code = dr["rgv_document_status_code"].ToString(),
                        rgv_document_status_name = dr["rgv_document_status_name"].ToString(),
                        rgv_document_status_description = dr["rgv_document_status_description"].ToString(),
                        rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]),
                        rgv_action_type_id = Convert.ToInt32(dr["rgv_action_type_id"]),
                        rgv_action_type_code = dr["rgv_action_type_code"].ToString(),
                        rgv_action_type_name = dr["rgv_action_type_name"].ToString(),
                        rgv_action_type_description = dr["rgv_action_type_description"].ToString(),
                        rgv_action_type_ctr = Convert.ToInt32(dr["rgv_action_type_ctr"]),
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
        public Document_route_logs GetBy_ID(int id)
        {
            Document_route_logs item = new Document_route_logs();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_route_logs_GetBy_ID";
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
                    item.route_date = Convert.ToDateTime(dr["route_date"]).ToString("MM-dd-yyyy");
                    item.route_time = Convert.ToDateTime(dr["route_time"]).ToString("HH:mm");
                    item.from_system_department_id = Convert.ToInt32(dr["from_system_department_id"]);
                    item.from_system_department_code = dr["from_system_department_code"].ToString();
                    item.from_system_department_name = dr["from_system_department_name"].ToString();
                    item.from_system_department_description = dr["from_system_department_description"].ToString();
                    item.from_system_department_ctr = Convert.ToInt32(dr["from_system_department_ctr"]);
                    item.from_system_division_id = Convert.ToInt32(dr["from_system_division_id"]);
                    item.from_system_division_code = dr["from_system_division_code"].ToString();
                    item.from_system_division_name = dr["from_system_division_name"].ToString();
                    item.from_system_division_description = dr["from_system_division_description"].ToString();
                    item.from_system_division_ctr = Convert.ToInt32(dr["from_system_division_ctr"]);
                    item.from_system_unit_id = Convert.ToInt32(dr["from_system_unit_id"]);
                    item.from_system_unit_code = dr["from_system_unit_code"].ToString();
                    item.from_system_unit_name = dr["from_system_unit_name"].ToString();
                    item.from_system_unit_description = dr["from_system_unit_description"].ToString();
                    item.from_system_unit_ctr = Convert.ToInt32(dr["from_system_unit_ctr"]);
                    item.from_name = dr["from_name"].ToString();
                    item.to_system_department_id = Convert.ToInt32(dr["to_system_department_id"]);
                    item.to_system_department_code = dr["to_system_department_code"].ToString();
                    item.to_system_department_name = dr["to_system_department_name"].ToString();
                    item.to_system_department_description = dr["to_system_department_description"].ToString();
                    item.to_system_department_ctr = Convert.ToInt32(dr["to_system_department_ctr"]);
                    item.to_system_division_id = Convert.ToInt32(dr["to_system_division_id"]);
                    item.to_system_division_code = dr["to_system_division_code"].ToString();
                    item.to_system_division_name = dr["to_system_division_name"].ToString();
                    item.to_system_division_description = dr["to_system_division_description"].ToString();
                    item.to_system_division_ctr = Convert.ToInt32(dr["to_system_division_ctr"]);
                    item.to_system_unit_id = Convert.ToInt32(dr["to_system_unit_id"]);
                    item.to_system_unit_code = dr["to_system_unit_code"].ToString();
                    item.to_system_unit_name = dr["to_system_unit_name"].ToString();
                    item.to_system_unit_description = dr["to_system_unit_description"].ToString();
                    item.to_system_unit_ctr = Convert.ToInt32(dr["to_system_unit_ctr"]);
                    item.to_name = dr["to_name"].ToString();
                    item.rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]);
                    item.rgv_document_status_code = dr["rgv_document_status_code"].ToString();
                    item.rgv_document_status_name = dr["rgv_document_status_name"].ToString();
                    item.rgv_document_status_description = dr["rgv_document_status_description"].ToString();
                    item.rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]);
                    item.rgv_action_type_id = Convert.ToInt32(dr["rgv_action_type_id"]);
                    item.rgv_action_type_code = dr["rgv_action_type_code"].ToString();
                    item.rgv_action_type_name = dr["rgv_action_type_name"].ToString();
                    item.rgv_action_type_description = dr["rgv_action_type_description"].ToString();
                    item.rgv_action_type_ctr = Convert.ToInt32(dr["rgv_action_type_ctr"]);
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
        public int Insert(Document_route_logs item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocument_route_logs_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = item.document_id;
                command.Parameters.Add("@route_date", SqlDbType.VarChar).Value = item.route_date;
                command.Parameters.Add("@route_time", SqlDbType.VarChar).Value = item.route_time;
                command.Parameters.Add("@from_system_department_id", SqlDbType.Int).Value = item.from_system_department_id;
                command.Parameters.Add("@from_system_division_id", SqlDbType.Int).Value = item.from_system_division_id;
                command.Parameters.Add("@from_system_unit_id", SqlDbType.Int).Value = item.from_system_unit_id;
                command.Parameters.Add("@from_name", SqlDbType.VarChar).Value = item.from_name;
                command.Parameters.Add("@to_system_department_id", SqlDbType.Int).Value = item.to_system_department_id;
                command.Parameters.Add("@to_system_division_id", SqlDbType.Int).Value = item.to_system_division_id;
                command.Parameters.Add("@to_system_unit_id", SqlDbType.Int).Value = item.to_system_unit_id;
                command.Parameters.Add("@to_name", SqlDbType.VarChar).Value = item.to_name;
                command.Parameters.Add("@rgv_document_status_id", SqlDbType.Int).Value = item.rgv_document_status_id;
                command.Parameters.Add("@rgv_action_type_id", SqlDbType.Int).Value = item.rgv_action_type_id;
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
        public int Update(Document_route_logs item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocument_route_logs_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = item.document_id;
                command.Parameters.Add("@route_date", SqlDbType.Date).Value = item.route_date;
                command.Parameters.Add("@route_time", SqlDbType.Time).Value = item.route_time;
                command.Parameters.Add("@from_system_department_id", SqlDbType.Int).Value = item.from_system_department_id;
                command.Parameters.Add("@from_system_division_id", SqlDbType.Int).Value = item.from_system_division_id;
                command.Parameters.Add("@from_system_unit_id", SqlDbType.Int).Value = item.from_system_unit_id;
                command.Parameters.Add("@from_name", SqlDbType.VarChar).Value = item.from_name;
                command.Parameters.Add("@to_system_department_id", SqlDbType.Int).Value = item.to_system_department_id;
                command.Parameters.Add("@to_system_division_id", SqlDbType.Int).Value = item.to_system_division_id;
                command.Parameters.Add("@to_system_unit_id", SqlDbType.Int).Value = item.to_system_unit_id;
                command.Parameters.Add("@to_name", SqlDbType.VarChar).Value = item.to_name;
                command.Parameters.Add("@rgv_document_status_id", SqlDbType.Int).Value = item.rgv_document_status_id;
                command.Parameters.Add("@rgv_action_type_id", SqlDbType.Int).Value = item.rgv_action_type_id;
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
        public int Delete(Document_route_logs item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spDocument_route_logs_Delete", connection);
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
        public List<Document_route_logs> ListBy_DocumentID(int document_id)
        {
            List<Document_route_logs> list = new List<Document_route_logs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_route_logs_ListBy_DocumentID";
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = document_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Document_route_logs
                    {
                        id = Convert.ToInt32(dr["id"]),
                        document_id = Convert.ToInt32(dr["document_id"]),
                        route_date = Convert.ToDateTime(dr["route_date"]).ToString("MM-dd-yyyy"),
                        route_time = Convert.ToDateTime(dr["route_time"]).ToString("HH:mm"),
                        from_system_department_id = Convert.ToInt32(dr["from_system_department_id"]),
                        from_system_department_code = dr["from_system_department_code"].ToString(),
                        from_system_department_name = dr["from_system_department_name"].ToString(),
                        from_system_department_description = dr["from_system_department_description"].ToString(),
                        from_system_department_ctr = Convert.ToInt32(dr["from_system_department_ctr"]),
                        from_system_division_id = Convert.ToInt32(dr["from_system_division_id"]),
                        from_system_division_code = dr["from_system_division_code"].ToString(),
                        from_system_division_name = dr["from_system_division_name"].ToString(),
                        from_system_division_description = dr["from_system_division_description"].ToString(),
                        from_system_division_ctr = Convert.ToInt32(dr["from_system_division_ctr"]),
                        from_system_unit_id = Convert.ToInt32(dr["from_system_unit_id"]),
                        from_system_unit_code = dr["from_system_unit_code"].ToString(),
                        from_system_unit_name = dr["from_system_unit_name"].ToString(),
                        from_system_unit_description = dr["from_system_unit_description"].ToString(),
                        from_system_unit_ctr = Convert.ToInt32(dr["from_system_unit_ctr"]),
                        from_name = dr["from_name"].ToString(),
                        to_system_department_id = Convert.ToInt32(dr["to_system_department_id"]),
                        to_system_department_code = dr["to_system_department_code"].ToString(),
                        to_system_department_name = dr["to_system_department_name"].ToString(),
                        to_system_department_description = dr["to_system_department_description"].ToString(),
                        to_system_department_ctr = Convert.ToInt32(dr["to_system_department_ctr"]),
                        to_system_division_id = Convert.ToInt32(dr["to_system_division_id"]),
                        to_system_division_code = dr["to_system_division_code"].ToString(),
                        to_system_division_name = dr["to_system_division_name"].ToString(),
                        to_system_division_description = dr["to_system_division_description"].ToString(),
                        to_system_division_ctr = Convert.ToInt32(dr["to_system_division_ctr"]),
                        to_system_unit_id = Convert.ToInt32(dr["to_system_unit_id"]),
                        to_system_unit_code = dr["to_system_unit_code"].ToString(),
                        to_system_unit_name = dr["to_system_unit_name"].ToString(),
                        to_system_unit_description = dr["to_system_unit_description"].ToString(),
                        to_system_unit_ctr = Convert.ToInt32(dr["to_system_unit_ctr"]),
                        to_name = dr["to_name"].ToString(),
                        rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]),
                        rgv_document_status_code = dr["rgv_document_status_code"].ToString(),
                        rgv_document_status_name = dr["rgv_document_status_name"].ToString(),
                        rgv_document_status_description = dr["rgv_document_status_description"].ToString(),
                        rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]),
                        rgv_action_type_id = Convert.ToInt32(dr["rgv_action_type_id"]),
                        rgv_action_type_code = dr["rgv_action_type_code"].ToString(),
                        rgv_action_type_name = dr["rgv_action_type_name"].ToString(),
                        rgv_action_type_description = dr["rgv_action_type_description"].ToString(),
                        rgv_action_type_ctr = Convert.ToInt32(dr["rgv_action_type_ctr"]),
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

        public List<Document_route_logs> ListAll_DatesBy_DocumentID(int document_id)
        {
            List<Document_route_logs> list = new List<Document_route_logs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_route_logs_ListAll_DatesBy_DocumentID";
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = document_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Document_route_logs
                    {
                        route_date = dr["route_date"].ToString(),
                        sroute_date = dr["sroute_date"].ToString(),
                    });
                }
            }

            return list;
        }

        public List<Document_route_logs> ListBy_DocumentIDAndDate(int document_id, string datetime)
        {
            List<Document_route_logs> list = new List<Document_route_logs>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDocument_route_logs_ListBy_DocumentIDAndDate";
                command.Parameters.Add("@document_id", SqlDbType.Int).Value = document_id;
                command.Parameters.Add("@dt", SqlDbType.VarChar).Value = datetime;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                var rows = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new Document_route_logs
                    {
                        id = Convert.ToInt32(dr["id"]),
                        document_id = Convert.ToInt32(dr["document_id"]),
                        route_date = dr["route_date"].ToString(),
                        route_time = dr["route_time"].ToString(),
                        from_system_department_id = Convert.ToInt32(dr["from_system_department_id"]),
                        from_system_department_code = dr["from_system_department_code"].ToString(),
                        from_system_department_name = dr["from_system_department_name"].ToString(),
                        from_system_department_description = dr["from_system_department_description"].ToString(),
                        from_system_department_ctr = Convert.ToInt32(dr["from_system_department_ctr"]),
                        from_system_division_id = Convert.ToInt32(dr["from_system_division_id"]),
                        from_system_division_code = dr["from_system_division_code"].ToString(),
                        from_system_division_name = dr["from_system_division_name"].ToString(),
                        from_system_division_description = dr["from_system_division_description"].ToString(),
                        from_system_division_ctr = Convert.ToInt32(dr["from_system_division_ctr"]),
                        from_system_unit_id = Convert.ToInt32(dr["from_system_unit_id"]),
                        from_system_unit_code = dr["from_system_unit_code"].ToString(),
                        from_system_unit_name = dr["from_system_unit_name"].ToString(),
                        from_system_unit_description = dr["from_system_unit_description"].ToString(),
                        from_system_unit_ctr = Convert.ToInt32(dr["from_system_unit_ctr"]),
                        from_name = dr["from_name"].ToString(),
                        to_system_department_id = Convert.ToInt32(dr["to_system_department_id"]),
                        to_system_department_code = dr["to_system_department_code"].ToString(),
                        to_system_department_name = dr["to_system_department_name"].ToString(),
                        to_system_department_description = dr["to_system_department_description"].ToString(),
                        to_system_department_ctr = Convert.ToInt32(dr["to_system_department_ctr"]),
                        to_system_division_id = Convert.ToInt32(dr["to_system_division_id"]),
                        to_system_division_code = dr["to_system_division_code"].ToString(),
                        to_system_division_name = dr["to_system_division_name"].ToString(),
                        to_system_division_description = dr["to_system_division_description"].ToString(),
                        to_system_division_ctr = Convert.ToInt32(dr["to_system_division_ctr"]),
                        to_system_unit_id = Convert.ToInt32(dr["to_system_unit_id"]),
                        to_system_unit_code = dr["to_system_unit_code"].ToString(),
                        to_system_unit_name = dr["to_system_unit_name"].ToString(),
                        to_system_unit_description = dr["to_system_unit_description"].ToString(),
                        to_system_unit_ctr = Convert.ToInt32(dr["to_system_unit_ctr"]),
                        to_name = dr["to_name"].ToString(),
                        rgv_document_status_id = Convert.ToInt32(dr["rgv_document_status_id"]),
                        rgv_document_status_code = dr["rgv_document_status_code"].ToString(),
                        rgv_document_status_name = dr["rgv_document_status_name"].ToString(),
                        rgv_document_status_description = dr["rgv_document_status_description"].ToString(),
                        rgv_document_status_ctr = Convert.ToInt32(dr["rgv_document_status_ctr"]),
                        rgv_action_type_id = Convert.ToInt32(dr["rgv_action_type_id"]),
                        rgv_action_type_code = dr["rgv_action_type_code"].ToString(),
                        rgv_action_type_name = dr["rgv_action_type_name"].ToString(),
                        rgv_action_type_description = dr["rgv_action_type_description"].ToString(),
                        rgv_action_type_ctr = Convert.ToInt32(dr["rgv_action_type_ctr"]),
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
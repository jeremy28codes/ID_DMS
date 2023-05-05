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
    public class DBM_SystemUsers
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<System_users> ListAll()
        {
            List<System_users> list = new List<System_users>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_Users_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_users
                    {
                        id = Convert.ToInt32(dr["id"]),
                        reference_number = dr["reference_number"].ToString(),
                        username = dr["username"].ToString(),
                        prefix = dr["prefix"].ToString(),
                        first_name = dr["first_name"].ToString(),
                        middle_name = dr["middle_name"].ToString(),
                        last_name = dr["last_name"].ToString(),
                        suffix = dr["suffix"].ToString(),
                        rgv_sex_id = Convert.ToInt32(dr["rgv_sex_id"]),
                        rgv_sex_code = dr["sex_code"].ToString(),
                        rgv_sex_name = dr["sex_name"].ToString(),
                        rgv_sex_description = dr["sex_description"].ToString(),
                        about = dr["about"].ToString(),
                        department_id = Convert.ToInt32(dr["department_id"]),
                        department_code = dr["department_code"].ToString(),
                        department_name = dr["department_name"].ToString(),
                        department_description = dr["department_description"].ToString(),
                        division_id = Convert.ToInt32(dr["division_id"]),
                        division_code = dr["division_code"].ToString(),
                        division_name = dr["division_name"].ToString(),
                        division_description = dr["division_description"].ToString(),
                        unit_id = Convert.ToInt32(dr["unit_id"]),
                        unit_code = dr["unit_code"].ToString(),
                        unit_name = dr["unit_name"].ToString(),
                        unit_description = dr["unit_description"].ToString(),
                        section_id = Convert.ToInt32(dr["section_id"]),
                        section_code = dr["section_code"].ToString(),
                        section_name = dr["section_name"].ToString(),
                        section_description = dr["section_description"].ToString(),
                        job_title = dr["job_title"].ToString(),
                        address = dr["address"].ToString(),
                        mobile_number = dr["mobile_number"].ToString(),
                        email = dr["email"].ToString(),
                        twitter = dr["twitter"].ToString(),
                        facebook = dr["facebook"].ToString(),
                        instagram = dr["instagram"].ToString(),
                        linked_in = dr["linked_in"].ToString(),
                        pic_img_path = dr["pic_img_path"].ToString(),
                        sig_img_path = dr["sig_img_path"].ToString(),
                        qr_img_path = dr["qr_img_path"].ToString(),
                        qr_code = dr["qr_code"].ToString(),
                        biometric_number = dr["biometric_number"].ToString(),
                        login_attempt = Convert.ToInt32(dr["login_attempt"]),
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
        public System_users GetBy_ID(int id)
        {
            System_users item = new System_users();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_Users_GetBy_ID";
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
                    item.username = dr["username"].ToString();
                    item.password = dr["password"].ToString();
                    item.prefix = dr["prefix"].ToString();
                    item.first_name = dr["first_name"].ToString();
                    item.middle_name = dr["middle_name"].ToString();
                    item.last_name = dr["last_name"].ToString();
                    item.suffix = dr["suffix"].ToString();
                    item.rgv_sex_id = Convert.ToInt32(dr["rgv_sex_id"]);
                    item.rgv_sex_code = dr["sex_code"].ToString();
                    item.rgv_sex_name = dr["sex_name"].ToString();
                    item.rgv_sex_description = dr["sex_description"].ToString();
                    item.about = dr["about"].ToString();
                    item.department_id = Convert.ToInt32(dr["department_id"]);
                    item.department_code = dr["department_code"].ToString();
                    item.department_name = dr["department_name"].ToString();
                    item.department_description = dr["department_description"].ToString();
                    item.division_id = Convert.ToInt32(dr["division_id"]);
                    item.division_code = dr["division_code"].ToString();
                    item.division_name = dr["division_name"].ToString();
                    item.division_description = dr["division_description"].ToString();
                    item.unit_id = Convert.ToInt32(dr["unit_id"]);
                    item.unit_code = dr["unit_code"].ToString();
                    item.unit_name = dr["unit_name"].ToString();
                    item.unit_description = dr["unit_description"].ToString();
                    item.section_id = Convert.ToInt32(dr["section_id"]);
                    item.section_code = dr["section_code"].ToString();
                    item.section_name = dr["section_name"].ToString();
                    item.section_description = dr["section_description"].ToString();
                    item.job_title = dr["job_title"].ToString();
                    item.address = dr["address"].ToString();
                    item.mobile_number = dr["mobile_number"].ToString();
                    item.email = dr["email"].ToString();
                    item.twitter = dr["twitter"].ToString();
                    item.facebook = dr["facebook"].ToString();
                    item.instagram = dr["instagram"].ToString();
                    item.linked_in = dr["linked_in"].ToString();
                    item.pic_img_path = dr["pic_img_path"].ToString();
                    item.sig_img_path = dr["sig_img_path"].ToString();
                    item.qr_img_path = dr["qr_img_path"].ToString();
                    item.qr_code = dr["qr_code"].ToString();
                    item.biometric_number = dr["biometric_number"].ToString();
                    item.login_attempt = Convert.ToInt32(dr["login_attempt"]);
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
        public int Insert(System_users item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_Users_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@reference_number", SqlDbType.VarChar).Value = item.reference_number;
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = item.username;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = item.password;
                command.Parameters.Add("@prefix", SqlDbType.VarChar).Value = item.prefix;
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = item.first_name;
                command.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = item.middle_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = item.last_name;
                command.Parameters.Add("@suffix", SqlDbType.VarChar).Value = item.suffix;
                command.Parameters.Add("@rgv_sex_id", SqlDbType.Int).Value = item.rgv_sex_id;
                command.Parameters.Add("@about", SqlDbType.VarChar).Value = item.about;
                command.Parameters.Add("@department_id", SqlDbType.Int).Value = item.department_id;
                command.Parameters.Add("@division_id", SqlDbType.Int).Value = item.division_id;
                command.Parameters.Add("@unit_id", SqlDbType.Int).Value = item.unit_id;
                command.Parameters.Add("@section_id", SqlDbType.Int).Value = item.section_id;
                command.Parameters.Add("@job_title", SqlDbType.VarChar).Value = item.job_title;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = item.address;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@twitter", SqlDbType.VarChar).Value = item.twitter;
                command.Parameters.Add("@facebook", SqlDbType.VarChar).Value = item.facebook;
                command.Parameters.Add("@instagram", SqlDbType.VarChar).Value = item.instagram;
                command.Parameters.Add("@linked_in", SqlDbType.VarChar).Value = item.linked_in;
                command.Parameters.Add("@pic_img_path", SqlDbType.VarChar).Value = item.pic_img_path;
                command.Parameters.Add("@sig_img_path", SqlDbType.VarChar).Value = item.sig_img_path;
                command.Parameters.Add("@qr_img_path", SqlDbType.VarChar).Value = item.qr_img_path;
                command.Parameters.Add("@qr_code", SqlDbType.VarChar).Value = item.qr_code;
                command.Parameters.Add("@biometric_number", SqlDbType.VarChar).Value = item.biometric_number;
                command.Parameters.Add("@login_attempt", SqlDbType.Int).Value = item.login_attempt;
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
        public int Update(System_users item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_Users_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@reference_number", SqlDbType.VarChar).Value = item.reference_number;
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = item.username;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = item.password;
                command.Parameters.Add("@prefix", SqlDbType.VarChar).Value = item.prefix;
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = item.first_name;
                command.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = item.middle_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = item.last_name;
                command.Parameters.Add("@suffix", SqlDbType.VarChar).Value = item.suffix;
                command.Parameters.Add("@rgv_sex_id", SqlDbType.Int).Value = item.rgv_sex_id;
                command.Parameters.Add("@about", SqlDbType.VarChar).Value = item.about;
                command.Parameters.Add("@department_id", SqlDbType.Int).Value = item.department_id;
                command.Parameters.Add("@division_id", SqlDbType.Int).Value = item.division_id;
                command.Parameters.Add("@unit_id", SqlDbType.Int).Value = item.unit_id;
                command.Parameters.Add("@section_id", SqlDbType.Int).Value = item.section_id;
                command.Parameters.Add("@job_title", SqlDbType.VarChar).Value = item.job_title;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = item.address;
                command.Parameters.Add("@mobile_number", SqlDbType.VarChar).Value = item.mobile_number;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = item.email;
                command.Parameters.Add("@twitter", SqlDbType.VarChar).Value = item.twitter;
                command.Parameters.Add("@facebook", SqlDbType.VarChar).Value = item.facebook;
                command.Parameters.Add("@instagram", SqlDbType.VarChar).Value = item.instagram;
                command.Parameters.Add("@linked_in", SqlDbType.VarChar).Value = item.linked_in;
                command.Parameters.Add("@pic_img_path", SqlDbType.VarChar).Value = item.pic_img_path;
                command.Parameters.Add("@sig_img_path", SqlDbType.VarChar).Value = item.sig_img_path;
                command.Parameters.Add("@qr_img_path", SqlDbType.VarChar).Value = item.qr_img_path;
                command.Parameters.Add("@qr_code", SqlDbType.VarChar).Value = item.qr_code;
                command.Parameters.Add("@biometric_number", SqlDbType.VarChar).Value = item.biometric_number;
                command.Parameters.Add("@login_attempt", SqlDbType.Int).Value = item.login_attempt;
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
        public int Delete(System_users item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_Users_Delete", connection);
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
        //GET BY Username & Password
        public System_users GetBy_Username_Password(string username, string password)
        {
            System_users item = new System_users();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_Users_GetBy_Username_Password";
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.reference_number = dr["reference_number"].ToString();
                    item.username = dr["username"].ToString();
                    item.prefix = dr["prefix"].ToString();
                    item.first_name = dr["first_name"].ToString();
                    item.middle_name = dr["middle_name"].ToString();
                    item.last_name = dr["last_name"].ToString();
                    item.suffix = dr["suffix"].ToString();
                    item.rgv_sex_id = Convert.ToInt32(dr["rgv_sex_id"]);
                    item.rgv_sex_code = dr["sex_code"].ToString();
                    item.rgv_sex_name = dr["sex_name"].ToString();
                    item.rgv_sex_description = dr["sex_description"].ToString();
                    item.about = dr["about"].ToString();
                    item.department_id = Convert.ToInt32(dr["department_id"]);
                    item.department_code = dr["department_code"].ToString();
                    item.department_name = dr["department_name"].ToString();
                    item.department_description = dr["department_description"].ToString();
                    item.division_id = Convert.ToInt32(dr["division_id"]);
                    item.division_code = dr["division_code"].ToString();
                    item.division_name = dr["division_name"].ToString();
                    item.division_description = dr["division_description"].ToString();
                    item.unit_id = Convert.ToInt32(dr["unit_id"]);
                    item.unit_code = dr["unit_code"].ToString();
                    item.unit_name = dr["unit_name"].ToString();
                    item.unit_description = dr["unit_description"].ToString();
                    item.section_id = Convert.ToInt32(dr["section_id"]);
                    item.section_code = dr["section_code"].ToString();
                    item.section_name = dr["section_name"].ToString();
                    item.section_description = dr["section_description"].ToString();
                    item.job_title = dr["job_title"].ToString();
                    item.address = dr["address"].ToString();
                    item.mobile_number = dr["mobile_number"].ToString();
                    item.email = dr["email"].ToString();
                    item.twitter = dr["twitter"].ToString();
                    item.facebook = dr["facebook"].ToString();
                    item.instagram = dr["instagram"].ToString();
                    item.linked_in = dr["linked_in"].ToString();
                    item.pic_img_path = dr["pic_img_path"].ToString();
                    item.sig_img_path = dr["sig_img_path"].ToString();
                    item.qr_img_path = dr["qr_img_path"].ToString();
                    item.qr_code = dr["qr_code"].ToString();
                    item.biometric_number = dr["biometric_number"].ToString();
                    item.login_attempt = Convert.ToInt32(dr["login_attempt"]);
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

        public List<System_users> ListBy_DepartmentDivisionID(int system_department_id, int system_division_id)
        {
            List<System_users> list = new List<System_users>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_Users_ListBy_DepartmentDivisionID";
                command.Parameters.Add("@system_department_id", SqlDbType.Int).Value = system_department_id;
                command.Parameters.Add("@system_division_id", SqlDbType.Int).Value = system_division_id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_users
                    {
                        id = Convert.ToInt32(dr["id"]),
                        reference_number = dr["reference_number"].ToString(),
                        username = dr["username"].ToString(),
                        prefix = dr["prefix"].ToString(),
                        first_name = dr["first_name"].ToString(),
                        middle_name = dr["middle_name"].ToString(),
                        last_name = dr["last_name"].ToString(),
                        suffix = dr["suffix"].ToString(),
                        rgv_sex_id = Convert.ToInt32(dr["rgv_sex_id"]),
                        rgv_sex_code = dr["sex_code"].ToString(),
                        rgv_sex_name = dr["sex_name"].ToString(),
                        rgv_sex_description = dr["sex_description"].ToString(),
                        about = dr["about"].ToString(),
                        department_id = Convert.ToInt32(dr["department_id"]),
                        department_code = dr["department_code"].ToString(),
                        department_name = dr["department_name"].ToString(),
                        department_description = dr["department_description"].ToString(),
                        division_id = Convert.ToInt32(dr["division_id"]),
                        division_code = dr["division_code"].ToString(),
                        division_name = dr["division_name"].ToString(),
                        division_description = dr["division_description"].ToString(),
                        unit_id = Convert.ToInt32(dr["unit_id"]),
                        unit_code = dr["unit_code"].ToString(),
                        unit_name = dr["unit_name"].ToString(),
                        unit_description = dr["unit_description"].ToString(),
                        section_id = Convert.ToInt32(dr["section_id"]),
                        section_code = dr["section_code"].ToString(),
                        section_name = dr["section_name"].ToString(),
                        section_description = dr["section_description"].ToString(),
                        job_title = dr["job_title"].ToString(),
                        address = dr["address"].ToString(),
                        mobile_number = dr["mobile_number"].ToString(),
                        email = dr["email"].ToString(),
                        twitter = dr["twitter"].ToString(),
                        facebook = dr["facebook"].ToString(),
                        instagram = dr["instagram"].ToString(),
                        linked_in = dr["linked_in"].ToString(),
                        pic_img_path = dr["pic_img_path"].ToString(),
                        sig_img_path = dr["sig_img_path"].ToString(),
                        qr_img_path = dr["qr_img_path"].ToString(),
                        qr_code = dr["qr_code"].ToString(),
                        biometric_number = dr["biometric_number"].ToString(),
                        login_attempt = Convert.ToInt32(dr["login_attempt"]),
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

        public int Update_Profile(System_users item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_Users_Update_Profile", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@reference_number", SqlDbType.VarChar).Value = item.reference_number;
                command.Parameters.Add("@prefix", SqlDbType.VarChar).Value = item.prefix;
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = item.first_name;
                command.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = item.middle_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = item.last_name;
                command.Parameters.Add("@suffix", SqlDbType.VarChar).Value = item.suffix;
                command.Parameters.Add("@rgv_sex_id", SqlDbType.Int).Value = item.rgv_sex_id;
                command.Parameters.Add("@about", SqlDbType.VarChar).Value = item.about;
                command.Parameters.Add("@department_id", SqlDbType.Int).Value = item.department_id;
                command.Parameters.Add("@division_id", SqlDbType.Int).Value = item.division_id;
                command.Parameters.Add("@unit_id", SqlDbType.Int).Value = item.unit_id;
                command.Parameters.Add("@job_title", SqlDbType.VarChar).Value = item.job_title;
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

        public int Update_Photo(System_users item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_Users_Update_Photo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@pic_img_path", SqlDbType.VarChar).Value = item.pic_img_path;

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

        public int Update_UsernamePassword(System_users item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_Users_Update_UsernamePassword", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = item.username;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = item.password;
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
        #endregion
    }
}
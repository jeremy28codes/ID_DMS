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
    public class DBM_SystemReferenceCountries
    {
        string sConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();

        #region Basic Crud Functions
        //GET ALL
        public List<System_reference_countries> ListAll()
        {
            List<System_reference_countries> list = new List<System_reference_countries>();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_reference_countries_ListAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    list.Add(new System_reference_countries
                    {
                        id = Convert.ToInt32(dr["id"]),
                        code = dr["code"].ToString(),
                        name = dr["name"].ToString(),
                        description = dr["description"].ToString(),
                        citizenship = dr["citizenship"].ToString(),
                        capital = dr["capital"].ToString(),
                        population = dr["population"].ToString(),
                        population_year = dr["population_year"].ToString(),
                        kilometer_area = dr["kilometer_area"].ToString(),
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
        public System_reference_countries GetBy_ID(int id)
        {
            System_reference_countries item = new System_reference_countries();

            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSystem_reference_countries_GetBy_ID";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                sqlDA.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    item.id = Convert.ToInt32(dr["id"]);
                    item.code = dr["code"].ToString();
                    item.name = dr["name"].ToString();
                    item.description = dr["description"].ToString();
                    item.citizenship = dr["citizenship"].ToString();
                    item.capital = dr["capital"].ToString();
                    item.population = dr["population"].ToString();
                    item.population_year = dr["population_year"].ToString();
                    item.kilometer_area = dr["kilometer_area"].ToString();
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
        public int Insert(System_reference_countries item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_reference_countries_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
                command.Parameters.Add("@citizenship", SqlDbType.NVarChar).Value = item.citizenship;
                command.Parameters.Add("@capital", SqlDbType.NVarChar).Value = item.capital;
                command.Parameters.Add("@population", SqlDbType.NVarChar).Value = item.population;
                command.Parameters.Add("@population_year", SqlDbType.NVarChar).Value = item.population_year;
                command.Parameters.Add("@kilometer_area", SqlDbType.NVarChar).Value = item.kilometer_area;
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
        public int Update(System_reference_countries item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_reference_countries_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                command.Parameters.Add("@code", SqlDbType.VarChar).Value = item.code;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.name;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = item.description;
                command.Parameters.Add("@citizenship", SqlDbType.NVarChar).Value = item.citizenship;
                command.Parameters.Add("@capital", SqlDbType.NVarChar).Value = item.capital;
                command.Parameters.Add("@population", SqlDbType.NVarChar).Value = item.population;
                command.Parameters.Add("@population_year", SqlDbType.NVarChar).Value = item.population_year;
                command.Parameters.Add("@kilometer_area", SqlDbType.NVarChar).Value = item.kilometer_area;
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
        public int Delete(System_reference_countries item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(sConnectionString))
            {
                SqlCommand command = new SqlCommand("spSystem_reference_countries_Delete", connection);
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
        
    }
}
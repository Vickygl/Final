using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBaseConnection
{
  public  class DBConnection
    {
        static String cons = @"Data Source=RILPT030;Initial Catalog=boutique;User ID=sa;Password=sa123";

        public void AddNewClothes(Clothings clothings)
        {
            using (SqlConnection con = new SqlConnection(cons))
            {
                var query = "INSERT INTO clothings VALUES(@clothid,clothname,@clothsize,@clothbrand,@clothprice)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@clothid", clothings.CId);
                cmd.Parameters.AddWithValue("@clothname", clothings.CName);
                cmd.Parameters.AddWithValue("@clothsize", clothings.CSize);
                cmd.Parameters.AddWithValue("@clothbrand", clothings.CBrand);
                cmd.Parameters.AddWithValue("@clothprice", clothings.CPrice);
                try
                {
                    con.Open();
                    int C = cmd.ExecuteNonQuery();
                    if (C == 0)
                        throw new Exception("entries not added");
                }
                catch (Exception)
                {
                    throw;

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void UpdateClothes(Clothings clothings)
        {
            using (SqlConnection con = new SqlConnection(cons))
            {
                var query = $"UPDATE clothings SET clothid ='{clothings.CId}, clothname = '{clothings.CName},clothsize ='{clothings.CSize}, clothbrand = '{clothings.CBrand}, clothprice = '{clothings.CPrice}' WHERE clothid = {clothings.CId}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int C = cmd.ExecuteNonQuery();
                    if (C == 0)
                        throw new Exception("no enttries were updated");

                }
                catch (Exception  ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
               
            }
        }

        public void DeleteClothes(int id)
        {
            Clothings clothings = new Clothings();
            using (SqlConnection con = new SqlConnection(cons))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM clothings WHERE clothid = " + id;
                    int C = cmd.ExecuteNonQuery();
                    if (C == 0)
                        throw new Exception("entries are not deleted");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public List<Clothings> GetAllClothes()
        {
            var list = new List<Clothings>();
            using (SqlConnection con = new SqlConnection(cons))
            {
                try
                {
                    var query = "SELECT * FROM clothings";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var cloth = new Clothings();
                        cloth.CId = Convert.ToInt32(reader[0]);
                        cloth.CName = reader[1].ToString();
                        cloth.CSize = reader[2].ToString();
                        cloth.CBrand = reader[3].ToString();
                        cloth.CSize = reader[4].ToString();
                        list.Add(cloth);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }

    }
}

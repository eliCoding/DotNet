using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPeopleDBEli
{
    class Database
    {
        SqlConnection conn;
        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=I:\Elmira\Winter Semester\DotNet\C#\LocalPeopleDBEli\PeopleDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

        }

        public void AddPerson(Person p)
        {

            string sql = "INSERT INTO people(Name, Age) VALUES(@NAME,@AGE)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = p.Name;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = p.Age;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        public List<Person> GetAllPeople()
        {

            List<Person> result = new List<Person>();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM people", conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];
                    Person p = new Person(id, name, age);
                    result.Add(p);
                }
                return result;
            }
        }
    }
}

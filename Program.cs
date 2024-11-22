using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTeam
{
    internal class Program
    {
        public static Connect conn = new Connect();
        public static void SoccerTeam()
        {
            conn.Connection.Open();

            string sql = "SELECT * FROM `player`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            do
            {
                var player = new
                {
                    Id = dr.GetInt32(0),
                    Name = dr.GetString(1),
                    Height = dr.GetInt32(2),
                    Weight = dr.GetInt32(3),
                    Age = dr.GetInt32(4),
                    CreatedTime = dr.GetDateTime(5)

                };

                Console.WriteLine($"Játékos adatok: {player.Name},{player.Height},{player.Weight}, {player.Age}");
            }
            while (dr.Read());



            dr.Close();



            conn.Connection.Close();
        }



        static void Main(string[] args)
        {
            SoccerTeam();
        }
    }
}

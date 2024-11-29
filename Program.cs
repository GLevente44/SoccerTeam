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
                var football = new
                {
                    Id = dr.GetInt32(0),
                    Name = dr.GetString(1),
                    Height = dr.GetInt32(2),
                    Weight = dr.GetInt32(3),

                };

                Console.WriteLine($"Játékos adatok: {football.Name},{football.Height},{football.Weight}");
            }
            while (dr.Read());



            dr.Close();



            conn.Connection.Close();
        }

        public static void AddNewPlayer(string name, int height, int weight)
        {
            try
            {
                conn.Connection.Open();

                string sql = $"INSERT INTO `player`(`Name`, `Height`, `Weight`) VALUES ('{name}',{height},{weight})";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
                cmd.ExecuteNonQuery();

                conn.Connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void DeletePlayer(int id)
        {
            conn.Connection.Open();

            string sql = "DELETE FROM `player` WHERE `Id` = {id};";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.ExecuteNonQuery();


            conn.Connection.Open();
        }

        public static void UpdatePlayer(int id, string name, int weight, int height)
        {
            conn.Connection.Open();


            string sql = $"UPDATE `player` SET `Name`='{name}',`Height`={height},`Weight`= {weight} WHERE `Id` = {id};";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();
        }


        static void Main(string[] args)
        {
            
            SoccerTeam();

            //try
            //{
            //    Console.Write("Kérem a játékos azonosítót: ");
            //    int id = int.Parse(Console.ReadLine());
            //    Console.Write("Kérem az új nevet: ");
            //    string name = Console.ReadLine();
            //    Console.Write("Kérem az új magasságot: ");
            //    int height = int.Parse(Console.ReadLine());
            //    Console.Write("Kérem az új súlyt: ");
            //    int weight = int.Parse(Console.ReadLine());


            //    UpdatePlayer(id, name, height, weight);
            //    Console.WriteLine("Sikeres frissítés!");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}



            //try
            //{
            //    Console.WriteLine("Kérem a játékos azonosítóját a törléshez: ");
            //    int id = int.Parse(Console.ReadLine());
            //    DeletePlayer(id);
            //    Console.WriteLine("Sikeres törlés");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}




            try
            {
                Console.Write("Kérem a játékos nevét: ");
                string name = Console.ReadLine();
                Console.Write("Kérem a játékos magasságát: ");
                int height = int.Parse(Console.ReadLine());
                Console.Write("Kérem a játékos súlyát: ");
                int weight = int.Parse(Console.ReadLine());

                AddNewPlayer(name, height, weight);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

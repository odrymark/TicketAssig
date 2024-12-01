using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TicketAssig.DAL
{
    public class EventCreator
    {
        private string sqlString = "datasource=127.0.0.1; port=3306; username=root; password=; database=ticketsystem";

        public string createEvent(string name, string date, string ticketNum, string location, string type, string price, string desc)
        {
            int id = 0;
            string[] split = date.Split(',');
            DateTime dateT = DateTime.ParseExact(split[0], "yyyy. MMMM dd.", new CultureInfo("hu-HU"));
            string goodDate = dateT.ToString("yyyy-MM-dd");

            using MySqlConnection sqlCon = new MySqlConnection(sqlString);

            try
            {
                sqlCon.Open();

                MySqlCommand idCmd = new MySqlCommand("SELECT MAX(eventid) FROM events", sqlCon);

                MySqlDataReader reader = idCmd.ExecuteReader();
                    
                if(reader.HasRows)
                {
                    reader.Read();
                    id = reader.GetInt32(0) + 1;
                }
                else
                {
                    id = 0;
                }
                reader.Close();

                MySqlCommand cmd = new MySqlCommand($"INSERT INTO events(eventid, name, date, numberoftickets, location, type, price, description) VALUES ({id}, \"{name}\", \"{goodDate}\", {ticketNum}, \"{location}\", \"{type}\", {price}, \"{desc}\")", sqlCon);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return e.Message;
            }

            return "Event created";
        }
    }
}
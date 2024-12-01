using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TicketAssig.DAL
{
    public class RetrieveTickets
    {
        private string sqlString = "datasource=127.0.0.1; port=3306; username=root; password=; database=ticketsystem";

        public List<ListViewItem> getTicketList(int userID)
        {
            List<ListViewItem> items = new();
            MySqlConnection sqlCon = new MySqlConnection(sqlString);
            MySqlCommand cmd = new MySqlCommand("SELECT (SELECT name FROM events WHERE events.eventid = tickets.eventid), amount FROM tickets WHERE userid = @userID;", sqlCon);
            cmd.Parameters.AddWithValue("@userID", userID);

            try
            {
                sqlCon.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        items.Add(new ListViewItem([reader.GetString(0), reader.GetInt32(1).ToString()]));
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return items;
        }
    }
}
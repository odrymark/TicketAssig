using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TicketAssig.DAL
{
    public class RetrieveEvents
    {
        private string sqlString = "datasource=127.0.0.1; port=3306; username=root; password=; database=ticketsystem";

        public List<ListViewItem> getEventList()
        {
            using MySqlConnection sqlCon = new MySqlConnection(sqlString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM events;", sqlCon);
            List<ListViewItem> items = new();

            try
            {
                sqlCon.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        items.Add(new ListViewItem([reader.GetString(1), reader.GetDateTime(2).ToString(), reader.GetInt32(3).ToString(), reader.GetString(4), reader.GetString(5), reader.GetInt32(6).ToString(), reader.GetString(7)]));
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
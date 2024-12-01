using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TicketAssig.DAL
{
    public class TicketAdder
    {
        private string sqlString = "datasource=127.0.0.1; port=3306; username=root; password=; database=ticketsystem";

        public string ticketBuying(string eventName, int ticketAmount, int userID)
        {
            using MySqlConnection sqlCon = new MySqlConnection(sqlString);
            MySqlCommand idCmd = new MySqlCommand("SELECT eventid FROM events WHERE name = @eventName;", sqlCon);
            idCmd.Parameters.AddWithValue("@eventName", eventName);

            try
            {
                sqlCon.Open();
                MySqlDataReader reader = idCmd.ExecuteReader();
                reader.Read();
                int eventid = reader.GetInt32(0);
                reader.Close();

                MySqlCommand decreaseCmd = new MySqlCommand("UPDATE events SET numberoftickets = numberoftickets - @tickets WHERE eventid = @eventid", sqlCon);
                decreaseCmd.Parameters.AddWithValue("@eventid", eventid);
                decreaseCmd.Parameters.AddWithValue("@tickets", ticketAmount);
                decreaseCmd.ExecuteNonQuery();

                MySqlCommand addTicket = new MySqlCommand("INSERT INTO tickets(userid, eventid, amount) VALUES(@userID, @eventID, @ticketAmount)", sqlCon);
                addTicket.Parameters.AddWithValue("@userID", userID);
                addTicket.Parameters.AddWithValue("@eventID", eventid);
                addTicket.Parameters.AddWithValue("@ticketAmount", ticketAmount);
                addTicket.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return e.Message;
            }

            return "Tickets bought successfully";
        }
    }
}
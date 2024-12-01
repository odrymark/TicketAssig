using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TicketAssig.DAL
{
    public class AdminCommand
    {
        private string sqlString = "datasource=127.0.0.1; port=3306; username=root; password=; database=ticketsystem";

        public string retrieveData(string input)
        {
            using MySqlConnection sqlCon = new(sqlString);
            MySqlCommand cmd = new MySqlCommand(input, sqlCon);
            string output = ""+Environment.NewLine;

            try
            {
                sqlCon.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < reader.FieldCount; i++)
                        {
                            if(reader.GetFieldType(i) == typeof(int))
                            {
                                output += reader.GetInt32(i).ToString();
                            }
                            else if(reader.GetFieldType(i) == typeof(string))
                            {
                                output += reader.GetString(i);
                            }
                            else if(reader.GetFieldType(i) == typeof(DateTime))
                            {
                                output += reader.GetDateTime(i).ToString();
                            }
                            else
                            {
                                output += "Unknown";
                            }

                            output += " ";
                        }

                        output += Environment.NewLine;
                    }
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }

            return output;
        }

        public string updateData(string input)
        {
            using MySqlConnection sqlCon = new(sqlString);
            MySqlCommand cmd = new MySqlCommand(input, sqlCon);

            try
            {
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return e.Message;
            }

            return Environment.NewLine + "Command successful";
        }
    }
}
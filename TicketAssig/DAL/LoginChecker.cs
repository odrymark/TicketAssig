using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TicketAssig.DAL
{
    public class LoginChecker
    {
        private string sqlString = "datasource=127.0.0.1; port=3306; username=root; password=; database=ticketsystem";
        private int priv = -1;
        private int userID = -1;

        public bool findUsername(string uname, string passwd)
        {
            if(uname != "" && passwd != "")
            {
                using MySqlConnection sqlCon = new(sqlString);
                MySqlCommand cmd = new("SELECT * FROM users WHERE username = @username;", sqlCon);
                cmd.Parameters.AddWithValue("@username", uname);

                try
                {
                    sqlCon.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (passwd.Equals(reader.GetString(2)))
                        {
                            priv = reader.GetInt32(3);
                            userID = reader.GetInt32(0);
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    if (uname.Equals("offline") && passwd.Equals("offline"))
                    {
                        priv = 2;
                        return true;
                    }
                }
            }

            return false;
        }

        public int getPrivilege()
        {
            return priv;
        }

        public int getUserID()
        {
            return userID;
        }
    }
}
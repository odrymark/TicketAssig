using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.DAL;

namespace TicketAssig.BLL
{
    public class DatabaseExecuter
    {
        private LoginChecker loginCheck = new();
        private AdminCommand adminCmd = new();
        private EventCreator eventCreate = new();
        private RetrieveEvents retEvents = new();
        private TicketAdder ticketAdd = new();
        private RetrieveTickets retTickets = new();
        private int priv = -1;
        private int userID = -1;

        public bool authenticationExecuter(string uname, string passwd)
        {
            if(loginCheck.findUsername(uname, passwd))
            {
                priv = loginCheck.getPrivilege();
                userID = loginCheck.getUserID();
            }

            return loginCheck.findUsername(uname, passwd);
        }

        public string commandExecuter(string input, bool isRetrieve)
        {
            if(isRetrieve)
            {
                return adminCmd.retrieveData(input);
            }
            else
            {
                return adminCmd.updateData(input);
            }
        }

        public string createEventExecuter(string name, string date, string ticketNum, string location, string type, string price, string desc)
        {
            return eventCreate.createEvent(name, date, ticketNum, location, type, price, desc);
        }

        public List<ListViewItem> retrieveEventsExecuter()
        {
            return retEvents.getEventList();
        }

        public List<ListViewItem> retrieveTicketsExecuter()
        {
            return retTickets.getTicketList(userID);
        }

        public string addTicketExecuter(string eventName, int ticketAmount)
        {
            return ticketAdd.ticketBuying(eventName, ticketAmount, userID);
        }

        public int getUserPriv()
        {
            return priv;
        }
    }
}
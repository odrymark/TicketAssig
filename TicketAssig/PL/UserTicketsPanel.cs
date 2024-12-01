using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.BLL;

namespace TicketAssig.PL
{
    public class UserTicketsPanel
    {
        private PanelController controller;
        private DatabaseExecuter executer;
        private Panel userTickP = new();
        private ListView tickets = new();
        private Button back = new();

        public UserTicketsPanel(PanelController controller, DatabaseExecuter executer)
        {
            this.controller = controller;
            this.executer = executer;

            Initialize();
        }

        private void Initialize()
        {
            tickets.Bounds = new Rectangle(new Point(55, 60), new Size(270, 270));
            tickets.View = View.Details;
            tickets.Columns.AddRange([new ColumnHeader {Text = "Event Name", Width = 150}, new ColumnHeader {Text = "Amount", Width = 115}]);
            refreshTickets();

            back.Bounds = new Rectangle(new Point(10, 10), new Size(50, 30));
            back.Text = "Back";
            back.Click += (o, s) => {controller.switchToMenu(""); refreshTickets();};

            userTickP.Bounds = new Rectangle(new Point(0, 0), new Size(400, 400));
            userTickP.Controls.AddRange([tickets, back]);
        }
        
        private void refreshTickets()
        {
            tickets.Items.Clear();
            List<ListViewItem> items = executer.retrieveTicketsExecuter();

            foreach(ListViewItem item in items)
            {
                tickets.Items.Add(item);
            }
        }

        public Panel getPanel()
        {
            return userTickP;
        }
    }
}
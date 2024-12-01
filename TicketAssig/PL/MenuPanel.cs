using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TicketAssig.BLL;

namespace TicketAssig.PL
{
    public class MenuPanel
    {
        private PanelController controller;
        private int priv = 0;
        private Panel menuPanel = new();
        private Label name = new();
        private Button btn = new();
        private Button myTickets = new();

        public MenuPanel(PanelController controller, string name, int priv)
        {
            this.controller = controller;
            this.priv = priv;
            this.name.Text = name;
            Initialize();
        }

        private void Initialize()
        {
            name.Bounds = new Rectangle(new Point(280, 20), new Size(100, 30));
            name.TextAlign = ContentAlignment.MiddleCenter;
            
            btn.Bounds = new Rectangle(new Point(140, 250), new Size(100, 50));
            switch(priv)
            {
                
                case 0:
                    btn.Text = "Buy Tickets";
                    btn.Bounds = new Rectangle(new Point(140, 200), new Size(100, 50));
                    btn.Click += (o, s) => {controller.switchToTickets();};

                    myTickets.Text = "My Tickets";
                    myTickets.Bounds = new Rectangle(new Point(140, 280), new Size(100, 50));
                    myTickets.Click += (o, s) => {controller.switchToMyTickets();};

                    menuPanel.Controls.Add(myTickets);
                    break;
                case 1:
                    btn.Text = "Create Event";
                    btn.Click += (o, s) => {controller.switchToCreator();};
                    break;
                case 2:
                    btn.Text = "Admin Commands";
                    btn.Click += (o, s) => {controller.switchToAdmin();};
                    break;
                default:
                    btn.Text = "ERROR";
                    break;
            }
            
            menuPanel.Bounds = new Rectangle(new Point(0, 0), new Size(400, 400));
            menuPanel.Controls.AddRange([name, btn]);
        }

        public Panel getPanel()
        {
            return menuPanel;
        }
    }
}
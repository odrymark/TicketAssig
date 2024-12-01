using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.PL;

namespace TicketAssig.BLL
{
    public class PanelController
    {
        private MainForm mainF;
        private DatabaseExecuter executer;
        private LoginPanel loginP;
        private MenuPanel menuP;
        private AdminPanel adminP;
        private CreatorPanel creatorP;
        private TicketsPanel ticketsP;
        private UserTicketsPanel userTicP;

        public PanelController()
        {
            mainF = new();
            executer = new();
            loginP = new(this, executer);

            mainF.getForm().Controls.Add(loginP.getPanel());
        }

        public void switchToMenu(string name)
        {
            if(menuP == null)
            {
                mainF.getForm().Controls.Clear();
                menuP = new(this, name, executer.getUserPriv());
                mainF.getForm().Controls.Add(menuP.getPanel());
            }
            else
            {
                adminP?.getPanel().Hide();
                creatorP?.getPanel().Hide();
                ticketsP?.getPanel().Hide();
                userTicP?.getPanel().Hide();
                menuP.getPanel().Show();
            }
        }

        public void switchToAdmin()
        {
            if(adminP == null)
            {
                adminP = new(this, executer);
                menuP.getPanel().Hide();
                mainF.getForm().Controls.Add(adminP.getPanel());
            }
            else
            {
                menuP.getPanel().Hide();
                adminP.getPanel().Show();
            }
        }

        public void switchToCreator()
        {
            if(creatorP == null)
            {
                creatorP = new(this, executer);
                menuP.getPanel().Hide();
                mainF.getForm().Controls.Add(creatorP.getPanel());
            }
            else
            {
                menuP.getPanel().Hide();
                creatorP.getPanel().Show();
            }
        }

        public void switchToTickets()
        {
            if(ticketsP == null)
            {
                ticketsP = new(this, executer);
                menuP.getPanel().Hide();
                mainF.getForm().Controls.Add(ticketsP.getPanel());
            }
            else
            {
                menuP.getPanel().Hide();
                ticketsP.getPanel().Show();
            }
        }

        public void switchToMyTickets()
        {
            if(userTicP == null)
            {
                userTicP = new(this, executer);
                menuP.getPanel().Hide();
                mainF.getForm().Controls.Add(userTicP.getPanel());
            }
            else
            {
                menuP.getPanel().Hide();
                userTicP.getPanel().Show();
            }
        }

        public Form getForm()
        {
            return mainF.getForm();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.BLL;
using TicketAssig.DAL;

namespace TicketAssig.PL
{
    public class AdminPanel
    {
        private PanelController controller;
        private DatabaseExecuter executer;
        private Panel adminP = new();
        private TextBox input = new();
        private Button btn = new();
        private Button back = new();
        private string[] validCmds = ["UPDATE", "INSERT", "DELETE", "CREATE"];

        public AdminPanel(PanelController controller, DatabaseExecuter executer)
        {
            this.controller = controller;
            this.executer = executer;

            Initialize();
        }

        private void Initialize()
        {
            input.Bounds = new Rectangle(new Point(70, 50), new Size(250, 200));
            input.Multiline = true;

            btn.Text = "Confirm";
            btn.Bounds = new Rectangle(new Point(160, 300), new Size(70, 30));
            btn.Click += (o, s) => {runCommand();};

            back.Bounds = new Rectangle(new Point(10, 10), new Size(50, 30));
            back.Text = "Back";
            back.Click += (o, s) => {controller.switchToMenu("");};

            adminP.Bounds = new Rectangle(new Point(0, 0), new Size(400, 400));
            adminP.Controls.AddRange([input, btn, back]);
        }

        private void runCommand()
        {
            if(input.Text != "")
            {
                string[] split = input.Text.Split(" ");

                if(split[0].ToUpper().Equals("SELECT"))
                {
                    input.Text += executer.commandExecuter(input.Text, true);
                }
                else if(validCmds.Contains(split[0].ToUpper()))
                {
                    input.Text += executer.commandExecuter(input.Text, false);
                }
            }
        }

        public Panel getPanel()
        {
            return adminP;
        }
    }
}
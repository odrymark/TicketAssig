using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.BLL;
using TicketAssig.DAL;

namespace TicketAssig.PL
{
    public class LoginPanel
    {
        private PanelController controller;
        private DatabaseExecuter executer;
        private Panel loginPanel = new();
        private Button loginB = new();
        private TextBox userInput = new();
        private TextBox passwdInput = new();
        private Label userText = new();
        private Label passwdText = new();
        private Label output = new();

        public LoginPanel(PanelController controller, DatabaseExecuter executer)
        {
            this.controller = controller;
            this.executer = executer;

            Initialize();
        }

        private void Initialize()
        {
            loginB.Text = "Login";
            loginB.Bounds = new Rectangle(new Point(160, 300), new Size(70, 30));
            loginB.Click += (o, s) => authentication();

            userInput.Bounds = new Rectangle(new Point(103, 100), new Size(180, 30));
            userInput.KeyDown += new KeyEventHandler(textBoxEnter);
            userText.Text = "Username";
            userText.Bounds = new Rectangle(new Point(103, 80), new Size(100, 30));

            passwdInput.Bounds = new Rectangle(new Point(103, 200), new Size(180, 30));
            passwdInput.PasswordChar = '*';
            passwdInput.KeyDown += new KeyEventHandler(textBoxEnter);
            passwdText.Text = "Password";
            passwdText.Bounds = new Rectangle(new Point(103, 180), new Size(100, 30));
            
            output.Bounds = new Rectangle(new Point(95, 250), new Size(200, 30));
            output.TextAlign = ContentAlignment.MiddleCenter;

            loginPanel.Bounds = new Rectangle(new Point(0, 0), new Size(400, 400));
            loginPanel.Controls.AddRange([loginB, userInput, userText, passwdInput, passwdText, output]);
        }

        private void textBoxEnter(object? s, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; 
                authentication();
            }
        }

        private void authentication()
        {
            if(executer.authenticationExecuter(userInput.Text, passwdInput.Text))
            {
                controller.switchToMenu(userInput.Text);
            }
            else
            {
                output.Text = "Invalid name or password";
            }
        }

        public Panel getPanel()
        {
            return loginPanel;
        }
    }
}
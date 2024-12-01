using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.BLL;

namespace TicketAssig.PL
{
    public class CreatorPanel
    {
        private PanelController controller;
        private DatabaseExecuter executer;
        private Panel creatorP = new();
        private Button back = new();
        private Button btn = new();
        private Label nameText = new();
        private TextBox name = new();
        private Label locationText = new();
        private TextBox location = new();
        private Label dateText = new();
        private DateTimePicker date = new();
        private TextBox ticketNum = new();
        private Label ticketNumText = new();
        private TextBox price = new();
        private Label priceText = new();
        private Label typeText = new();
        private ComboBox type = new();
        private Label descText = new();
        private TextBox desc = new();
        private Label output = new();

        public CreatorPanel(PanelController controller, DatabaseExecuter executer)
        {
            this.controller = controller;
            this.executer = executer;

            Initialize();
        }

        private void Initialize()
        {
            btn.Bounds = new Rectangle(new Point(65, 310), new Size(70, 30));
            btn.Text = "Confirm";
            btn.Click += (o, s) => {confirm();};

            back.Bounds = new Rectangle(new Point(10, 10), new Size(50, 30));
            back.Text = "Back";
            back.Click += (o, s) => {controller.switchToMenu("");};

            nameText.Text = "Event name*";
            nameText.Bounds = new Rectangle(new Point(40, 60), new Size(100, 30));
            name.Bounds = new Rectangle(new Point(40, 80), new Size(130, 30));

            locationText.Text = "Location*";
            locationText.Bounds = new Rectangle(new Point(40, 130), new Size(100, 30));
            location.Bounds = new Rectangle(new Point(40, 150), new Size(130, 30));

            dateText.Text = "Date*";
            dateText.Bounds = new Rectangle(new Point(40, 200), new Size(100, 30));
            date.Bounds = new Rectangle(new Point(40, 220), new Size(130, 30));

            ticketNum.Bounds = new Rectangle(new Point(220, 80), new Size(40, 30));
            ticketNumText.Text = "Ticket count";
            ticketNumText.Bounds = new Rectangle(new Point(210, 60), new Size(80, 30));

            price.Bounds = new Rectangle(new Point(310, 80), new Size(40, 30));
            priceText.Text = "Ticket price";
            priceText.Bounds = new Rectangle(new Point(310, 60), new Size(100, 30));

            typeText.Text = "Event type*";
            typeText.Bounds = new Rectangle(new Point(220, 130), new Size(100, 30));
            type.Bounds = new Rectangle(new Point(220, 150), new Size(130, 30));
            type.DropDownStyle = ComboBoxStyle.DropDownList;
            type.Items.AddRange(["musical", "historical", "relaxation", "sports", "tournament", "lecture", "other"]);


            descText.Text = "Description (not requried)";
            descText.Bounds = new Rectangle(new Point(220, 200), new Size(200, 30));
            desc.Multiline = true;
            desc.Bounds = new Rectangle(new Point(220, 220), new Size(130, 120));

            output.Bounds = new Rectangle(new Point(30, 270), new Size(150, 30));
            output.TextAlign = ContentAlignment.MiddleCenter;
            
            creatorP.Bounds = new Rectangle(new Point(0, 0), new Size(400, 400));
            creatorP.Controls.AddRange([btn, back, name, nameText, location, locationText, date, dateText, ticketNum, ticketNumText, price, priceText, type, typeText, desc, descText, output]);
        }

        private void confirm()
        {
            if(name.Text != "" && location.Text != "" && date.Text != "" && ticketNum.Text != "" && price.Text != "" && type.Text != "")
            {
                output.Text = executer.createEventExecuter(name.Text, date.Text.ToString(), ticketNum.Text, location.Text, type.Text, price.Text, desc.Text);
            }
        }
        public Panel getPanel()
        {
            return creatorP;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.BLL;

namespace TicketAssig.PL
{
    public class TicketsPanel
    {
        private PanelController controller;
        private DatabaseExecuter executer;
        private Panel eventListP = new();
        private ListView list = new();
        private Button back = new();
        private Button buy = new();
        private TextBox number = new();
        private Label numberText = new();
        private Label priceSum = new();
        private Label priceSumText = new();
        private Label output = new();

        public TicketsPanel(PanelController controller, DatabaseExecuter executer)
        {
            this.controller = controller;
            this.executer = executer;
            Initialize();
        }

        private void Initialize()
        {
            list.Bounds = new Rectangle(new Point(55, 60), new Size(280, 230));
            list.View = View.Details;
            list.Columns.AddRange([new ColumnHeader {Text = "Name", Width = 50}, new ColumnHeader {Text = "Date", Width = 120}, new ColumnHeader {Text = "Remaining tickets", Width = 110}, new ColumnHeader {Text = "Location"}, new ColumnHeader {Text = "Type", Width = 70}, new ColumnHeader {Text = "Price"}, new ColumnHeader {Text = "Description", Width = 200}]);
            refreshEvents();

            buy.Bounds = new Rectangle(new Point(200, 315), new Size(80, 30));
            buy.Text = "Buy Tickets";
            buy.Click += (o, s) => {buyTickets();};

            number.Bounds = new Rectangle(new Point(100, 320), new Size(80, 30));
            number.TextChanged += (o, s) => calculatePrice();

            numberText.Bounds = new Rectangle(new Point(100, 300), new Size(100, 30));
            numberText.Text = "Amount";

            priceSum.Bounds = new Rectangle(new Point(280, 325), new Size(100, 30));
            priceSum.TextAlign = ContentAlignment.TopCenter;

            priceSumText.Bounds = new Rectangle(new Point(280, 300), new Size(100, 30));
            priceSumText.TextAlign = ContentAlignment.TopCenter;
            priceSumText.Text = "Price";

            back.Bounds = new Rectangle(new Point(10, 10), new Size(50, 30));
            back.Text = "Back";
            back.Click += (o, s) => {controller.switchToMenu(""); refreshEvents(); number.Text = ""; output.Text = ""; priceSum.Text = "";};

            output.Bounds = new Rectangle(new Point(90, 15), new Size(200, 30));
            output.TextAlign = ContentAlignment.MiddleCenter;

            eventListP.Bounds = new Rectangle(new Point(0, 0), new Size(400, 400));
            eventListP.Controls.AddRange([list, back, buy, number, numberText, priceSum, priceSumText, output]);
        }

        private void buyTickets()
        {
            if(!number.Text.Equals("") && number.Text.All(char.IsNumber) && list.SelectedItems.Count == 1)
            {
                if(int.Parse(list.SelectedItems[0].SubItems[2].Text) >= int.Parse(number.Text))
                {
                    output.Text = executer.addTicketExecuter(list.SelectedItems[0].Text, int.Parse(number.Text));
                    refreshEvents();
                }
                else
                {
                    output.Text = "Amount exceeds remaining";
                }
            }
            else
            {
                output.Text = "No selected event or no amount";
            }
        }

        private void calculatePrice()
        {
            if(!number.Text.Equals("") && number.Text.All(char.IsNumber) && list.SelectedItems.Count == 1)
            {
                try
                {
                    priceSum.Text = (int.Parse(list.SelectedItems[0].SubItems[5].Text) * int.Parse(number.Text)).ToString();
                }
                catch{}
            }
            else
            {
                priceSum.Text = "";
            }
        }

        private void refreshEvents()
        {
            list.Items.Clear();
            List<ListViewItem> items = executer.retrieveEventsExecuter();

            foreach(ListViewItem item in items)
            {
                list.Items.Add(item);
            }
        }

        public Panel getPanel()
        {
            return eventListP;
        }
    }
}
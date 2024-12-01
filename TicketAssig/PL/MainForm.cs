using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAssig.PL
{
    public class MainForm
    {
        private Form form = new();

        public MainForm()
        {
            Initialize();
        }

        private void Initialize()
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Bounds = new Rectangle(new Point(760, 300), new Size(400, 400));
            form.Text = "Ticket System";
        }

        public Form getForm()
        {
            return form;
        }
    }
}
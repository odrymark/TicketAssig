using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAssig.BLL;
using TicketAssig.PL;

namespace TicketAssig
{
    public class MainS
    {
        private static void Main(string[] args)
        {
            PanelController controller = new();
            Application.Run(controller.getForm());
        }
    }
}
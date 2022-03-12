using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_SZTGUI_2021222.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Husband> Husbands { get; set; }
        public RestCollection<Wife> Wives { get; set; }
        public RestCollection<Wedding> Weddings { get; set; }
        public MainWindowViewModel()
        {
            Husbands = new RestCollection<Husband>("http://localhost:18885/", "husband");
            Wives = new RestCollection<Wife>("http://localhost:18885/", "wife");
            Weddings = new RestCollection<Wedding>("http://localhost:18885/", "wedding");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_ClinicaDental.Settings.Diags
{
    public class ItemSender
    {
        public static bool modifyEnabled { get; set; }
        public static sqlSystemUsers element { get; set; }
        public ItemSender(sqlSystemUsers update, bool modify)
        {
            if (update != null)
            {
                element = update;
            }
            modifyEnabled = modify;
        }
    }
}

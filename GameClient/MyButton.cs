using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    public class MyButton : Button
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public Match.Type Type { get; set; }
        public Image Item { get; set; }
    }
}

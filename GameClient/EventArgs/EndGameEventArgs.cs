using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.EventArgs
{
    class EndGameEventArgs : System.EventArgs
    {
        public int MyUnities { get; set; }
        public int EnemyUnities { get; set; }
    }
}

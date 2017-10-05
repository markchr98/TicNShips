using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class BattleShip
    {
        private string type;
        private int quantity;
        private int length;
        public BattleShip(string type, int quantity, int length)
        {
            this.type = type;
            this.quantity = quantity;
            this.length = length;
        }
    }
}

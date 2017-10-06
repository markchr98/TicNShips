using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    public enum Type {
        Carrier,
        Submarine,
        Destroyer,
        Patrolboat,
        Battleship,
        Notvalid
    };
        public class BattleShip
    {
        private Type type;
        private int quantity;
        private int length;
        private char symbol;
        public BattleShip(Type type, int quantity, char symbol, int length)
        {
            this.type = type;
            this.quantity = quantity;
            this.length = length;
            this.symbol = symbol;
        }
        public Type Type { get { return type; } }

        public char Symbol { get { return symbol; } }

        public int Quantity { get { return quantity; } }

        public int Length { get { return length; } }
    }
}

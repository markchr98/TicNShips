using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    public enum Type {
        Aircraftcarrier,
        Submarine,
        Destroyer,
        Patrolboat,
        Battleship
    };
    class BattleShip
    {
        private Type type;
        private int quantity;
        private int length;
        public BattleShip(Type type, int quantity, int length)
        {
            this.type = type;
            this.quantity = quantity;
            this.length = length;
        }
        public Type Type { get { return type; } }
    }
}

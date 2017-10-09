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
        private int length;
       
        public BattleShip(Type type, int length)
        {
            this.type = type;           
            this.length = length;            
        }
        public Type Type { get; set; }
   
        public int Length { get { return length; } }
    }
}

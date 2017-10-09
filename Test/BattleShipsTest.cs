using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spil;

namespace Test
{
    [TestClass]
    public class BattleshipsTest
    {

        [TestMethod]
        public void PlayerOneTurn()
        {
            BattleshipsMenu battleshipsMenu = new BattleshipsMenu();
            bool expected = false;
            bool actual = battleshipsMenu.player1;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Shooting()
        {
            BattleshipsMenu battleshipsMenu = new BattleshipsMenu();
            bool expected = false;
            bool actual = battleshipsMenu.shooting;
            Assert.AreEqual(expected, actual);
        }
      
        [TestMethod]
        public void StartNewGame()
        {
            BattleshipsMenu battleshipsMenu = new BattleshipsMenu();

            bool expected = false;
            bool actual = battleshipsMenu.player1;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShipInfo()
        {
            BattleShip battleShip = new BattleShip(spil.Type.Patrolboat , 3, 'B', 2);
            PrivateObject privateObject = new PrivateObject(battleShip);
            Assert.AreEqual <int?>(2, privateObject.GetFieldOrProperty("length") as int?);
        }
        [TestMethod]
        public void ListOfShips()
        {
            bool actual;
            actual = Enum.IsDefined(typeof(spil.Type), "Carrier");
            bool expected = true;
            Assert.AreEqual(actual, expected);

        }
    }
}







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
            BattleShip battleShip = new BattleShip(spil.Type.Patrolboat, 3);
            PrivateObject privateObject = new PrivateObject(battleShip);
            Assert.AreEqual<int?>(3, privateObject.GetFieldOrProperty("length") as int?);
        }
        [TestMethod]
        public void ShipCarrierExists()
        {
            bool actual;
            actual = Enum.IsDefined(typeof(spil.Type), "Carrier");
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void ShipSubmarineExists()
        {
            bool actual;
            actual = Enum.IsDefined(typeof(spil.Type), "Submarine");
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void ShipDestroyerExists()
        {
            bool actual;
            actual = Enum.IsDefined(typeof(spil.Type), "Destroyer");
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void ShipPatrolboatExists()
        {
            bool actual;
            actual = Enum.IsDefined(typeof(spil.Type), "Patrolboat");
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void ShipBattleshipExists()
        {
            bool actual;
            actual = Enum.IsDefined(typeof(spil.Type), "Battleship");
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
    }
}



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
        public void ChooseGameMode()

        {
            BattleshipsMenu battleshipsMenu = new BattleshipsMenu();
            bool expected = false;
            bool actual = battleshipsMenu.startednewgame;
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
        //[TestInitialize]
        //public void Gameboard
        //[TestMethod]
        //public void LoadBattleBoard()
        //{
        //    Battle battleBoard = new BattleBoard();
        //   =  ;
        //     = BattleBoard.

        //[TestMethod]
        //public void MenuSelectionError()
        //{
        //    BattleshipsMenu battleshipsMenu = new BattleshipsMenu();
        //     string expected = "Invalid choice.";
        //    string actual = battleshipsMenu.ShowMenuSelectionError;
        //    Assert.ReferenceEquals (expected, actual);
        //}
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
            BattleShip battleShip = new BattleShip(spil.Type.Patrolboat , 3, '▼', 2);
            PrivateObject privateObject = new PrivateObject(battleShip);
            Assert.AreEqual <int?>(2, privateObject.GetFieldOrProperty("lenght") as int?);
            throw new  MemberAccessException("2, 2");
        }
    }
}







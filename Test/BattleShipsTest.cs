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
        //[TestMethod]
        //public void LoadBattleBoard()
        //{
        //    BattleBoard battleBoard = new BattleBoard();
        //   =  ;
        //     = BattleBoard.
        //}
    }
}



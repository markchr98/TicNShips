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
            BattleshipsMenu battleshipsMenu = new BattleshipsMenu ();
            bool expected = false;
            bool actual = battleshipsMenu.player1;
            Assert.AreEqual(expected, actual);

        }
    }
    //{
    //    [TestMethod]
    //    public void ChooseGamemode()
    //        {
    //        Program program = new program;
    //        int expectedResult = program.Run;
    //         }
    }


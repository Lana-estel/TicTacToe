using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace nolik8.Tests
{
    [TestClass]
    public class Main
    {


        
        [TestMethod]
        public void TestTheSettingPosition()
        {
            var position =
                  "X 0"
                  +"X 0"
                  +"   ";
            var e = new TicTacToeEngine(position);

            Assert.AreEqual(e.Position, position);
        }

        [TestMethod]
        public void GetGameResult_Should_Return_Right_Result()
        {
           TestGetGameResult(GameResult.Undefined,
                "   "+
                "   "+
                "   ");

           TestGetGameResult(GameResult.Draw,
                "X0X" +
                "00X" +
                "XX0");

            TestGetGameResult(GameResult.Zero,
                "X0X" +
                "00X" +
                "X00");

            TestGetGameResult(GameResult.Cross,
                "X0X" +
                "0XX" +
                "XX0");

            TestGetGameResult(GameResult.Cross,
                  "X0X" +
                  "XXX" +
                  "0X0");


        }

        public void TestGetGameResult(GameResult expected, string position)
        {
            var e = new TicTacToeEngine(position);

            var actual = e.GetGameResult();
            Assert.AreEqual(expected, actual, string.Format("{0} expected for position : {1}", expected, position));
        }


        [TestMethod]
        public void ConvertStringPosition_Should_Return_the_Right_Result() 
        {
            TestConvertStringPosition(
                 new int[]{ 
                   0, 0, 0, 
                   0 ,0, 0,
                   0, 0, 0 },
                 "         "
            );

            TestConvertStringPosition(
                 new int[]{ 
                   1,  0,  -1, 
                   0 , 1,  0,
                   -1, 0, -1 },
                  "X 0"+
                  " X "+
                  "0 0"
            );
            TestConvertStringPosition(
                new int[] {
                1, 1, 0,
                -1,-1, 0,
                1, -1, 0
                },
                "XX " +
                "00 " +
                "X0 "
                );
                
        
        }

        public void TestConvertStringPosition(int[] expected, string position)
        {

            var actual = TicTacToeEngine.ConvertStringPosition(position);
            Assert.IsTrue(expected.SequenceEqual(actual));
        
        }
        [TestMethod]
        public void GetBestMove_Should_Return_the_Right_Result()
        {
            TestGetBestMove(
                 1,
                 "0  " +
                 "XX0" +
                 "0 X"
                 );
            TestGetBestMove(
                 2,
                 "0  " +
                 " X " +
                 " 0X"
                 );
            TestGetBestMove(
            5,
                "00 "+
                "XX "+
                "0X "
                );
            TestGetBestMove(
                8 ,
                "X0 " +
                "0X " +
                "X0 "
                );
            TestGetBestMove(
                4,
                "   "+
                "   "+
                "   "
                );
            TestGetBestMove(
                2,
                "   " +
                " 0 " +
                "   "
                );
            TestGetBestMove(
                6,
                "0  " +
                " 0 " +
                "  X"
                );
            
        }
        public void TestGetBestMove(int expected, string position)
        {
            var e = new TicTacToeEngine(position);
          //  var actualZ = TicTacToeEngine.GetBestMove(PlayerType.Zero);
            var actualC = e.GetBestMove(PlayerType.Cross);
          //  Assert.AreEqual(expected, actualZ);
            Assert.IsTrue(actualC.Contains(expected));
            //Assert.IsTrue(Array.Exists(actualC, expected));
            //Assert.IsTrue(expected.SequenceEqual(actualC));
        }
    }
}

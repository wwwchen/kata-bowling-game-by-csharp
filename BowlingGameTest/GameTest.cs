﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kata.game;

namespace kata.game.test
{
    [TestClass]
    public class GameTest
    {
        private Game g;     // 宣告參考變數，指向 Game instance

        [TestInitialize]
        public void setup()
        {
            g = new Game();
        }

        [TestMethod]
        public void testGutterGame()
        {
            int expected = 0;   // 期望結果值
            int actual;         // 實際結果值

            this.rollMany(20, 0);
            actual = g.score();

            // 斷言比對
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // 測試玩家投球共20次，每次都只得一分時的總得分數
        // 期望結果值：20	
        public void testAllOnes()
        {
            int expected = 20;
            int actual;

            this.rollMany(20, 1);
            actual = g.score();

            // 斷言比對
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // 測試玩家整局只有一次補中+次一計分格投球的分數
        // 共 20 次投球機會，其餘 17 次皆0分
        public void testOneSpare()
        {

            int expected = 16;
            int actual;

            this.rollSPare();
	        g.roll(3);
	        this.rollMany(17,0); //其餘17次投球皆0分
            actual = g.score();

            Assert.AreEqual(expected, actual);
        }


        private void rollSPare()
        {
            g.roll(5);
            g.roll(5);
        }

        private void rollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.roll(pins);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RussianRoulette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Tests
{
    [TestClass()]
    public class GameTests
    {

        [TestMethod()]
        public void NewGameTest()
        {
            var gameMaster = new Game();
            var game = gameMaster.NewGame(new GameState());
            Assert.AreEqual(game.State, State.Play);

        }

        [TestMethod()]
        public void NewGameLoseTest()
        {

            var gameMaster = new Game();
            var game = gameMaster.NewGame(new GameState());
            game.State = State.Lose;
            game.Position = 4;

            game = gameMaster.NewGame(game);

            Assert.AreEqual(game.State, State.Intro);
            Assert.AreEqual(game.Loses, 1);
            Assert.AreEqual(game.Position, 0);
        }

        [TestMethod()]
        public void NewGameWinTest()
        {  
            var gameMaster = new Game();
            var game = gameMaster.NewGame(new GameState());

            game.State = State.Win;
            game.Position = 6;
            game.DodgesLeft = 0;

            game = gameMaster.NewGame(game);
            Assert.AreEqual(game.State, State.Intro);
            Assert.AreEqual(game.Wins, 1);
            Assert.AreEqual(game.Position, 0);
            Assert.AreEqual(game.DodgesLeft, 2);

        }

        [TestMethod()]
        public void FireTest()
        {
            var gameMaster = new Game();
            var game = gameMaster.NewGame(new GameState());

            game = gameMaster.Fire(game);

            Assert.AreEqual(game.Position, 0);

            game = gameMaster.Spin(game, 555);
            game = gameMaster.Fire(game);
            Assert.AreEqual(game.Position, 1);
        }

        [TestMethod()]
        public void DodgeTest()
        {
            var gameMaster = new Game();
            var game = gameMaster.NewGame(new GameState());
            game = gameMaster.Dodge(game);

            Assert.AreEqual(game.DodgesLeft, 1);
            Assert.AreEqual(game.Position, 1);
            game = gameMaster.Dodge(game);
            Assert.AreEqual(game.Position, 2);
        }
    }
}
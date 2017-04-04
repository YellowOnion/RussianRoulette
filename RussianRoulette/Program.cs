using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RussianRoulette
{
    static class Utils {

        // some code to shuffle a list.
        public static void Shuffle<T>(IList<T> list, Random rnd)
        {
            for (var i = 0; i < list.Count; i++)
                list.Swap(i, rnd.Next(i, list.Count));
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public enum State
    {
        Intro ,
        Play ,
        Win ,
        Lose
    }

    public class GameState
    {
        public int Position = 0;
        public int DodgesLeft = 2;
        public int Wins = 0;
        public int Loses = 0;
        public List<bool> Moves = new List<bool> { true, false, false, false, false, false };

        public State State = State.Intro;
    }

    public class Game
    {
        // spin the Cylinder of the "revolver"
        public GameState Spin(GameState state, int seed)
        {
            state.State = State.Play;
            Random random = new Random(seed);
            Utils.Shuffle(state.Moves, random);
            return state;
        }

        // this creates a new game.
        public GameState NewGame(GameState state)
        {
            switch (state.State)
            {
                case State.Lose:
                    // add one to losses, and start the game again.
                    state.Loses += 1;
                    state.Position = 0;
                    state.State = State.Intro;
                    state.DodgesLeft = 2;
                    break;

                case State.Intro:
                    state.Position = 0;
                    state.State = State.Play;
                    break;

                case State.Win:
                    state.DodgesLeft = 2;
                    state.Wins += 1;
                    state.Position = 0;
                    state.State = State.Intro;
                    break;

                case State.Play:
                    throw new SystemException("WHOOPS!");
            }
            return state;
        }

        // this "fires" the gun.
        public GameState Fire(GameState state)
        {
            if (state.Moves[state.Position] == true)
            {
                state.State = State.Lose;
            }
            else
            {
                state.Position += 1;
                if (state.Position >= 5)
                {
                    state.State = State.Win;
                }
            }

            return state;
        }

        // this "fires" away the bullet, get out of jail free.
        public GameState Dodge(GameState state)
        {
            if (state.DodgesLeft <= 0) return null;
            state.Position += 1;
            state.DodgesLeft -= 1;
            if (state.Position >= 5)
            {
                state.State = State.Win;
            }
            return state;
        }

    }

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

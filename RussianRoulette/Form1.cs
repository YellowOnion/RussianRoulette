using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Text;


namespace RussianRoulette
{
    public enum GameAction
    {
        Observe,
        Evade
    }
    enum Prompt
    {
        Continue,
        Fire,
        Off
    }

    enum Sounds
    {
        Evade,
        Observe,
        Dead,
        Win
    }

    // this class controls all redrawing and sounds events.
    public class Controller
    {
        private Prompt promptState = Prompt.Off;
        private int textSpeed = 32;

        public string promptText = "";

        private SemaphoreSlim continueSem = new SemaphoreSlim(0, 1);
        private SemaphoreSlim fireSem = new SemaphoreSlim(0, 1);
        private GameAction fireAction;

        private Label lblLosses;
        private Label lblBlinds;
        private Label lblTurns;
        private Label lblWins;
        private Button btnBlind;
        private Button btnObserve;
        private PictureBox picDinger;

        private SoundPlayer evadeSound;
        private SoundPlayer observeSound;
        private SoundPlayer deadSound;
        private SoundPlayer winSound;


        public Controller(Button GOText,
                          Label lblBlinds,
                          Label lblLosses,
                          Label lblTurns,
                          Label lblWins,
                          Button btnBlind,
                          Button btnObserve,
                          PictureBox picDinger)
        {
            Task drawTask;
            this.lblBlinds = lblBlinds;
            this.lblLosses = lblLosses; 
            this.lblTurns  = lblTurns;
            this.lblWins = lblWins;
            this.btnBlind = btnBlind;
            this.btnObserve = btnObserve;
            this.picDinger = picDinger;

            evadeSound = new SoundPlayer("Resources\\evade.wav");
            observeSound = new SoundPlayer("Resources\\observe.wav");
            deadSound = new SoundPlayer("Resources\\dead.wav");
            winSound = new SoundPlayer("Resources\\win.wav");

            /// this creates a stream of events for the button to be redrawn with.
            var btn = new Progress<string>(s => GOText.Text = s);
            drawTask = Task.Run(() => drawText(btn));
        } 

        // this is the "script" for the game, controls text animations and sound events.
        public async Task GameScript()
        {
            await animateText("Welcome to Schrödinger's Pusheen, click on this box to continue");
            await prompt(Prompt.Continue);

            // seed and game loop.
            int seed = 554;
            bool newgame = true;
            Game gameMaster = new Game();

            GameState gameState = new GameState();

            while (newgame)
            {
                    switch (gameState.State)
                    {
                        case State.Intro:
                            seed++;
                            gameState = gameMaster.NewGame(gameState);
                            // Start the Schrodinger animation.
                             (new Task(() => animateDinger())).RunSynchronously();
                            // start the intro text!
                            await animateText("A wild Schrödinger appears!");
                            await prompt(Prompt.Continue);
                            await animateText("Schrödinger prepares his famous experiment!");
                            await prompt(Prompt.Continue);
                            gameState = gameMaster.Spin(gameState, seed);
                            drawState(gameState);
                        break;

                        case State.Play:
                            await animateText("what are you going to do??");
                            await prompt(Prompt.Fire);
                            
                            switch (fireAction)
                            {
                                case GameAction.Observe:
                                    gameState = gameMaster.Fire(gameState);
                                    drawState(gameState);
                                    playSound(Sounds.Observe);
                                    await animateText("Schrödinger uses observe!");
                                    await prompt(Prompt.Continue);
                                    if (gameState.State == State.Play)
                                    {
                                        await animateText("Pusheen is alive!");
                                        await prompt(Prompt.Continue);
                                    }
                                    break;

                                case GameAction.Evade:
                                    var gameState2 = gameMaster.Dodge(gameState);
                                    if (gameState2 == null)
                                    {
                                        await animateText("You don't have any dodges left!");
                                        await prompt(Prompt.Continue);
                                    }
                                    else
                                    {
                                        gameState = gameState2;
                                    }
                                    drawState(gameState);
                                    playSound(Sounds.Evade);
                                    await animateText("Pusheen uses blind!");
                                    await prompt(Prompt.Continue);
                                    playSound(Sounds.Observe);
                                    await animateText("Schrödinger uses observe!");
                                    await prompt(Prompt.Continue);
                                    await animateText("He can't see!");
                                    await prompt(Prompt.Continue);
                                    break;
                            }
                            break;
                        case State.Win:
                            await animateText("Schrödinger gives up!");
                            await prompt(Prompt.Continue);
                            playSound(Sounds.Win);
                            await animateText("YOU WIN!");
                            await prompt(Prompt.Continue);
                            gameState = gameMaster.NewGame(gameState);
                            drawState(gameState);
                            break;

                        case State.Lose:
                            await animateText("IT'S SUPER EFFECTIVE!!@!@!");
                            await prompt(Prompt.Continue);
                            playSound(Sounds.Dead);
                            await animateText("Pusheen is dead");
                            await prompt(Prompt.Continue);
                            gameState = gameMaster.NewGame(gameState);
                            drawState(gameState);
                            break;
                    }

            }

        }


        // this plays the sound in the "background" synchronously.
        private void playSound(Sounds sound)
        {
            (new Task(() => playSoundReal(sound))).RunSynchronously();
        }

        // This is where we play the sounds for real, needed something to be called for Task.
        private void playSoundReal(Sounds sound)
        {
            switch (sound)
            {
                case Sounds.Evade:
                    evadeSound.Play();
                    break;

                case Sounds.Observe:
                    observeSound.Play();
                    break;
                case Sounds.Win:
                    winSound.Play();
                    break;
                case Sounds.Dead:
                    deadSound.Play();
                    break;
            }
        }

        // here we want to only allow one button press at a time, so we create a semaphore to protect the semaphore. yo dawg.
        private async Task prompt(Prompt prompt)
        {
            promptState = prompt;
            switch (prompt)
            {
                case Prompt.Continue:
                    await continueSem.WaitAsync();
                    break;

                case Prompt.Fire:
                    btnBlind.Visible = true;
                    btnObserve.Visible = true;  
                    await fireSem.WaitAsync();
                    btnBlind.Visible = false;
                    btnObserve.Visible = false;  
                        break;
                }
            promptState = Prompt.Off;
        }

        // this is called when we want the score board updated.
        private void drawState(GameState state)
        {
            lblBlinds.Text = state.DodgesLeft.ToString();
            lblLosses.Text = state.Loses.ToString();
            lblTurns.Text  = (state.Position + 1).ToString();
            lblWins.Text = state.Wins.ToString();

        }

        // this animates the Schrodinger animation using Tasks and Task Delay.
        private async void animateDinger()
        {
            int dingerStartingPosition = -396;
            int dingerTimerCounter = dingerStartingPosition;
            while (dingerTimerCounter != 0)
            {
                dingerTimerCounter += 4;

                var loc = picDinger.Location;
                loc.Y = dingerTimerCounter;
                picDinger.Location = loc;
                await Task.Delay(16);
            }
        }

        // a loop with a delay to print each character to the screen one at at time.
        private async void drawText(IProgress<string> btn)
        {
            bool isDot = true;
            int counter = 0;
            while (true)
            {
                // this reports back to the lambda that actualises the button label.
                btn.Report(drawTextGo(isDot));

                counter += textSpeed;
                if (counter > 500)
                {
                    isDot = !isDot;
                    counter = 0;
                }

                await Task.Delay(textSpeed);
            }
        }

        // the blinking fullstop is added if needed.
        private string drawTextGo(bool isDot)
        {
            var dot = isDot ? "." : " ";
            return promptText + dot;
        }


        // here we setup the string to be printed character by character.
        private async Task animateText(string text)
        {
            string textRemaining = text;
            textRemaining = await animateTextGo(true, textRemaining);
            while (textRemaining.Length != 0)
            {
                await Task.Delay(textSpeed);
                textRemaining = await animateTextGo(false, textRemaining);
            }
        }

        /// this method  modifies the buttonGo string, ready for dot appendage.
        private async Task<string> animateTextGo(bool reset, string remainingText)
        {
            var text = reset ? "" : promptText;
            var length = text.Length == 0 ? 0 : text.Length;

            var remaining = remainingText.Length == 0 ? "" : remainingText.Substring(0, 1);

            promptText = text.Substring(0, length) + remaining;

            return remainingText.Length == 0 ? "" : remainingText.Substring(1, remainingText.Length - 1);
        }

        // some code to make all the button clicks safe from exploding in to a firery mess.
        public void PromptClick(GameAction gameAction)
        {
            var savedFire = fireAction;
            fireAction = gameAction;
            try
            { fireSem.Release(1); }
            catch
            { fireAction = savedFire; }
        }

        public void ContinueClick()
        {

            if (promptState != Prompt.Continue) return; // do nothing when we aint asking for anything.
            try
            { continueSem.Release(1); } // send the "continue" action to the prompt.
            catch { };
        }
    }

    public partial class Form1 : Form
    {


        private Controller control;

        public Form1()
        {
            InitializeComponent();
            control = new Controller(btnGO, lblBlinds, lblLosses, lblTurns, lblWins, btnBlind, btnObserve, picDinger);

            // lets setup our custom font.
            PrivateFontCollection Player2Font = new PrivateFontCollection();
            Player2Font.AddFontFile("Resources/PressStart2P.ttf");
            var Font = new Font(Player2Font.Families[0], btnGO.Font.Size);
            btnGO.Font = Font;
            lblTurnText.Font = Font;
            lblTurns.Font = Font;
            lblWinsText.Font = Font;
            lblWins.Font = Font;
            lblLossesText.Font = Font;
            lblLosses.Font = Font;
            lblBlinds.Font = Font;
            lblBlindsText.Font = Font;

            // hide the action buttons until they are needed.
            btnBlind.Visible = false;
            btnObserve.Visible = false;  
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {

            await control.GameScript();
        }


        private void btnGO_Click(object sender, EventArgs e)
        {
            control.ContinueClick();

        }

        private void btnObserve_Click(object sender, EventArgs e)
        {
            control.PromptClick(GameAction.Observe);
 
        }

        private void btnBlind_Click(object sender, EventArgs e)
        {
            control.PromptClick(GameAction.Evade);
        }
    }
}

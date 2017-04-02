using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Text;


namespace RussianRoulette
{
    enum GameAction
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
    public partial class Form1 : Form
    {

        private Prompt promptState = Prompt.Off;

        private string promptText = "";

        private SemaphoreSlim continueSem = new SemaphoreSlim(0,1);
        private SemaphoreSlim fireSem = new SemaphoreSlim(0,1);
        private GameAction fireAction;


        public Form1()
        {
            InitializeComponent();

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
            Task drawTask;
            var btn = new Progress<string>(s => btnGO.Text = s);
            drawTask = Task.Run(() => drawText(btn));
            await GameScript();
        }
        private async Task GameScript()
        {
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
                                    await animateText("Pusheen uses blind!");
                                    await prompt(Prompt.Continue);
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
                            await animateText("YOU WIN!");
                            await prompt(Prompt.Continue);
                            gameState = gameMaster.NewGame(gameState);
                            drawState(gameState);
                            break;

                        case State.Lose:
                            await animateText("IT'S SUPER EFFECTIVE!!@!@!");
                                    await prompt(Prompt.Continue);
                            await animateText("Pusheen is dead");
                                    await prompt(Prompt.Continue);
                            gameState = gameMaster.NewGame(gameState);
                            drawState(gameState);
                            break;
                    }
             
                //await animateText("He uses Observe, it's super effective");

            }

        }

        // here we want to only allow one button press at a time, so we create a semaphore to protect the semaphore.
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

        private void drawState(GameState state)
        {
            lblBlinds.Text = state.DodgesLeft.ToString();
            lblLosses.Text = state.Loses.ToString();
            lblTurns.Text  = (state.Position + 1).ToString();
            lblWins.Text = state.Wins.ToString();

        }
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

        
        private async void drawText(IProgress<string> btn)
        {
            int textSpeed = 50;
            bool isDot = true;
            int counter = 0;
            while (true)
            {
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

        private string drawTextGo(bool isDot)
        {
            var dot = isDot ? "." : " ";
            return promptText + dot;
        }

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

        private async Task<string> animateTextGo(bool reset, string remainingText)
        {
            var text = reset ? "" : promptText;
            var length = text.Length == 0 ? 0 : text.Length;

            var remaining = remainingText.Length == 0 ? "" : remainingText.Substring(0, 1);

            promptText = text.Substring(0, length) + remaining;

            return remainingText.Length == 0 ? "" : remainingText.Substring(1, remainingText.Length - 1);
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (promptState != Prompt.Continue) return; // do nothing when we aint asking for anything.
            try
            { continueSem.Release(1); } // send the "continue" action to the prompt.
            catch { };

        }

        private void btnObserve_Click(object sender, EventArgs e)
        {
            var savedFire = fireAction;
            fireAction = GameAction.Observe;
            try
            { fireSem.Release(1); } // send the "Observe" action to the prompt
            catch
            { fireAction = savedFire; }
 
        }

        private void btnBlind_Click(object sender, EventArgs e)
        {
            var savedFire = fireAction;
            fireAction = GameAction.Evade;
            try
            { fireSem.Release(1); } // send the "Blind/Evade" option to the prompt.
            catch
            { fireAction = savedFire; }
        }
    }
}

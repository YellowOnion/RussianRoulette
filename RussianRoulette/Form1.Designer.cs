namespace RussianRoulette
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGO = new System.Windows.Forms.Button();
            this.lblTurnText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLosses = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblTurns = new System.Windows.Forms.Label();
            this.lblWinsText = new System.Windows.Forms.Label();
            this.lblLossesText = new System.Windows.Forms.Label();
            this.lblBlinds = new System.Windows.Forms.Label();
            this.lblBlindsText = new System.Windows.Forms.Label();
            this.picEmotive = new System.Windows.Forms.PictureBox();
            this.picPusheen1 = new System.Windows.Forms.PictureBox();
            this.picDinger = new System.Windows.Forms.PictureBox();
            this.btnObserve = new System.Windows.Forms.Button();
            this.btnBlind = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmotive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPusheen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDinger)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGO
            // 
            this.btnGO.BackColor = System.Drawing.Color.Black;
            this.btnGO.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGO.Location = new System.Drawing.Point(147, 394);
            this.btnGO.Name = "btnGO";
            this.btnGO.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.btnGO.Size = new System.Drawing.Size(562, 82);
            this.btnGO.TabIndex = 2;
            this.btnGO.Text = "The quick brown fox jumped over the lazy frog.";
            this.btnGO.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGO.UseVisualStyleBackColor = false;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // lblTurnText
            // 
            this.lblTurnText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTurnText.AutoSize = true;
            this.lblTurnText.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnText.Location = new System.Drawing.Point(3, 3);
            this.lblTurnText.Margin = new System.Windows.Forms.Padding(3);
            this.lblTurnText.Name = "lblTurnText";
            this.lblTurnText.Size = new System.Drawing.Size(122, 22);
            this.lblTurnText.TabIndex = 4;
            this.lblTurnText.Text = "Turn:";
            this.lblTurnText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblLosses, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblWins, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTurns, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTurnText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWinsText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLossesText, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBlinds, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBlindsText, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(179, 112);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblLosses
            // 
            this.lblLosses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLosses.AutoSize = true;
            this.lblLosses.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLosses.Location = new System.Drawing.Point(131, 59);
            this.lblLosses.Margin = new System.Windows.Forms.Padding(3);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(45, 22);
            this.lblLosses.TabIndex = 10;
            this.lblLosses.Text = "00";
            this.lblLosses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWins
            // 
            this.lblWins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWins.AutoSize = true;
            this.lblWins.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWins.Location = new System.Drawing.Point(131, 31);
            this.lblWins.Margin = new System.Windows.Forms.Padding(3);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(45, 22);
            this.lblWins.TabIndex = 9;
            this.lblWins.Text = "00";
            this.lblWins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTurns
            // 
            this.lblTurns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTurns.AutoSize = true;
            this.lblTurns.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurns.Location = new System.Drawing.Point(131, 3);
            this.lblTurns.Margin = new System.Windows.Forms.Padding(3);
            this.lblTurns.Name = "lblTurns";
            this.lblTurns.Size = new System.Drawing.Size(45, 22);
            this.lblTurns.TabIndex = 8;
            this.lblTurns.Text = "00";
            this.lblTurns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWinsText
            // 
            this.lblWinsText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWinsText.AutoSize = true;
            this.lblWinsText.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinsText.Location = new System.Drawing.Point(3, 31);
            this.lblWinsText.Margin = new System.Windows.Forms.Padding(3);
            this.lblWinsText.Name = "lblWinsText";
            this.lblWinsText.Size = new System.Drawing.Size(122, 22);
            this.lblWinsText.TabIndex = 6;
            this.lblWinsText.Text = "Wins:";
            this.lblWinsText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLossesText
            // 
            this.lblLossesText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLossesText.AutoSize = true;
            this.lblLossesText.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLossesText.Location = new System.Drawing.Point(3, 59);
            this.lblLossesText.Margin = new System.Windows.Forms.Padding(3);
            this.lblLossesText.Name = "lblLossesText";
            this.lblLossesText.Size = new System.Drawing.Size(122, 22);
            this.lblLossesText.TabIndex = 7;
            this.lblLossesText.Text = "Losses:";
            this.lblLossesText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBlinds
            // 
            this.lblBlinds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlinds.AutoSize = true;
            this.lblBlinds.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlinds.Location = new System.Drawing.Point(131, 87);
            this.lblBlinds.Margin = new System.Windows.Forms.Padding(3);
            this.lblBlinds.Name = "lblBlinds";
            this.lblBlinds.Size = new System.Drawing.Size(45, 22);
            this.lblBlinds.TabIndex = 12;
            this.lblBlinds.Text = "00";
            this.lblBlinds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBlindsText
            // 
            this.lblBlindsText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlindsText.AutoSize = true;
            this.lblBlindsText.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlindsText.Location = new System.Drawing.Point(3, 87);
            this.lblBlindsText.Margin = new System.Windows.Forms.Padding(3);
            this.lblBlindsText.Name = "lblBlindsText";
            this.lblBlindsText.Size = new System.Drawing.Size(122, 22);
            this.lblBlindsText.TabIndex = 11;
            this.lblBlindsText.Text = "Blinds:";
            this.lblBlindsText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picEmotive
            // 
            this.picEmotive.Image = global::RussianRoulette.Properties.Resources.excite;
            this.picEmotive.Location = new System.Drawing.Point(13, 394);
            this.picEmotive.Name = "picEmotive";
            this.picEmotive.Size = new System.Drawing.Size(128, 128);
            this.picEmotive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEmotive.TabIndex = 3;
            this.picEmotive.TabStop = false;
            // 
            // picPusheen1
            // 
            this.picPusheen1.Image = global::RussianRoulette.Properties.Resources.pusheen_back;
            this.picPusheen1.Location = new System.Drawing.Point(12, 176);
            this.picPusheen1.Name = "picPusheen1";
            this.picPusheen1.Size = new System.Drawing.Size(350, 300);
            this.picPusheen1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPusheen1.TabIndex = 1;
            this.picPusheen1.TabStop = false;
            // 
            // picDinger
            // 
            this.picDinger.Image = global::RussianRoulette.Properties.Resources.Erwin_Schrödinger;
            this.picDinger.Location = new System.Drawing.Point(440, -396);
            this.picDinger.Name = "picDinger";
            this.picDinger.Size = new System.Drawing.Size(280, 396);
            this.picDinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDinger.TabIndex = 0;
            this.picDinger.TabStop = false;
            // 
            // btnObserve
            // 
            this.btnObserve.BackColor = System.Drawing.Color.Black;
            this.btnObserve.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObserve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnObserve.Location = new System.Drawing.Point(3, 3);
            this.btnObserve.Name = "btnObserve";
            this.btnObserve.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.btnObserve.Size = new System.Drawing.Size(131, 40);
            this.btnObserve.TabIndex = 6;
            this.btnObserve.Text = "Observe";
            this.btnObserve.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnObserve.UseVisualStyleBackColor = false;
            this.btnObserve.Click += new System.EventHandler(this.btnObserve_Click);
            // 
            // btnBlind
            // 
            this.btnBlind.BackColor = System.Drawing.Color.Black;
            this.btnBlind.Font = new System.Drawing.Font("Press Start 2P", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBlind.Location = new System.Drawing.Point(140, 3);
            this.btnBlind.Name = "btnBlind";
            this.btnBlind.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.btnBlind.Size = new System.Drawing.Size(131, 40);
            this.btnBlind.TabIndex = 7;
            this.btnBlind.Text = "Blind!";
            this.btnBlind.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBlind.UseVisualStyleBackColor = false;
            this.btnBlind.Click += new System.EventHandler(this.btnBlind_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnObserve);
            this.flowLayoutPanel1.Controls.Add(this.btnBlind);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(148, 474);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(561, 48);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(721, 534);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.picEmotive);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.picPusheen1);
            this.Controls.Add(this.picDinger);
            this.Name = "Form1";
            this.Text = "Schrödinger\'s Pusheen";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmotive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPusheen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDinger)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picDinger;
        private System.Windows.Forms.PictureBox picPusheen1;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.PictureBox picEmotive;
        private System.Windows.Forms.Label lblTurnText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblTurns;
        private System.Windows.Forms.Label lblWinsText;
        private System.Windows.Forms.Label lblLossesText;
        private System.Windows.Forms.Label lblBlinds;
        private System.Windows.Forms.Label lblBlindsText;
        private System.Windows.Forms.Button btnObserve;
        private System.Windows.Forms.Button btnBlind;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}


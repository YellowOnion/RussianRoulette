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
            this.picPusheen1 = new System.Windows.Forms.PictureBox();
            this.picDinger = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPusheen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDinger)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGO
            // 
            this.btnGO.BackColor = System.Drawing.Color.Black;
            this.btnGO.Font = new System.Drawing.Font("Press Start 2P", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGO.Location = new System.Drawing.Point(12, 370);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(697, 152);
            this.btnGO.TabIndex = 2;
            this.btnGO.UseVisualStyleBackColor = false;
            // 
            // picPusheen1
            // 
            this.picPusheen1.Image = global::RussianRoulette.Properties.Resources.pusheen_dance;
            this.picPusheen1.Location = new System.Drawing.Point(12, 62);
            this.picPusheen1.Name = "picPusheen1";
            this.picPusheen1.Size = new System.Drawing.Size(339, 281);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 534);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.picPusheen1);
            this.Controls.Add(this.picDinger);
            this.Name = "Form1";
            this.Text = "Schrödinger\'s Pusheen";
            ((System.ComponentModel.ISupportInitialize)(this.picPusheen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picDinger;
        private System.Windows.Forms.PictureBox picPusheen1;
        private System.Windows.Forms.Button btnGO;
    }
}


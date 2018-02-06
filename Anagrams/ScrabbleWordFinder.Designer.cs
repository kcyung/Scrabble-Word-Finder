namespace Anagrams
{
    partial class ScrabbleWordFinder
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
            this.UI_TB_Input = new System.Windows.Forms.TextBox();
            this.UI_LB_Words = new System.Windows.Forms.ListBox();
            this.UI_LBL_EnterTiles = new System.Windows.Forms.Label();
            this.UI_LBL_MaxCharacters = new System.Windows.Forms.Label();
            this.UI_BTN_Points = new System.Windows.Forms.Button();
            this.UI_BTN_Length = new System.Windows.Forms.Button();
            this.UI_LBL_BlanksWorthNothing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_TB_Input
            // 
            this.UI_TB_Input.Location = new System.Drawing.Point(26, 36);
            this.UI_TB_Input.MaxLength = 15;
            this.UI_TB_Input.Name = "UI_TB_Input";
            this.UI_TB_Input.Size = new System.Drawing.Size(256, 20);
            this.UI_TB_Input.TabIndex = 0;
            // 
            // UI_LB_Words
            // 
            this.UI_LB_Words.FormattingEnabled = true;
            this.UI_LB_Words.Location = new System.Drawing.Point(26, 109);
            this.UI_LB_Words.Name = "UI_LB_Words";
            this.UI_LB_Words.ScrollAlwaysVisible = true;
            this.UI_LB_Words.Size = new System.Drawing.Size(256, 290);
            this.UI_LB_Words.TabIndex = 1;
            // 
            // UI_LBL_EnterTiles
            // 
            this.UI_LBL_EnterTiles.AutoSize = true;
            this.UI_LBL_EnterTiles.Location = new System.Drawing.Point(23, 17);
            this.UI_LBL_EnterTiles.Name = "UI_LBL_EnterTiles";
            this.UI_LBL_EnterTiles.Size = new System.Drawing.Size(148, 13);
            this.UI_LBL_EnterTiles.TabIndex = 2;
            this.UI_LBL_EnterTiles.Text = "Enter Tiles (use \'?\' for blanks):";
            // 
            // UI_LBL_MaxCharacters
            // 
            this.UI_LBL_MaxCharacters.AutoSize = true;
            this.UI_LBL_MaxCharacters.Location = new System.Drawing.Point(182, 59);
            this.UI_LBL_MaxCharacters.Name = "UI_LBL_MaxCharacters";
            this.UI_LBL_MaxCharacters.Size = new System.Drawing.Size(97, 13);
            this.UI_LBL_MaxCharacters.TabIndex = 3;
            this.UI_LBL_MaxCharacters.Text = "max. 15 characters";
            // 
            // UI_BTN_Points
            // 
            this.UI_BTN_Points.Location = new System.Drawing.Point(26, 80);
            this.UI_BTN_Points.Name = "UI_BTN_Points";
            this.UI_BTN_Points.Size = new System.Drawing.Size(128, 22);
            this.UI_BTN_Points.TabIndex = 4;
            this.UI_BTN_Points.Text = "Sort By Points";
            this.UI_BTN_Points.UseVisualStyleBackColor = true;
            this.UI_BTN_Points.Click += new System.EventHandler(this.UI_BTN_Points_Click);
            // 
            // UI_BTN_Length
            // 
            this.UI_BTN_Length.Location = new System.Drawing.Point(160, 80);
            this.UI_BTN_Length.Name = "UI_BTN_Length";
            this.UI_BTN_Length.Size = new System.Drawing.Size(119, 22);
            this.UI_BTN_Length.TabIndex = 5;
            this.UI_BTN_Length.Text = "Sort By Word Length";
            this.UI_BTN_Length.UseVisualStyleBackColor = true;
            this.UI_BTN_Length.Click += new System.EventHandler(this.UI_BTN_Length_Click);
            // 
            // UI_LBL_BlanksWorthNothing
            // 
            this.UI_LBL_BlanksWorthNothing.AutoSize = true;
            this.UI_LBL_BlanksWorthNothing.Location = new System.Drawing.Point(130, 402);
            this.UI_LBL_BlanksWorthNothing.Name = "UI_LBL_BlanksWorthNothing";
            this.UI_LBL_BlanksWorthNothing.Size = new System.Drawing.Size(152, 13);
            this.UI_LBL_BlanksWorthNothing.TabIndex = 6;
            this.UI_LBL_BlanksWorthNothing.Text = "(Blank Tiles are worth 0 points)";
            // 
            // ScrabbleWordFinder
            // 
            this.AcceptButton = this.UI_BTN_Points;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 421);
            this.Controls.Add(this.UI_LBL_BlanksWorthNothing);
            this.Controls.Add(this.UI_BTN_Length);
            this.Controls.Add(this.UI_BTN_Points);
            this.Controls.Add(this.UI_LBL_MaxCharacters);
            this.Controls.Add(this.UI_LBL_EnterTiles);
            this.Controls.Add(this.UI_LB_Words);
            this.Controls.Add(this.UI_TB_Input);
            this.Name = "ScrabbleWordFinder";
            this.Text = "Scrabble Word Finder";
            this.Load += new System.EventHandler(this.WordSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UI_TB_Input;
        private System.Windows.Forms.ListBox UI_LB_Words;
        private System.Windows.Forms.Label UI_LBL_EnterTiles;
        private System.Windows.Forms.Label UI_LBL_MaxCharacters;
        private System.Windows.Forms.Button UI_BTN_Points;
        private System.Windows.Forms.Button UI_BTN_Length;
        private System.Windows.Forms.Label UI_LBL_BlanksWorthNothing;
    }
}


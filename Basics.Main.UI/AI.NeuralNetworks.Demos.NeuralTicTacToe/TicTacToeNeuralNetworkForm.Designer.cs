﻿namespace Basics.AI.NeuralNetworks.Demos.NeuralTicTacToe
{
    partial class TicTacToeNeuralNetworkForm
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
            this.panel1 = new Basics.AI.NeuralNetworks.Demos.NeuralTicTacToe.TicTacToeNeuralBoardControl();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(77, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 229);
            this.panel1.TabIndex = 0;
            // 
            // TicTacToeNeuralNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "TicTacToeNeuralNetworkForm";
            this.Text = "TicTacToeNeuralNetworkForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Basics.AI.NeuralNetworks.Demos.NeuralTicTacToe.TicTacToeNeuralBoardControl panel1;
    }
}
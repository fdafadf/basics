﻿using Demos.Forms.Utilities;
using Demos.Forms.Base;
using Games.TicTacToe;
using Games.Utilities;
using System.Collections.Generic;

namespace Demos.Forms.TicTacToe
{
    public class TicTacToeBoardControl1<TFieldControl> : BoardControl<GameState, GameAction> where TFieldControl : TicTacToeBoardFieldControl
    {
        private const int BoardSize = 3;

        private SquaresGridLayoutPanel<TFieldControl> layoutPanel;

        public TicTacToeBoardControl1()
        {
            TFieldControl[,] fieldControls = new TFieldControl[BoardSize, BoardSize];

            for (ushort y = 0; y < BoardSize; y++)
            {
                for (ushort x = 0; x < BoardSize; x++)
                {
                    TFieldControl fieldControl = System.Activator.CreateInstance(typeof(TFieldControl), new BoardCoordinates(x, y)) as TFieldControl;
                    fieldControl.Tag = new GameAction(x, y);
                    fieldControl.MouseUp += FieldControl_MouseUp;
                    fieldControls[x, y] = fieldControl;
                }
            }

            this.layoutPanel = new SquaresGridLayoutPanel<TFieldControl>(fieldControls);
            this.SuspendLayout();
            // 
            // ticTacToeBoardControl1
            // 
            this.layoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Padding = new System.Windows.Forms.Padding(0);
            this.layoutPanel.TabIndex = 0;
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // TicTacToeBoardControl
            // 
            this.Controls.Add(this.layoutPanel);

            this.Name = "TicTacToeBoardControl";
            this.Text = "TicTacToeBoardControl";
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResumeLayout(false);
        }

        public override GameState BoardState
        {
            set
            {
                foreach (TicTacToeBoardFieldControl fieldControl in Fields)
                {
                    fieldControl.FieldState = value[fieldControl.Coordinates.X, fieldControl.Coordinates.Y];
                }
            }
        }

        private void FieldControl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TicTacToeBoardFieldControl fieldControl = sender as TicTacToeBoardFieldControl;

            if (fieldControl != null)
            {
                GameAction gameAction = fieldControl.Tag as GameAction;

                if (gameAction != null)
                {
                    this.RaiseFieldSelect(gameAction);
                }
            }
        }

        public TFieldControl this[ushort x, ushort y]
        {
            get
            {
                return layoutPanel.Controls[y * 3 + x] as TFieldControl;
            }
        }

        public IEnumerable<TFieldControl> Fields
        {
            get
            {
                for (ushort y = 0; y < 3; y++)
                {
                    for (ushort x = 0; x < 3; x++)
                    {
                        yield return this[x, y];
                    }
                }
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            var geometry = new SquareGridGeometry(BoardSize, BoardSize, this.Width, this.Height, 5);
            var cell = geometry.GetCellCoordinates(e.X, e.Y);

            if (cell.HasValue)
            {
                //this.RaiseFieldSelect(cell.Value.ToGameAction());
            }
        }
    }
}

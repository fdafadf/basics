﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Labs.Agents.Forms
{
    public partial class PropertyGridForm : Form
    {
        public PropertyGrid PropertyGrid => propertyGrid1;
        public Action OKAction;

        public PropertyGridForm()
        {
            InitializeComponent();
        }

        public PropertyGridForm(string title) : this()
        {
            Text = title;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    if (PropertyGrid.SelectedObject is IValidatable validatable)
                    {
                        validatable.Validate();
                        OKAction?.Invoke();
                    }
                    else
                    {
                        OKAction?.Invoke();
                    }
                }
                catch (Exception exception)
                {
                    e.Cancel = true;
                    MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

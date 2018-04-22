using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA_blth_n_tray
{
    public partial class HotKeyForm : Form
    {
        public volatile MainForm.HotKeyCommands actualHotKeyCommads = null;
        public MainForm.HotKeyCommands newHotKeyCommads = new MainForm.HotKeyCommands();

        public SortedSet<Keys> changedKeys = null;
        public TextBox changedBox = null;

        public bool catchKeys = false;

        public HotKeyForm()
        {
            InitializeComponent();
        }

        private void selectCombo()
        {
            if (catchKeys)
            {
                changedBox.HideSelection = false;

                changedBox.SelectAll();
            }
        }

        private void deSelectCombo()
        {
            if (catchKeys)
            {
                changedBox.HideSelection = true;

                changedBox.DeselectAll();
            }
        }

        private void HotKeyForm_Load(object sender, EventArgs e)
        {
            newHotKeyCommads.Assign(actualHotKeyCommads);


            refreshTextBoxHotCombinations();
        }

        private void refreshTextBoxHotCombinations()
        {
            catchHotKeysMethod(newHotKeyCommads.breakControl, breakTextBox);

            catchHotKeysMethod(newHotKeyCommads.nextPC, nextTextBox);
            catchHotKeysMethod(newHotKeyCommads.previousPC, previousTextBox);

            catchHotKeysMethod(newHotKeyCommads._1PC, PC1_TextBox);
            catchHotKeysMethod(newHotKeyCommads._2PC, PC2_TextBox);
            catchHotKeysMethod(newHotKeyCommads._3PC, PC3_TextBox);
            catchHotKeysMethod(newHotKeyCommads._4PC, PC4_TextBox);
            catchHotKeysMethod(newHotKeyCommads._5PC, PC5_TextBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads.breakControl;
            changedBox = this.breakTextBox;
            catchKeys = true;

            selectCombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads.nextPC;
            changedBox = this.nextTextBox;
            catchKeys = true;

            selectCombo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads.previousPC;
            changedBox = this.previousTextBox;
            catchKeys = true;

            selectCombo();
        }

        private void PC1_TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PC2_TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PC3_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads._1PC;
            changedBox = this.PC1_TextBox;
            catchKeys = true;

            selectCombo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads._2PC;
            changedBox = this.PC2_TextBox;
            catchKeys = true;

            selectCombo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads._3PC;
            changedBox = this.PC3_TextBox;
            catchKeys = true;

            selectCombo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads._4PC;
            changedBox = this.PC4_TextBox;
            catchKeys = true;

            selectCombo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            changedKeys = newHotKeyCommads._5PC;
            changedBox = this.PC5_TextBox;
            catchKeys = true;

            selectCombo();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainForm.ResetHotKeys(newHotKeyCommads);
            refreshTextBoxHotCombinations();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            actualHotKeyCommads.Assign(newHotKeyCommads);
            this.Close();
        }

        private static void catchHotKeysMethod(SortedSet<Keys> keys, TextBox textbox)
        {
            textbox.Text = "";
            foreach (var item in keys)
            {
                if (!string.IsNullOrWhiteSpace(textbox.Text))
                {
                    textbox.Text += "+";
                }
                textbox.Text += item.ToString();
            }
        }

        public void updateKeys(SortedSet<Keys> keys)
        {
            if (catchKeys)
            {
                changedKeys.Clear();
                foreach (var item in keys)
                {
                    changedKeys.Add(item);
                }
                catchHotKeysMethod(changedKeys, changedBox);

                selectCombo();
            }
        }

        public void finishKeys(SortedSet<Keys> keys)
        {
            if (catchKeys)
            {
                deSelectCombo();
                changedKeys = null;
                changedBox = null;
                catchKeys = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExWin
{
    public partial class Form1 : Form
    {


        Game game = new Game(1);

        new void Update()
        {
            label1.Text = game.GetDesc();
            label1.MaximumSize = new Size(800,400);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Button[] btns = new Button[] { button1, button2, button3, button4 };
            for (int i = 0; i < btns.Length; i++)
                btns[i].Visible = false;

            string[] acts = game.GetActions();
            for (int i = 0; i < acts.Length && i < 4; i++)
            {
                btns[i].Visible = true;
                btns[i].Text = acts[i];
            }
        }

        public Form1()
        {
            InitializeComponent();
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.DoAction(0);
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.DoAction(1);
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.DoAction(2);
            Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.DoAction(3);
            Update();
        }

       
    }
}

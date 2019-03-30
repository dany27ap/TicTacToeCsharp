using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe {
    public partial class Form1 : Form {

        bool turn = true;
        int turnCount = 0;

        public Form1() {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Credits Danny Mns.\nUser friendly", "X & 0");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e) {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "0";

            turn = !turn;
            b.Enabled = false;
            turnCount++;

            checkForWinner();
        }

        private void checkForWinner() {
            bool existWinner = false;
            foreach(Control c in Controls) {
                //horizontal
                if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    existWinner = true;
                else if ((A4.Text == A5.Text) && (A5.Text == A6.Text) && (!A4.Enabled))
                    existWinner = true;
                else if ((A7.Text == A8.Text) && (A8.Text == A9.Text) && (!A7.Enabled))
                    existWinner = true;
                //vertical
                if ((A1.Text == A4.Text) && (A4.Text == A7.Text) && (!A1.Enabled))
                    existWinner = true;
                else if ((A2.Text == A5.Text) && (A5.Text == A8.Text) && (!A2.Enabled))
                    existWinner = true;
                else if ((A3.Text == A6.Text) && (A6.Text == A9.Text) && (!A3.Enabled))
                    existWinner = true;
                //diagonal
                if ((A1.Text == A5.Text) && (A5.Text == A9.Text) && (!A1.Enabled))
                    existWinner = true;
                else if ((A3.Text == A5.Text) && (A5.Text == A7.Text) && (!A3.Enabled))
                    existWinner = true;


                if (existWinner) {
                    disableButtons();
                    String winner = "";
                    if (turn) {
                        winner = "0";
                    } else {
                        winner = "X";
                    }
                    MessageBox.Show("Winner is " + winner, "Result");
                } else {
                    if(turnCount == 9) {
                        MessageBox.Show("Equals", "Stop");
                    }
                }
            }
        }

        private void disableButtons() {
            try {
                foreach (Control c in Controls) {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            } catch {
                Exception e;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
            turn = true;
            turnCount = 0;

            try {
                foreach(Control c in Controls) {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            } catch { }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace greekLetterProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score = 0;
        int group = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            submitAnswerButton.Enabled = false;
        }

        private void submitAnswerButton_Click(object sender, EventArgs e)
        {
            SubmitAnswer();
        }

        private void SubmitAnswer()
        {
            if (submitAnswerButton.Text == "Avgi svar")
            {
                submitAnswerButton.Text = "Neste";
                UpdateLabels();
            }
            else
            {
                submitAnswerButton.Text = "Avgi svar";
                group += 1;
                if (group < 7)
                {
                    UpdateLabels();
                }

                if (group == 7)
                {
                    DialogResult answer = MessageBox.Show("Du fikk " + score + "/" + (group - 1) * 4 + "\n \n Vil du starte på nytt?", "Resultattavle", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        Reset();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }

        private void UpdateLabels()
        {
            groupLabel.Text = "Group " + group;
            scoreLabel.Text = "Score " + score + "/" + group * 4;
        }

        private void Reset()
        {
            score = 0;
            group = 1;
            UpdateLabels();
        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            submitAnswerButton.Enabled = true;
        }

        private Point firstPoint = new Point();

        private void DragAndDrop(Label label)
        {
            label.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    firstPoint = Control.MousePosition;
                }
            };

            label.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    label.BringToFront();
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);
                    label.Location = new Point(label.Location.X - res.X, label.Location.Y - res.Y);
                    firstPoint = temp;
                }
            };

            label.MouseUp += (ss, ee) =>
            {
                if (label.Bounds.IntersectsWith(letterPicture1.Bounds))
                {

                }
            };
        }

        private void nameLabel1_Click(object sender, EventArgs e)
        {
            DragAndDrop(nameLabel1);
        }

        private void nameLabel2_Click(object sender, EventArgs e)
        {
            DragAndDrop(nameLabel2);
        }

        private void nameLabel3_Click(object sender, EventArgs e)
        {
            DragAndDrop(nameLabel3);
        }

        private void nameLabel4_Click(object sender, EventArgs e)
        {
            DragAndDrop(nameLabel4);
        }
    }
}

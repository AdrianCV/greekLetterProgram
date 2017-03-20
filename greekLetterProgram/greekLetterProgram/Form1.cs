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

        List<PictureInfo> pictureInfoList = new List<PictureInfo>();

        private void Form1_Load(object sender, EventArgs e)
        {
            submitAnswerButton.Enabled = false;
            DragAndDrop(nameLabel1);
            DragAndDrop(nameLabel2);
            DragAndDrop(nameLabel3);
            DragAndDrop(nameLabel4);
        }

        private void ListAdd()
        {
            pictureInfoList.Add(new PictureInfo("Alpha", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Beta", @"GreekLetter\UpperCaseBeta.png", @"GreekLetter\LowerCaseBeta.png"));
            pictureInfoList.Add(new PictureInfo("Gamma", @"GreekLetter\UpperCaseGamma.png", @"GreekLetter\LowerCaseGamma.png"));
            pictureInfoList.Add(new PictureInfo("Delta", @"GreekLetter\UpperCaseDelta.png", @"GreekLetter\LowerCaseDelta.png"));
            pictureInfoList.Add(new PictureInfo("Epsilon", @"GreekLetter\UpperCaseEpsilon.png", @"GreekLetter\LowerCaseEpsilon.png"));
            pictureInfoList.Add(new PictureInfo("Zeta", @"GreekLetter\UpperCaseZeta.png", @"GreekLetter\LowerCaseZeta.png"));
            pictureInfoList.Add(new PictureInfo("Eta", @"GreekLetter\UpperCaseEta.png", @"GreekLetter\LowerCaseEta.png"));
            pictureInfoList.Add(new PictureInfo("Theta", @"GreekLetter\UpperCaseTheta.png", @"GreekLetter\LowerCaseTheta.png"));
            pictureInfoList.Add(new PictureInfo("Iota", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Kappa", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Lambda", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Mu", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Nu", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Xi", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Omicron", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Pi", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Rho", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Sigma", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Tau", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Upsilon", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Phi", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Chi", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Psi", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Omega", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
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
                nameLabel1.Enabled = true;
                nameLabel2.Enabled = true;
                nameLabel3.Enabled = true;
                nameLabel4.Enabled = true;
                submitAnswerButton.Text = "Avgi svar";
                group += 1;
                if (group < 7)
                {
                    UpdateLabels();
                    ResetPosition();
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
                    LockPosition(label, letterPicture1);
                }
                else if (label.Bounds.IntersectsWith(letterPicture2.Bounds))
                {
                    LockPosition(label, letterPicture2);
                }
                else if (label.Bounds.IntersectsWith(letterPicture3.Bounds))
                {
                    LockPosition(label, letterPicture3);
                }
                else if (label.Bounds.IntersectsWith(letterPicture4.Bounds))
                {
                    LockPosition(label, letterPicture4);
                }
            };
        }

        private void LockPosition(Label label, PictureBox PBox)
        {
            if ((nameLabel1.Location.X == PBox.Location.X + 100 && nameLabel1.Location.Y == PBox.Location.Y + 54)||
                (nameLabel2.Location.X == PBox.Location.X + 100 && nameLabel2.Location.Y == PBox.Location.Y + 54)||
                (nameLabel3.Location.X == PBox.Location.X + 100 && nameLabel3.Location.Y == PBox.Location.Y + 54)||
                (nameLabel4.Location.X == PBox.Location.X + 100 && nameLabel4.Location.Y == PBox.Location.Y + 54))
            {
                ResetPosition(label);
            }
            else
            {
                label.Location = new Point(PBox.Location.X + 100, PBox.Location.Y + 54);
                label.Enabled = false;
            }

            if (nameLabel1.Enabled==false && nameLabel2.Enabled == false && nameLabel3.Enabled == false && nameLabel4.Enabled == false)
            {
                submitAnswerButton.Enabled = true;
            }
        }

        private void ResetPosition()
        {
            nameLabel1.Location = new Point(552, 74);
            nameLabel2.Location = new Point(552, 122);
            nameLabel3.Location = new Point(552, 170);
            nameLabel4.Location = new Point(552, 218);
        }

        private void ResetPosition(Label label)
        {
            label.Location = new Point(552, 74);
            if (label.Bounds.IntersectsWith(nameLabel1.Bounds) && !(label.Text == nameLabel1.Text) || label.Bounds.IntersectsWith(nameLabel2.Bounds) && !(label.Text == nameLabel2.Text) || label.Bounds.IntersectsWith(nameLabel3.Bounds) && !(label.Text == nameLabel3.Text) || label.Bounds.IntersectsWith(nameLabel4.Bounds) && !(label.Text == nameLabel4.Text))
            {
                label.Location = new Point(label.Location.X, label.Location.Y + 48);
            }
            if (label.Bounds.IntersectsWith(nameLabel1.Bounds) && !(label.Text == nameLabel1.Text) || label.Bounds.IntersectsWith(nameLabel2.Bounds) && !(label.Text == nameLabel2.Text) || label.Bounds.IntersectsWith(nameLabel3.Bounds) && !(label.Text == nameLabel3.Text) || label.Bounds.IntersectsWith(nameLabel4.Bounds) && !(label.Text == nameLabel4.Text))
            {
                label.Location = new Point(label.Location.X, label.Location.Y + 48);
            }
            if (label.Bounds.IntersectsWith(nameLabel1.Bounds) && !(label.Text == nameLabel1.Text) || label.Bounds.IntersectsWith(nameLabel2.Bounds) && !(label.Text == nameLabel2.Text) || label.Bounds.IntersectsWith(nameLabel3.Bounds) && !(label.Text == nameLabel3.Text) || label.Bounds.IntersectsWith(nameLabel4.Bounds) && !(label.Text == nameLabel4.Text))
            {
                label.Location = new Point(label.Location.X, label.Location.Y + 48);
            }
        }
    }
}

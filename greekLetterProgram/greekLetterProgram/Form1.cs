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
using System.Media;

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
            ListAdd();
            ChangeInfo();
            background.PlayLooping();
        }

        //Legger alle bildene inn i en liste
        private void ListAdd()
        {
            pictureInfoList.Add(new PictureInfo("Alpha", @"GreekLetter\UpperCaseAlpha.png", @"GreekLetter\LowerCaseAlpha.png"));
            pictureInfoList.Add(new PictureInfo("Gamma", @"GreekLetter\UpperCaseGamma.png", @"GreekLetter\LowerCaseGamma.png"));
            pictureInfoList.Add(new PictureInfo("Iota", @"GreekLetter\UpperCaseIota.png", @"GreekLetter\LowerCaseIota.png"));
            pictureInfoList.Add(new PictureInfo("Delta", @"GreekLetter\UpperCaseDelta.png", @"GreekLetter\LowerCaseDelta.png"));
            pictureInfoList.Add(new PictureInfo("Xi", @"GreekLetter\UpperCaseXi.png", @"GreekLetter\LowerCaseXi.png"));
            pictureInfoList.Add(new PictureInfo("Beta", @"GreekLetter\UpperCaseBeta.png", @"GreekLetter\LowerCaseBeta.png"));
            pictureInfoList.Add(new PictureInfo("Chi", @"GreekLetter\UpperCaseChi.png", @"GreekLetter\LowerCaseChi.png"));
            pictureInfoList.Add(new PictureInfo("Epsilon", @"GreekLetter\UpperCaseEpsilon.png", @"GreekLetter\LowerCaseEpsilon.png"));
            pictureInfoList.Add(new PictureInfo("Rho", @"GreekLetter\UpperCaseRho.png", @"GreekLetter\LowerCaseRho.png"));
            pictureInfoList.Add(new PictureInfo("Zeta", @"GreekLetter\UpperCaseZeta.png", @"GreekLetter\LowerCaseZeta.png"));
            pictureInfoList.Add(new PictureInfo("Nu", @"GreekLetter\UpperCaseNu.png", @"GreekLetter\LowerCaseNu.png"));
            pictureInfoList.Add(new PictureInfo("Eta", @"GreekLetter\UpperCaseEta.png", @"GreekLetter\LowerCaseEta.png"));
            pictureInfoList.Add(new PictureInfo("Sigma", @"GreekLetter\UpperCaseSigma.png", @"GreekLetter\LowerCaseSigma.png"));
            pictureInfoList.Add(new PictureInfo("Omega", @"GreekLetter\UpperCaseOmega.png", @"GreekLetter\LowerCaseOmega.png"));
            pictureInfoList.Add(new PictureInfo("Kappa", @"GreekLetter\UpperCaseKappa.png", @"GreekLetter\LowerCaseKappa.png"));
            pictureInfoList.Add(new PictureInfo("Pi", @"GreekLetter\UpperCasePi.png", @"GreekLetter\LowerCasePi.png"));
            pictureInfoList.Add(new PictureInfo("Upsilon", @"GreekLetter\UpperCaseUpsilon.png", @"GreekLetter\LowerCaseUpsilon.png"));
            pictureInfoList.Add(new PictureInfo("Mu", @"GreekLetter\UpperCaseMu.png", @"GreekLetter\LowerCaseMu.png"));
            pictureInfoList.Add(new PictureInfo("Omicron", @"GreekLetter\UpperCaseOmicron.png", @"GreekLetter\LowerCaseOmicron.png"));
            pictureInfoList.Add(new PictureInfo("Tau", @"GreekLetter\UpperCaseTau.png", @"GreekLetter\LowerCaseTau.png"));
            pictureInfoList.Add(new PictureInfo("Psi", @"GreekLetter\UpperCasePsi.png", @"GreekLetter\LowerCasePsi.png"));
            pictureInfoList.Add(new PictureInfo("Theta", @"GreekLetter\UpperCaseTheta.png", @"GreekLetter\LowerCaseTheta.png"));
            pictureInfoList.Add(new PictureInfo("Phi", @"GreekLetter\UpperCasePhi.png", @"GreekLetter\LowerCasePhi.png"));
            pictureInfoList.Add(new PictureInfo("Lambda", @"GreekLetter\UpperCaseLambda.png", @"GreekLetter\LowerCaseLambda.png"));
        }

        //Legger til lydfiler
        SoundPlayer background = new SoundPlayer(@"GreekLetter\FunkyBassShit.wav");
        SoundPlayer fullScore = new SoundPlayer(@"GreekLetter\SexySlideShit.wav");
        SoundPlayer lowScore = new SoundPlayer(@"GreekLetter\SadGuitarShit.wav");

        //endrer info i pricturebox og label
        private void ChangeInfo()
        {
            //Bruker randomgenerator for å velge små eller store bokstaver
            Random rdm = new Random();
            int random = rdm.Next(0, 2);
            nameLabel1.Text = pictureInfoList[4 * group - 4].LetterName;
            nameLabel2.Text = pictureInfoList[4 * group - 3].LetterName;
            nameLabel3.Text = pictureInfoList[4 * group - 2].LetterName;
            nameLabel4.Text = pictureInfoList[4 * group - 1].LetterName;
            if (random == 0)
            {
                letterPicture1.ImageLocation = pictureInfoList[4 * group - 4].LowerLink;
                letterPicture2.ImageLocation = pictureInfoList[4 * group - 3].LowerLink;
                letterPicture3.ImageLocation = pictureInfoList[4 * group - 2].LowerLink;
                letterPicture4.ImageLocation = pictureInfoList[4 * group - 1].LowerLink;
            }
            else
            {
                letterPicture1.ImageLocation = pictureInfoList[4 * group - 4].UpperLink;
                letterPicture2.ImageLocation = pictureInfoList[4 * group - 3].UpperLink;
                letterPicture3.ImageLocation = pictureInfoList[4 * group - 2].UpperLink;
                letterPicture4.ImageLocation = pictureInfoList[4 * group - 1].UpperLink;
            }
            RandomLocation();
        }

        //Bruker randomgenerator til å stokke om labels
        private void RandomLocation()
        {
            Random rdm = new Random();
            int random = rdm.Next(0, 24);
            int[] combinations = { 1234, 1243, 1324, 1342, 1423, 1432, 2134, 2143, 2314, 2341, 2413, 2431, 3124, 3142, 3214, 3241, 3412, 3421, 4123, 4132, 4213, 4231, 4312, 4321 };

            #region NoOpen
            if (combinations[random] / 1000 == 1)
            {
                LabelPosition(nameLabel1, 1);
            }
            else if (combinations[random] / 1000 == 2)
            {
                LabelPosition(nameLabel2, 1);
            }
            else if (combinations[random] / 1000 == 3)
            {
                LabelPosition(nameLabel3, 1);
            }
            else if (combinations[random] / 1000 == 4)
            {
                LabelPosition(nameLabel4, 1);
            }
            if ((combinations[random] / 100)%10 == 1)
            {
                LabelPosition(nameLabel1, 2);
            }
            else if ((combinations[random] / 100) % 10 == 2)
            {
                LabelPosition(nameLabel2, 2);
            }
            else if ((combinations[random] / 100) % 10 == 3)
            {
                LabelPosition(nameLabel3, 2);
            }
            else if ((combinations[random] / 100) % 10 == 4)
            {
                LabelPosition(nameLabel4, 2);
            }
            if ((combinations[random] / 10) % 100 % 10 == 1)
            {
                LabelPosition(nameLabel1, 3);
            }
            else if ((combinations[random] / 10) % 100 % 10 == 2)
            {
                LabelPosition(nameLabel2, 3);
            }
            else if ((combinations[random] / 10) % 100 % 10 == 3)
            {
                LabelPosition(nameLabel3, 3);
            }
            else if ((combinations[random] / 10) % 100 % 10 == 4)
            {
                LabelPosition(nameLabel4, 3);
            }
            if (combinations[random] % 1000 % 100 % 10 == 1)
            {
                LabelPosition(nameLabel1, 4);
            }
            else if (combinations[random] % 1000 % 100 % 10 == 2)
            {
                LabelPosition(nameLabel2, 4);
            }
            else if (combinations[random] % 1000 % 100 % 10 == 3)
            {
                LabelPosition(nameLabel3, 4);
            }
            else if (combinations[random] % 1000 % 100 % 10 == 4)
            {
                LabelPosition(nameLabel4, 4);
            }
            #endregion NoOpen
        }

        //Plasserer labels i henhold til posisjonen de fikk i RandomLocation()
        private void LabelPosition(Label label, int position)
        {
            if (position == 1)
            {
                label.Location = new Point(552, 74);
            }
            else if (position == 2)
            {
                label.Location = new Point(552, 122);
            }
            else if (position == 3)
            {
                label.Location = new Point(552, 170);
            }
            else
            {
                label.Location = new Point(552, 218);
            }
        }

        private void submitAnswerButton_Click(object sender, EventArgs e)
        {
            SubmitAnswer();
        }

        //Regner ut score og gjør klar neste gruppe med bilder og labels, viser også resultatvindu når spillet er over
        private void SubmitAnswer()
        {
            if (submitAnswerButton.Text == "Avgi svar")
            {
                submitAnswerButton.Text = "Neste";
                Score();
                UpdateLabels();
            }
            else
            {
                submitAnswerButton.Enabled = false;
                nameLabel1.Enabled = true;
                nameLabel2.Enabled = true;
                nameLabel3.Enabled = true;
                nameLabel4.Enabled = true;
                feedbackPicture1.Image = null;
                feedbackPicture2.Image = null;
                feedbackPicture3.Image = null;
                feedbackPicture4.Image = null;
                submitAnswerButton.Text = "Avgi svar";
                group += 1;
                if (group < 7)
                {
                    UpdateLabels();
                    ResetPosition();
                }

                if (group == 7)
                {
                    background.Stop();
                    if (score == 24)
                    {
                        fullScore.Play();
                    }
                    else
                    {
                        lowScore.Play();
                    }

                    DialogResult answer = MessageBox.Show("Du fikk " + score + "/" + (group - 1) * 4 + "\n \n Vil du starte på nytt?", "Resultattavle", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        Reset();
                    }
                    else
                    {
                        Close();
                        return;
                    }
                }
                ChangeInfo();
            }
        }

        //Sjekker posisjonen til alle labels og regner ut score. Viser relevante feedback-bilder
        private void Score()
        {
            if (nameLabel1.Location.X == letterPicture1.Location.X + 110 && nameLabel1.Location.Y == letterPicture1.Location.Y + 54)
            {
                feedbackPicture1.ImageLocation = @"GreekLetter\FeedBackRight.png";
                score++;
            }
            else
            {
                feedbackPicture1.ImageLocation = @"GreekLetter\FeedBackWrong.png";
            }
            if (nameLabel2.Location.X == letterPicture2.Location.X + 110 && nameLabel2.Location.Y == letterPicture2.Location.Y + 54)
            {
                feedbackPicture2.ImageLocation = @"GreekLetter\FeedBackRight.png";
                score++;
            }
            else
            {
                feedbackPicture2.ImageLocation = @"GreekLetter\FeedBackWrong.png";
            }
            if (nameLabel3.Location.X == letterPicture3.Location.X + 110 && nameLabel3.Location.Y == letterPicture3.Location.Y + 54)
            {
                feedbackPicture3.ImageLocation = @"GreekLetter\FeedBackRight.png";
                score++;
            }
            else
            {
                feedbackPicture3.ImageLocation = @"GreekLetter\FeedBackWrong.png";
            }
            if (nameLabel4.Location.X == letterPicture4.Location.X + 110 && nameLabel4.Location.Y == letterPicture4.Location.Y + 54)
            {
                feedbackPicture4.ImageLocation = @"GreekLetter\FeedBackRight.png";
                score++;
            }
            else
            {
                feedbackPicture4.ImageLocation = @"GreekLetter\FeedBackWrong.png";
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
            background.PlayLooping();
        }

        private Point firstPoint = new Point();

        //Håndterer bevegelse av labels og kjører låserutinen
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
                if (!label.Bounds.IntersectsWith(panel1.Bounds))
                {
                    ResetPosition(label);
                }
            };
        }

        //Låser posisjonen til labels til et bestemt punkt i forhold til bildene
        private void LockPosition(Label label, PictureBox PBox)
        {
            if ((nameLabel1.Location.X == PBox.Location.X + 110 && nameLabel1.Location.Y == PBox.Location.Y + 54)||
                (nameLabel2.Location.X == PBox.Location.X + 110 && nameLabel2.Location.Y == PBox.Location.Y + 54)||
                (nameLabel3.Location.X == PBox.Location.X + 110 && nameLabel3.Location.Y == PBox.Location.Y + 54)||
                (nameLabel4.Location.X == PBox.Location.X + 110 && nameLabel4.Location.Y == PBox.Location.Y + 54))
            {
                ResetPosition(label);
            }
            else
            {
                label.Location = new Point(PBox.Location.X + 110, PBox.Location.Y + 54);
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

        //Plasserer labels i først ledige plass
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

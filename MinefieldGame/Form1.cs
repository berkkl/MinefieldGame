using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace MinefieldGame
{
    public partial class Minefield : Form
    {

        Random r = new Random();
        int myBombNumber_1;
        int myBombNumber_2;
        int myBombNumber_3;
        List<int> myBombNumbers = new List<int>();
        int playerPoints = 0;
        int playerHealth = 3;
        int tilesOpened = 0;

        public Minefield()
        {
            InitializeComponent();
        }
        public int getRandomNumber()
        {
            return r.Next(1, 10);
        }

        public void enableButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            restartButton.Enabled = true;
        }

        public void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
        }

        public void resetBackgrounds()
        {
            button1.BackgroundImage = Properties.Resources.mine;
            button2.BackgroundImage = Properties.Resources.mine;
            button3.BackgroundImage = Properties.Resources.mine;
            button4.BackgroundImage = Properties.Resources.mine;
            button5.BackgroundImage = Properties.Resources.mine;
            button6.BackgroundImage = Properties.Resources.mine;
            button7.BackgroundImage = Properties.Resources.mine;
            button8.BackgroundImage = Properties.Resources.mine;
            button9.BackgroundImage = Properties.Resources.mine;
            button10.BackgroundImage = Properties.Resources.mine;
            button11.BackgroundImage = Properties.Resources.mine;
            button12.BackgroundImage = Properties.Resources.mine;
            button13.BackgroundImage = Properties.Resources.mine;
            button14.BackgroundImage = Properties.Resources.mine;
            button15.BackgroundImage = Properties.Resources.mine;
            button16.BackgroundImage = Properties.Resources.mine;
        }

        public void resetBombPlaces()
        {
            myBombNumbers.Clear();
            myBombNumber_1 = r.Next(1, 17);
            myBombNumbers.Add(myBombNumber_1);
            do { myBombNumber_2 = r.Next(1, 17); }
            while (myBombNumbers.Contains(myBombNumber_2));
            myBombNumbers.Add((int)myBombNumber_2);
            do { myBombNumber_3 = r.Next(1, 17); }
            while (myBombNumbers.Contains(myBombNumber_3));
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "WELCOME!";
            label2.Text = "Points: ";
            restartButton.Text = "RESTART";
            startButton.Enabled = true;
            restartButton.Enabled = false;
            disableButtons();
        }

        public Image imageList(int myNumber)
        {
            Image[] myImages = new Image[]
            {
                Properties.Resources._1,
                Properties.Resources._2,
                Properties.Resources._3,
                Properties.Resources._4,
                Properties.Resources._5,
                Properties.Resources._6,
                Properties.Resources._7,
                Properties.Resources._8,
                Properties.Resources._9,
            };

            return myImages[myNumber - 1];
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            enableButtons();
            startButton.Enabled = false;
            myBombNumber_1 = r.Next(1, 17);
            myBombNumbers.Add(myBombNumber_1);
            do { myBombNumber_2 = r.Next(1, 17); }
            while (myBombNumbers.Contains(myBombNumber_2));
            myBombNumbers.Add((int)myBombNumber_2);
            do { myBombNumber_3 = r.Next(1, 17); }
            while (myBombNumbers.Contains(myBombNumber_3));
            label1.Text = "Healths left: " + playerHealth;
            label2.Visible = true;
            label2.Text = "Points: " + playerPoints;
        }

        private void my_buttons(object sender, EventArgs e)
        {
            int myNumber = getRandomNumber();
            Button clicked_button = (Button)sender;
            clicked_button.Enabled = false;
            int button_id = Convert.ToInt32(clicked_button.Name.Substring(6));
            tilesOpened++;

            if (myBombNumber_1 == button_id || myBombNumber_2 == button_id || myBombNumber_3 == button_id)
            {
                clicked_button.BackgroundImage = Properties.Resources.bomb;
                playerHealth--;
                label1.Text = "Healths left: " + playerHealth;
                if (playerHealth == 0)
                {
                    disableButtons();
                    label1.Text = "GAME OVER, TRY AGAIN!";
                }
            }
            else
            {
                clicked_button.BackgroundImage = imageList(myNumber);
                playerPoints += myNumber;
                label2.Text = "Points: " + playerPoints;
            }
            if (tilesOpened + playerHealth == 16)
            {
                disableButtons();
                label1.Text = "Congratulations! Your score is: " + playerPoints;
                startButton.Enabled = true;
            }
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            disableButtons();
            resetBackgrounds();
            resetBombPlaces();
            startButton.Enabled = true;
            playerHealth = 3;
            playerPoints = 0;
            tilesOpened = 0;
            label1.Text = "Click START to play again!";
        }
    }
}

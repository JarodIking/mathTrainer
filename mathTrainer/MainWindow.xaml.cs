using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mathTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //constructor-----------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

        }

        //variables & arrays & objects----------------------------------------------------
        private int level = 0;
        private int correct = 0;
        private int wrong = 0;
        private int i = 0;
        private int gameLength = 5;
        private int playerAns = 0;

        sumGeneration sumMaker = null;

        //properties------------------------------------------------------------


        //methods---------------------------------------------------------------
        private void Start(object sender, RoutedEventArgs e)
        {
            if(level == 0)
            {
                MessageBox.Show("Please choose a level");
                return;
            }

            if(playerName.Text == "")
            {
                MessageBox.Show("Please enter a name");
                return;
            } 

            createSumObject(level, correct, wrong);

            switch (sumMaker.Level)
            {
                case 1:
                    number1.Content = sumMaker.nums1[i];
                    if (sumMaker.operators[i] == 0)
                        operator0.Content = "-";
                    else
                        operator0.Content = "+";
                    number2.Content = sumMaker.nums2[i];
                    break;

                case 2:
                    number1.Content = sumMaker.nums3[i];
                    if (sumMaker.operators[i] == 0)
                        operator0.Content = ":";
                    else
                        operator0.Content = "X";
                    number2.Content = sumMaker.nums4[i];
                    break;

                case 3:
                    number1.Content = sumMaker.nums5[i];
                    switch (sumMaker.operators2[i])
                    {
                        case 0:
                            operator0.Content = "+";
                            break;

                        case 1:
                            operator0.Content = "-";
                            break;

                        case 2:
                            operator0.Content = "X";
                            break;

                        case 3:
                            operator0.Content = ":";
                            break;
                    }
                    number2.Content = sumMaker.nums6[i];

                    break;
            }

            MessageBox.Show("Start maar " + sumMaker.Name + " en veel success!");
        }

        private void Set_Level(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int value = int.Parse(button.Tag.ToString());
            level = value;
            levelIndicator.Content = value;
        }

        private void Next_Question(object sender, RoutedEventArgs e)
        {
            if (sumMaker == null)
                return;

            switch (sumMaker.Level)
            {
                case 1:
                    if (Check_Completion(i, gameLength))
                        break;

                    i++;

                    number1.Content = sumMaker.nums1[i];
                    if (sumMaker.operators[i] == 0)
                        operator0.Content = "-";
                    else
                        operator0.Content = "+";
                    number2.Content = sumMaker.nums2[i];

                    break;

                case 2:
                    if (Check_Completion(i, gameLength))
                        break;

                    i++;

                    number1.Content = sumMaker.nums3[i];
                    if (sumMaker.operators1[i] == 0)
                        operator0.Content = ":";
                    else
                        operator0.Content = "X";
                    number2.Content = sumMaker.nums4[i];

                    break;

                case 3:
                    if (Check_Completion(i, gameLength))
                        break;

                    i++;

                    number1.Content = sumMaker.nums5[i];
                    switch (sumMaker.operators2[i])
                    {
                        case 0:
                            operator0.Content = "+";
                            break;

                        case 1:
                            operator0.Content = "-";
                            break;

                        case 2:
                            operator0.Content = "X";
                            break;

                        case 3:
                            operator0.Content = ":";
                            break;
                    }
                    number2.Content = sumMaker.nums6[i];
                    
                    break;
            }
        }

        private void Check_Answer(object sender, RoutedEventArgs e)
        {
            if (sumMaker == null)
                return;

            if (!int.TryParse(playerAnswer.Text, out playerAns))
            {
                MessageBox.Show("please enter a number!");
                return;
            }

            switch (sumMaker.Level)
            {
                case 1:
                    if (Int32.Parse(playerAnswer.Text) == sumMaker.answers[i])
                    {
                        MessageBox.Show("correct!");
                        sumMaker.Correct++;
                        correctIndicator.Content = sumMaker.Correct;
                    }
                    else
                    {
                        MessageBox.Show("wrong! Answer was " + Convert.ToString(sumMaker.answers[i]));
                        sumMaker.Wrong++;
                        incorrectIndicator.Content = sumMaker.Wrong;
                    }
                    break;

                case 2:
                    if (Int32.Parse(playerAnswer.Text) == sumMaker.answers1[i])
                    {
                        MessageBox.Show("correct!");
                        sumMaker.Correct++;
                        correctIndicator.Content = sumMaker.Correct;
                    }
                    else
                    {
                        MessageBox.Show("wrong! Answer was: " + Convert.ToString(sumMaker.answers1[i]));
                        sumMaker.Wrong++;
                        incorrectIndicator.Content = sumMaker.Wrong;
                    }
                    break;

                case 3:
                    if (Int32.Parse(playerAnswer.Text) == sumMaker.answers2[i])
                    {
                        MessageBox.Show("correct!");
                        sumMaker.Correct++;
                        correctIndicator.Content = sumMaker.Correct;
                    }
                    else
                    {
                        MessageBox.Show("wrong! Answer was: " + Convert.ToString(sumMaker.answers2[i]));
                        sumMaker.Wrong++;
                        incorrectIndicator.Content = sumMaker.Wrong;
                    }
                    break;
            }
        }

        private bool Check_Completion(int a, int lng)
        {
            MessageBox.Show(Convert.ToString(i) + " " + Convert.ToString(lng));

            if (a == lng - 1)
            {
                MessageBox.Show("you finished the game!");
                sumMaker = null;
                i = 0;
                level = 0;
                correct = 0;
                wrong = 0;
                playerAns = 0;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void createSumObject(int lvl, int cor, int wro)
        {
            if(level != 0)
            {
                sumMaker = new sumGeneration(lvl, cor, wro, gameLength);
                sumMaker.Name = playerName.Text;
                sumMaker.Level = level;
                sumMaker.Start();
            }
        }
    }
}

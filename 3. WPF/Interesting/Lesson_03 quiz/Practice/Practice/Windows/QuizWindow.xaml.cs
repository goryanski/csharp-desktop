using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Practice.Models;
using Practice.Models.Helpers;

namespace Practice.Windows
{
    /// <summary>
    /// Логика взаимодействия для QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window, INotifyPropertyChanged
    {
        // что бы не создавать класс только с одним свойством, подпишемся на PropertyChanged прямо здесь 
        public event PropertyChangedEventHandler PropertyChanged;
        private string _currentQuestion = string.Empty;

        public string CurrentQuestion 
        { 
            get => _currentQuestion;
            set 
            {
                if (!_currentQuestion.Equals(value))
                {
                    _currentQuestion = value;
                    OnPropertyChanged(nameof(CurrentQuestion));
                }
            } 
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        ResultsStorage resultsStorage = ResultsStorage.Instance;
        QuizStorage quizStorage = new QuizStorage();
    
        public List<string> AnswersVariants { get; set; }
        public BindingList<Result> Results { get; set; }
        public string UserLogin { get; set; }


        const int COUNT_QUESTIONS = 10;
        int quectionCounter = 0;
        List<string> userAnswers = new List<string>();
        string userAnswer = string.Empty;
        

        public QuizWindow(string userLogin)
        {
            InitializeComponent();
            DataContext = this;
            UserLogin = userLogin;
            Title = $"Hello, {UserLogin}";

            CurrentQuestion = quizStorage.Questions[quectionCounter];
            AnswersVariants = quizStorage.AnswersVariants;
            Results = resultsStorage.Results;

            rbNotknow.IsChecked = true;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if(btnNext.Content.Equals("repeat"))
            {
                // для повтора при первом клике просто поменяем текст кнопки, и только при втором начнется прохождение опроса заново, что бы понятно все было и первый вопрос пользователь не пропустил 
                btnNext.Content = "next";
            }
            else
            {
                WriteAnswer();
                ++quectionCounter;
                if (quectionCounter < COUNT_QUESTIONS)
                {
                    userAnswers.Add(userAnswer);
                    CurrentQuestion = quizStorage.Questions[quectionCounter];
                    rbNotknow.IsChecked = true;
                }
                else
                {
                    userAnswers.Add(userAnswer); // добавим последний
                    GetResult();
                    // предоставим возможность пройти повторно
                    GoRepeat();
                }
            }          
        }

        private void GoRepeat()
        {
            quectionCounter = 0;
            CurrentQuestion = quizStorage.Questions[quectionCounter];
            rbNotknow.IsChecked = true;
            userAnswer = string.Empty;
            userAnswers = null;
            userAnswers = new List<string>();
            btnNext.Content = "repeat";
        }

        private void WriteAnswer()
        {
            // поскольку пользователь может просто проклацать кнопку Next не нажимая на RadioButton, то событие Checked у RadioButton использовать бесполезно и нужно каждый раз при нажатии на кнопку Next проверять так
            if (rbYes.IsChecked == true)
            {
                userAnswer = rbYes.Content.ToString();
            }
            else if(rbNo.IsChecked == true)
            {
                userAnswer = rbNo.Content.ToString();
            }
            else if(rbNotknow.IsChecked == true)
            {
                userAnswer = rbNotknow.Content.ToString();
            }
        }

        private void GetResult()
        {
            int countMatches = 0;
            for (int i = 0; i < COUNT_QUESTIONS; i++)
            {
                if (userAnswers[i].Equals(quizStorage.RightAnswers[i]))
                {
                    countMatches++;
                }
            }

            AddToStorage(countMatches);

            MessageBox.Show($"Your result: {countMatches} points", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddToStorage(int countMatches)
        {
            Result result = new Result
            {
                UserName = UserLogin,
                Score = countMatches
            };

            if (resultsStorage.ResultExist(result))
            {
                resultsStorage.ChangeResult(result);
            }
            else
            {
                resultsStorage.Results.Add(result);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Models;

namespace WindowsFormsApp3
{
    public partial class Form : System.Windows.Forms.Form
    {
        TestsManager testsManager = new TestsManager();
        TestValidator testValidator = new TestValidator();

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            testsManager.Load();
            LoadTestsToList();
        }

        #region ListBox SelectedIndexChanged
        private void LbTestChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            int testIdx = lbTestChoose.SelectedIndex;

            if (testIdx != -1)
            {
                Test selectedTest = lbTestChoose.SelectedItem as Test;
                // загрузка данных для выбора
                LoadQuestionsToList(selectedTest);
                // загрузка данных для редактирования
                LoadTestToEdit(selectedTest);
            }
        }
       
        private void LbQuestionChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            int questionIdx = lbQuestionChoose.SelectedIndex;

            if (questionIdx != -1)
            {              
                Question selectedQuestion = lbQuestionChoose.SelectedItem as Question;
                // загрузка данных для выбора
                LoadAnswersToList(selectedQuestion);
                // загрузка данных для редактирования
                LoadQuestionToEdit(selectedQuestion);
            }
        }

        private void LbAnswerChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            int answerIdx = lbAnswerChoose.SelectedIndex;

            if (answerIdx != -1)
            {
                Answer selectedAnswer = lbAnswerChoose.SelectedItem as Answer;
                // загрузка данных для редактирования
                LoadAnswerToEdit(selectedAnswer);
            }
        }
        #endregion

        #region Load data to choose panel
        private void LoadTestsToList()
        {
            lbTestChoose.DataSource = testsManager.Tests;
        }
        private void LoadQuestionsToList(Test selectedTest)
        {
            lbQuestionChoose.DataSource = selectedTest.Questions;
        }
        private void LoadAnswersToList(Question selectedQuestion)
        {
            lbAnswerChoose.DataSource = selectedQuestion.Answers;
        }
        #endregion

        #region Load data to edit panel
        private void LoadTestToEdit(Test selectedTest)
        {
            tbTestName.Text = selectedTest.Name;
            nudMinutesCount.Value = selectedTest.Minutes;
        }
        private void LoadQuestionToEdit(Question selectedQuestion)
        {
            tbQuestion.Text = selectedQuestion.Text;
        }
        private void LoadAnswerToEdit(Answer selectedAnswer)
        {           
            tbAnswer.Text = selectedAnswer.Text;

            // и расставим чеки заново, исходя из данных в масиве
            if (selectedAnswer.IsCorrect)
            {
                cbRightAnswer.Checked = true;
            }
            else
            {
                cbRightAnswer.Checked = false;
            }
        }

        #endregion
        

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            testValidator.CheckEditFields(tbTestName.Text, tbQuestion.Text, tbAnswer.Text);

            // если проверка прошла успешно - можем сохранять данные 
            SavingData();
            // перезагрузка данных
            ReloadData();
        }

        private void SavingData()
        {
            // редактируем данные теста
            int testIdx = lbTestChoose.SelectedIndex;
            if (testIdx != -1)
            {
                testsManager.Tests[testIdx].Name = tbTestName.Text;
                testsManager.Tests[testIdx].Minutes = Convert.ToInt32(nudMinutesCount.Value);
            }

            // редактируем вопрос выбранного теста
            int questionIdx = lbQuestionChoose.SelectedIndex;
            if (questionIdx != -1)
            {
                testsManager.Tests[testIdx].Questions[questionIdx].Text = tbQuestion.Text;
            }

            // редактируем ответ выбранного вопроса и выбранного текста
            int answerIdx = lbAnswerChoose.SelectedIndex;
            if (answerIdx != -1)
            {
                testsManager.Tests[testIdx].Questions[questionIdx].Answers[answerIdx].Text = tbAnswer.Text;
            }

            // сохраняем правильный ответ или сбрасываем правильный ответ и сохраняем
            if (cbRightAnswer.Checked)
            {
                testsManager.Tests[testIdx].Questions[questionIdx].Answers[answerIdx].IsCorrect = true;
            }
            else
            {
                testsManager.Tests[testIdx].Questions[questionIdx].Answers[answerIdx].IsCorrect = false;
            }     
        }

        private void ReloadData()
        {
            // сбрасываем все листбоксы
            lbTestChoose.DataSource = null;
            lbQuestionChoose.DataSource = null;
            lbAnswerChoose.DataSource = null;
            // перезаливаем только тесты - остальное подтянется автоматически
            LoadTestsToList();
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // сохраним в файл только по закрытию
            testsManager.SaveToFile();
        }
    }
}

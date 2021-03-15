using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using QuizApp.DataModels;
using QuizApp.Fragments;
using QuizApp.Helpers;

namespace QuizApp.Activities
{
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : AppCompatActivity
    {
        Android.Support.V7.Widget.Toolbar toolbar;

        //Instances of radio button
        RadioButton optionARadio, optionBRadio, optionCRadio, optionDRadio;

        //Instances of textviews
        TextView optionATextView, optionBTextView, optionCTextView, optionDTextView, timerCounterTextView, quizPositionTextView, questionTextView;

        //Button
        Button proceedQuizButton;

        List<Question> quizQuestionList = new List<Question>();
        QuizHelper quizHelper = new QuizHelper();

        string quizTopic;
        int quizPosition;
        double correctAnswerCount = 0;

        int timerCounter = 0;
        DateTime dateTime;
        System.Timers.Timer countDown = new System.Timers.Timer();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.quiz);

            quizTopic = Intent.GetStringExtra("topic");

            toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.quizToolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = quizTopic + "Quiz";

            Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.outline_arrowback);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            ConnectViews();
            BeginQuiz();

            //Countdown timer
            countDown.Interval = 1000;
            countDown.Elapsed += CountDown_Elapsed;
        }

        private void CountDown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerCounter++;

            DateTime dt = new DateTime();
            //-1 reduce 1 second to the timer
            dt = dateTime.AddSeconds(-1);

            var dateDifference = dateTime.Subtract(dt);
            dateTime -= dateDifference;

            RunOnUiThread(() =>
            {
                timerCounterTextView.Text = dateTime.ToString("mm:ss");
            });

            //END OF QUIZ ON TIMEOUT
            if (timerCounter == 120)
            {
                countDown.Enabled = false;
                CompleteQuiz();
            }
        }

        void ConnectViews()
        {

            //Radio button
            optionARadio = (RadioButton)FindViewById(Resource.Id.optionARadio);
            optionBRadio = (RadioButton)FindViewById(Resource.Id.optionBRadio);
            optionCRadio = (RadioButton)FindViewById(Resource.Id.optionCRadio);
            optionDRadio = (RadioButton)FindViewById(Resource.Id.optionDRadio);
            optionARadio.Click += OptionARadio_Click;
            optionBRadio.Click += OptionBRadio_Click;
            optionCRadio.Click += OptionCRadio_Click;
            optionDRadio.Click += OptionDRadio_Click;

            //Text views
            optionATextView = (TextView)FindViewById(Resource.Id.optionATextView);
            optionBTextView = (TextView)FindViewById(Resource.Id.optionBTextView);
            optionCTextView = (TextView)FindViewById(Resource.Id.optionCTextView);
            optionDTextView = (TextView)FindViewById(Resource.Id.optionDTextView);
            questionTextView = (TextView)FindViewById(Resource.Id.questionTextView);
            quizPositionTextView = (TextView)FindViewById(Resource.Id.quizPositiontextView);
            timerCounterTextView = (TextView)FindViewById(Resource.Id.timeCounterTextView);

            //Button
            proceedQuizButton = (Button)FindViewById(Resource.Id.proceedQuizButton);
            proceedQuizButton.Click += ProceedQuizButton_Click;
        }

        //Proceed quiz button event handler
        private void ProceedQuizButton_Click(object sender, EventArgs e)
        {
            if(!optionARadio.Checked && !optionBRadio.Checked && !optionCRadio.Checked && !optionDRadio.Checked)
            {
                //REPLACEMENT FOR TOAST
                Snackbar.Make((View)sender, "Please choose your answer!!", Snackbar.LengthShort).Show();
            }
            else if (optionARadio.Checked)
            {
                if(optionATextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    IncorrectAnswer();
                }
            }
            else if (optionBRadio.Checked)
            {
                if (optionBTextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    IncorrectAnswer();
                }
            }
            else if (optionCRadio.Checked)
            {
                if (optionCTextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    IncorrectAnswer();
                }
            }
            else if (optionDRadio.Checked)
            {
                if (optionDTextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    IncorrectAnswer();
                }
            }
        }

        //RADIO BUTTON EVENT HANDLERS
        private void OptionDRadio_Click(object sender, EventArgs e)
        {
            ClearRadioButtons();
            optionDRadio.Checked = true;
        }

        private void OptionCRadio_Click(object sender, EventArgs e)
        {
            ClearRadioButtons();
            optionCRadio.Checked = true;
        }

        private void OptionBRadio_Click(object sender, EventArgs e)
        {
            ClearRadioButtons();
            optionBRadio.Checked = true;
        }

        private void OptionARadio_Click(object sender, EventArgs e)
        {
            ClearRadioButtons();
            optionARadio.Checked = true;
        }

        void ClearRadioButtons()
        {
            optionARadio.Checked = false;
            optionBRadio.Checked = false;
            optionCRadio.Checked = false;
            optionDRadio.Checked = false;
        }

        void BeginQuiz()
        {
            quizPosition = 1;
            quizQuestionList = quizHelper.GetQuizQuestion(quizTopic);
            questionTextView.Text = quizQuestionList[0].QuizQuestion;
            optionATextView.Text = quizQuestionList[0].OptionA;
            optionBTextView.Text = quizQuestionList[0].OptionB;
            optionCTextView.Text = quizQuestionList[0].OptionC;
            optionDTextView.Text = quizQuestionList[0].OptionD;

            quizPositionTextView.Text = "Question" + quizPosition.ToString() + "/" + quizQuestionList.Count();

            //This is the duration allocated to this quiz (2 is = to 2 minutes)          
            dateTime = new DateTime();
            dateTime = dateTime.AddMinutes(2);
            //mm:ss is the time format (minues and seconds)
            timerCounterTextView.Text = dateTime.ToString("mm:ss");
            countDown.Enabled = true;
        }

        void CorrectAnswer()
        {
            CorrectFragment correctFragment = new CorrectFragment();

            //Transaction Manager = it is responsible for allowing us to move swiftly from the activity to the dialogue fragment
            var trans = SupportFragmentManager.BeginTransaction();

            //Cancelable if set to true is when you touch any part of the screen, the dialogue fragment will exit.
            correctFragment.Cancelable = false;
            correctFragment.Show(trans, "Correct");
            correctFragment.NextQuestion += CorrectFragment_NextQuestion;
        }

        void IncorrectAnswer()
        {

            IncorrectFragment incorrectFragment = new IncorrectFragment(quizQuestionList[quizPosition - 1].Answer);

            var trans = SupportFragmentManager.BeginTransaction();
            incorrectFragment.Cancelable = false;
            incorrectFragment.Show(trans, "Incorrect");
            incorrectFragment.NextQuestion += CorrectFragment_NextQuestion;
            
        }

        private void CorrectFragment_NextQuestion(object sender, EventArgs e)
        {
            quizPosition++;

            if (quizPosition > quizQuestionList.Count)
            {
                CompleteQuiz();
                return;
            }

            int indx = quizPosition - 1;
            ClearRadioButtons();

            questionTextView.Text = quizQuestionList[indx].QuizQuestion;
            optionATextView.Text = quizQuestionList[indx].OptionA;
            optionBTextView.Text = quizQuestionList[indx].OptionB;
            optionCTextView.Text = quizQuestionList[indx].OptionC;
            optionDTextView.Text = quizQuestionList[indx].OptionD;

            quizPositionTextView.Text = "Question" + quizPosition.ToString() + "/" + quizQuestionList.Count.ToString();
        }

        void CompleteQuiz()
        {
            timerCounterTextView.Text = "00:00";
            countDown.Enabled = false;

            string score = correctAnswerCount.ToString() + '/' + quizQuestionList.Count.ToString();
            double percentage = (correctAnswerCount/double.Parse(quizQuestionList.Count.ToString())) *100;
            string remarks = "";
            string image = "";

            if (percentage > 50 && percentage < 70)
            {
                remarks = "Very Good result!!!";
            }
            else if (percentage >= 70)
            {
                remarks = "Very Outstanding result!!!";
            }
            else if(percentage == 50)
            {
                remarks = "You made it!!!";
            }
            else if(percentage < 50)
            {
                remarks = "You didn't make it.";
            }

            CompletedFragment completedFragment = new CompletedFragment(remarks, score, image);
            completedFragment.Cancelable = false;
            var trans = SupportFragmentManager.BeginTransaction();
            completedFragment.Show(trans, "Complete");

            completedFragment.GoHome += (sender, e) =>
            {
                this.Finish();
            };
        }


    }
}
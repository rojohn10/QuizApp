using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using QuizApp.Helpers;

namespace QuizApp.Activities
{
    [Activity(Label = "QuizDescriptionActivity", Theme = "@style/AppTheme")]
    public class QuizDescriptionActivity : AppCompatActivity
    {
        //Instantiate
        TextView quizTopicTextView;
        TextView quizDescriptionTextView;
        ImageView quizImageView;
        Button quizStartButton;

        //variables
        string quizTopic;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.selected_topic);

            //Reference
            quizTopicTextView = (TextView)FindViewById(Resource.Id.quizTopicTest);
            quizDescriptionTextView = (TextView)FindViewById(Resource.Id.quizDescriptionText);
            quizImageView = (ImageView)FindViewById(Resource.Id.quizImage);
            quizStartButton = (Button)FindViewById(Resource.Id.quizStartButton);


            //GET TOPIC NAME
            quizTopic = Intent.GetStringExtra("topic");
            quizTopicTextView.Text = quizTopic;

            //Retrieve topic description
            QuizHelper quizHelper = new QuizHelper();
            quizDescriptionTextView.Text = quizHelper.GetTopicDescription(quizTopic);
            quizStartButton.Click += QuizStartButton_Click;

            //GET IMAGE
            quizImageView.SetImageResource(GetImage(quizTopic));
        }

        private void QuizStartButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(QuizActivity));
            intent.PutExtra("topic", quizTopic);
            StartActivity(intent);
            Finish();
        }

        //GET THE IMAGE OF THE SELECTED TOPIC
        int GetImage(string topic)
        {
            int imageInt = 0;

            switch (topic)
            {
                case "History":
                    imageInt = Resource.Drawable.history;
                    break;

                case "Geography":
                    imageInt = Resource.Drawable.geography;
                    break;

                case "Space":
                    imageInt = Resource.Drawable.space;
                    break;

                case "Engineering":
                    imageInt = Resource.Drawable.engineering;
                    break;

                case "Programming":
                    imageInt = Resource.Drawable.programming;
                    break;

                case "Business":
                    imageInt = Resource.Drawable.business;
                    break;  

                default:
                    break;               
            }

            return imageInt;
        }
    }
}
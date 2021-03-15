﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace QuizApp.Fragments
{
    public class CorrectFragment : Android.Support.V4.App.DialogFragment
    {
        Button correctButton;

        public event EventHandler NextQuestion;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.correct, container, false);

            correctButton = (Button)view.FindViewById(Resource.Id.correctButton);
            correctButton.Click += CorrectButton_Click;
            return view;
        }

        private void CorrectButton_Click(object sender, EventArgs e)
        {
            //Exit the dialogue
            this.Dismiss();
            NextQuestion?.Invoke(this, new EventArgs());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Database.Sqlite;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinQuizApp.Acitivty;
using XamarinQuizApp.Common;
using XamarinQuizApp.DbHelper;

namespace XamarinQuizApp.Acitivty
{
    [Activity(MainLauncher = true)]
    public class MainActivity1 : Activity
    {

        private EditText txtUsername, txtPassword;
        private Button btnSignIn, btnCreate;
        Helper helper;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main1);

            txtUsername = FindViewById<EditText>(Resource.Id.txtusername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtpassword);
            btnCreate = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignIn = FindViewById<Button>(Resource.Id.btnSign);
            helper = new Helper(this);

      //      btnSignIn.Click += BtnSignIn_Click;
            btnCreate.Click += delegate { StartActivity(typeof(SignUp)); };

            btnSignIn.Click += delegate
            {
                try
                {
                    string Username = txtUsername.Text.ToString();
                    string Password = txtPassword.Text.ToString();
                    var user = helper.Authenticate(this, new Admin(null, Username, null, null, Password, null));
                    if (user != null)
                    {

                        Toast.MakeText(this, "Login Successful", ToastLength.Short).Show();
                        //  SetContentView(Resource.Layout.MainActvity);
                        Intent intent = new Intent(this, typeof(MainActivity));
                        StartActivity(intent);

                    }
                    else
                    {
                        Toast.MakeText(this, "Login Unsuccessful! Please verify your Username and Password", ToastLength.Short).Show();
                    }
                }
                catch (SQLiteException ex)
                {
                    Toast.MakeText(this, "" + ex, ToastLength.Short).Show();
                }

            };
        }
        //private void BtnSignIn_Click(object sender, EventArgs e)
        //{
        //    SetContentView(Resource.Layout.SignUp);
        //}
        }
}
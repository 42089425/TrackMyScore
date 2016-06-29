using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using Android.Database.Sqlite;

namespace TrackMyScore
{

    [Activity(Label = "TrackMyScore", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity

    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            //var fileName = "TrackMyScore.db";
            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //var path = Path.Combine(documentsPath, fileName);

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "TrackMyScore.db"));

            EditText MemberShipID = FindViewById<EditText>(Resource.Id.MembershipID);
            EditText Date = FindViewById<EditText>(Resource.Id.DateID);
            EditText Course = FindViewById<EditText>(Resource.Id.CourseID);
            EditText Par = FindViewById<EditText>(Resource.Id.ParID);
            Button button = FindViewById<Button>(Resource.Id.Submit);
           
            EditText Comments = FindViewById<EditText>(Resource.Id.ComID);

            EditText Hole1 = FindViewById<EditText>(Resource.Id.Hole1);
            EditText Hole2 = FindViewById<EditText>(Resource.Id.Hole2);
            EditText Hole3 = FindViewById<EditText>(Resource.Id.Hole3);
            EditText Hole4 = FindViewById<EditText>(Resource.Id.Hole4);
            EditText Hole5 = FindViewById<EditText>(Resource.Id.Hole5);
            EditText Hole6 = FindViewById<EditText>(Resource.Id.Hole6);
            EditText Hole7 = FindViewById<EditText>(Resource.Id.Hole7);
            EditText Hole8 = FindViewById<EditText>(Resource.Id.Hole8);
            EditText Hole9 = FindViewById<EditText>(Resource.Id.Hole9);
            EditText Hole10 = FindViewById<EditText>(Resource.Id.Hole10);
            EditText Hole11 = FindViewById<EditText>(Resource.Id.Hole11);
            EditText Hole12 = FindViewById<EditText>(Resource.Id.Hole12);
            EditText Hole13 = FindViewById<EditText>(Resource.Id.Hole13);
            EditText Hole14 = FindViewById<EditText>(Resource.Id.Hole14);
            EditText Hole15 = FindViewById<EditText>(Resource.Id.Hole15);
            EditText Hole16 = FindViewById<EditText>(Resource.Id.Hole16);
            EditText Hole17 = FindViewById<EditText>(Resource.Id.Hole17);
            EditText Hole18 = FindViewById<EditText>(Resource.Id.Hole18);
            EditText MembeNr = FindViewById<EditText>(Resource.Id.txtMemberNr);
            Button button1 = FindViewById <Button>(Resource.Id.View);
            
            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            createDatabase(conn);


            //var connection = new SQLiteAsyncConnection(path);

            button.Click += (object sender, EventArgs e) =>
            {
                AddScores(conn, MemberShipID.Text, Date.Text, Course.Text, Hole1.Text, Hole2.Text, Hole3.Text, Hole4.Text, Hole5.Text, Hole6.Text, Hole7.Text, Hole8.Text, Hole9.Text,
                    Hole10.Text, Hole11.Text, Hole12.Text, Hole13.Text, Hole14.Text, Hole15.Text, Hole16.Text, Hole17.Text, Hole18.Text, Comments.Text, Par.Text);
                Android.App.AlertDialog.Builder builer = new AlertDialog.Builder(this);
                builer.Create();
                builer.SetTitle("Scores");
                builer.SetMessage("Scores Succesfully Added");
                builer.SetIcon(1);
                // Setting OK Button
                builer.SetPositiveButton("OK", (EventHandler<DialogClickEventArgs>)null);
               
                builer.Show();
                Hole1.Text = "";
                Hole2.Text = "";
                Hole3.Text = "";
                Hole4.Text = "";
                Hole5.Text = "";
                Hole6.Text = "";
                Hole7.Text = "";
                Hole8.Text = "";
                Hole9.Text = "";
                Hole10.Text = "";
                Hole11.Text = "";
                Hole12.Text = "";
                Hole13.Text = "";
                Hole14.Text = "";
                Hole15.Text = "";
                Hole16.Text = "";
                Hole17.Text = "";
                Hole18.Text = "";
                Par.Text = "";
                Comments.Text = "";
                Date.Text = "";
                MemberShipID.Text = "";
                Course.Text = "";
            };

            button1.Click += (object sender, EventArgs e) =>
            {
                if (MembeNr.Text.Trim() == "")
                {
                    Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.Create();
                    builder.SetTitle("Membership NR");
                    builder.SetMessage("Please enter Member Nr");
                    builder.SetIcon(1);
                    builder.SetPositiveButton("OK", (EventHandler<DialogClickEventArgs>)null);
                    builder.Show();
                    return;
                }
                var query = (from p in conn.Table<Player>()
                                  where p.MembershipID == MembeNr.Text
                             select p); //conn.Table<Player>();
                                        //AddScores(conn, MemberShipID.Text, Date.Text, Course.Text, Hole1.Text, Hole2.Text, Hole3.Text, Hole4.Text, Hole5.Text, Hole6.Text, Hole7.Text, Hole8.Text, Hole9.Text,

                if (query.Count().ToString() == "0")
                {
                    Android.App.AlertDialog.Builder builder1 = new AlertDialog.Builder(this);
                    builder1.Create();
                    builder1.SetTitle("MembershipNR");
                    builder1.SetIcon(1);
                    builder1.SetMessage("No Scores available for Member. Please re-enter Member ID");
                    builder1.SetPositiveButton("OK", (EventHandler<DialogClickEventArgs>)null);
                    builder1.Show();
                    return;
                }

                foreach (var message in query)
                {

                    Android.App.AlertDialog.Builder builder2 = new AlertDialog.Builder(this);
                    builder2.Create();
                    builder2.SetTitle("Player Scores for: " + MembeNr.Text);
                    builder2.SetMessage(
                        "MemberShipID:" + " " + message.MembershipID + " " +
                           "\n" +
                         "\nDate:" + " " + message.Date +
                        "\nPar:" + " " + message.Par + " " +
                         "\nComments:" + " " + message.Comments +
                         "\n" + 
                        "\nHole 1: " + " " + message.Hole1 + " " + "\nHole 2: " + " " + message.Hole2 + " "
                                             + "\nHole 3: " + " " + message.Hole3 + " " + "\nHole 4: " + " " + message.Hole4 + " "
                                             + "\nHole 5: " + " " + message.Hole5 + " " + "\nHole 6: " + " " + message.Hole6 + " "
                                             + "\nHole 7: " + " " + message.Hole7 + " " + "\nHole 8: " + " " + message.Hole8 + " "
                                               + "\nHole 9: " + " " + message.Hole9 + " " + "\nHole 10: " + " " + message.Hole10 + " "
                                                 + "\nHole 11: " + " " + message.Hole11 + " " + "\nHole 12: " + " " + message.Hole12 + " "
                                                   + "\nHole 13: " + " " + message.Hole13 + " " + "\nHole 14: " + " " + message.Hole14 + " "
                                                     + "\nHole 15: " + " " + message.Hole15 + " " + "\nHole 16: " + " " + message.Hole16 + " "
                                                       + "\nHole 17: " + " " + message.Hole17 + " " + "\nHole 18: " + " " + message.Hole18 + " "
                                                         + "\n"
                                                          + "\n"
                                                       + "\nFinal Score:" + " " + (int.Parse(message.Hole1) + int.Parse(message.Hole2)+ int.Parse(message.Hole7) + int.Parse(message.Hole8)
                                                       + int.Parse(message.Hole3) + int.Parse(message.Hole4)+ int.Parse(message.Hole5) + int.Parse(message.Hole6)
                                                       + int.Parse(message.Hole9) + int.Parse(message.Hole10)+ int.Parse(message.Hole11) + int.Parse(message.Hole12)
                                                       + int.Parse(message.Hole13) + int.Parse(message.Hole14)+ int.Parse(message.Hole15) + int.Parse(message.Hole16)
                                                       + int.Parse(message.Hole17) + int.Parse(message.Hole18))
                                       );
                    builder2.SetPositiveButton("OK", (EventHandler<DialogClickEventArgs>)null);
                    builder2.Show();
                    MembeNr.Text = "";

                }

                   
                //   Hole10.Text, Hole11.Text, Hole12.Text, Hole13.Text, Hole14.Text, Hole15.Text, Hole16.Text, Hole17.Text, Hole18.Text, Comments.Text, Par.Text);


            };
        }

 
        private string createDatabase(SQLiteConnection path)
        {
            try
            {
                //var connection = new SQLiteAsyncConnection(path);
                string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "TrackMyScore.db"));
                //connection.CreateTableAsync<Player>();
                conn.CreateTable<Player>();
                return "Database created";
            }
            catch (Android.Database.Sqlite.SQLiteException ex)
            {
                return ex.Message;
            }
        }

        

        public static void AddScores(SQLiteConnection db, string MembershipID
         ,string Date 
         ,string Course 
         ,string Hole1 
         ,string Hole2
         ,string Hole3 
         ,string Hole4 
         ,string Hole5 
         ,string Hole6 
         ,string Hole7 
         ,string Hole8 
         ,string Hole9 
         ,string Hole10 
         ,string Hole11 
         ,string Hole12 
         ,string Hole13 
         ,string Hole14 
         ,string Hole15 
         ,string Hole16 
         ,string Hole17 
         ,string Hole18 
         ,string Comments 
         ,string Par )
        {
            try
            { 
            var s = new Player
            {
                //Symbol = symbol,
                MembershipID = MembershipID,
                //Date = DatePlayed.Text,
                Date = Date,
                Course = Course,
                Hole1 = Hole1,
                Hole2 = Hole2,
                Hole3 = Hole3,
                Hole4 = Hole4,
                Hole5 = Hole5,
                Hole6 = Hole6,
                Hole7 = Hole7,
                Hole8 = Hole8,
                Hole9 = Hole9,
                Hole10 = Hole10,
                Hole11 = Hole11,
                Hole12 = Hole12,
                Hole13 = Hole13,
                Hole14 = Hole14,
                Hole15 = Hole15,
                Hole16 = Hole16,
                Hole17 = Hole17,
                Hole18 = Hole18,
                Comments = Comments,
                Par = Par
            };
            db.Insert(s);
                //Console.WriteLine("{0} == {1}", s.MembershipID, s.Id);
            }
            catch(Exception ex)
            {

            }
            //Console.WriteLine("{0} == {1}", s.Symbol, s.Id);
        }
    }
}
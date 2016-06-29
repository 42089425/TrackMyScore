using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TrackMyScore
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string MembershipID { get; set; }
        public string Date { get; set; }
        public string Course { get; set; }
        public string Hole1 { get; set; }
        public string Hole2 { get; set; }
        public string Hole3 { get; set; }
        public string Hole4 { get; set; }
        public string Hole5 { get; set; }
        public string Hole6 { get; set; }
        public string Hole7 { get; set; }
        public string Hole8 { get; set; }
        public string Hole9 { get; set; }
        public string Hole10 { get; set; }
        public string Hole11 { get; set; }
        public string Hole12 { get; set; }
        public string Hole13 { get; set; }
        public string Hole14 { get; set; }
        public string Hole15 { get; set; }
        public string Hole16 { get; set; }
        public string Hole17 { get; set; }
        public string Hole18 { get; set; }
        public string Comments { get; set; }
        public string Par { get; set; }

        public override string ToString()
        {
            return string.Format("[Player: Id={0}, MembershipID={1}, Date={2}]", Id, MembershipID, Date);
        }
    }

    
}
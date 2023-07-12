using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Shapes;
using System.Runtime.InteropServices.WindowsRuntime;
using SQLite;
using eumatamboV2.Droid;
[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]
namespace eumatamboV2.Droid

{
    public class SqliteClient : Database {
        public SQLiteAsyncConnection GetConnection() 
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath,"uisrael.db3");
            return new SQLiteAsyncConnection(path);
            
        
        }
    }
}
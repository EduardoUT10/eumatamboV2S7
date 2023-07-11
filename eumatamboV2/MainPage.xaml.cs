using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eumatamboV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {   
        private SQLiteAsyncConnection _connection;
        public MainPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<Estudiante>("SELECT * FROM estudiante where Usuario = ? and Contrasenia = ?",usuario,contra);   

}
    }
}


using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eumatamboV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _connection;
        IEnumerable<Estudiante> ResultadosDelete;
        IEnumerable<Estudiante> ResultadosUpdate;
        public Elemento(int id)
        {
            _connection= DependencyService.Get<Database>().GetConnection(); 
            IdSeleccionado= id; 
            InitializeComponent();
        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadosUpdate = Update(db, Nombre.Text, Usuario.Text, Contrasenia.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "ok");
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta","ERROR" +ex.Message,"ok");
            }
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadosDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "ok");
            }
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db,int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
        } 

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario,string contrasenia, int id)
        {
            return db.Query<Estudiante>("ÚPDATE Estudiantes SET Nombre = ?,Usuario =?, " +
                "Contrasenia= ? where Id = ?",nombre,usuario,contrasenia,id);
        }
    }
}
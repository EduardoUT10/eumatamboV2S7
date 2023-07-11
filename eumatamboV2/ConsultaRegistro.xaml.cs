using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eumatamboV2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultarRegistro : ContentPage
	{
		private SQLiteAsyncConnection _connection;
		private ObservableCollection<Estudiante> _TablaEstudiante;
		public ConsultarRegistro()
		{
			InitializeComponent();
			_connection = DependencyService.Get<Database>().GetConnection();
			NavigationPage.SetHasBackButton(this, false);
		}

		protected async override void OnAppearing()
		{

			var ResulRegistros = await _connection.Table<Estudiante>().ToListAsync();	
			_TablaEstudiante= new ObservableCollection<Estudiante>();
			ListaUsuarios.ItemSource = _TablaEstudiante;
			base.OnAppearing();	

		}

		void OnSelection(object sender, SelectionChangedEventArgs e)
		{
			var Obj = (Estudiante)sender;
			var item =  Obj.Id.ToString();
			int ID = Convert.ToInt32(item);
			try
			{
				Navigation.PushAsync(new Elemento(ID));
			}
			catch (Exception ex)
			{
				throw;
			}
		}
}
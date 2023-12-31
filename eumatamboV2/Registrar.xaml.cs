﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eumatamboV2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registrar : ContentPage
	{	
		private SQLiteAsyncConnection _connection;
		public Registrar ()
		{
			InitializeComponent ();
			_connection = DependencyService.Get<Database>().GetConnection();
		}

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
			var DatosRegistro = new Estudiante { Nombre =  Nombre.Text, Usuario = Usuario.Text, Contrasenia = Contrasenia.Text };
			_connection.InsertAsync(DatosRegistro);
			limpiarFormulario();
        }


		void limpiarFormulario()
		{
			Nombre.Text = "";
			Usuario.Text = "";
			Contrasenia.Text = "";
			DisplayAlert("Alerta", "Se agrego correctamente", "OK");
		}

    }
}
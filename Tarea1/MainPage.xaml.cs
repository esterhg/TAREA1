using System;
using System.IO;
using SQLite;
using Tarea1.Models;
using Microsoft.Maui.Controls;

namespace Tarea1
{
    public partial class MainPage : ContentPage
    {
        SQLiteAsyncConnection database;

        public MainPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "personas.db3");
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Persona>().Wait();
        }

        private async void Button_guardar(object sender, EventArgs e)
        {
            // Crear una nueva persona
            var nuevaPersona = new Persona
            {
                Nombre = nombre.Text,
                Apellido = apellido.Text,
                Edad = int.Parse(edad.Text),
                Correo = correo.Text,
                Descripcion = descripcion.Text
            };

            // Guardar la persona en la base de datos
            await database.InsertAsync(nuevaPersona);

            // Limpiar los campos después de guardar
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            correo.Text = "";
            descripcion.Text = "";

            await DisplayAlert("Éxito", "Persona guardada correctamente", "Aceptar");
        }
       

            private void Button_lista(object sender, EventArgs e)
        {
            // Navegar a la página de lista de personas
            Navigation.PushAsync(new ListaPage());
        }
    }
}

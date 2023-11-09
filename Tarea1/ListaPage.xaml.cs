using Tarea1.Data;

namespace Tarea1
{
    public partial class ListaPage : ContentPage
    {
        Database database;

        public ListaPage()
        {
            InitializeComponent();
            database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "personas.db3"));
            plist = new ListView();
            CargarPersonas(); // Cargar la lista de personas al iniciar la página
        }

        private async void CargarPersonas()
        {
            plist.ItemsSource = await database.GetPersonasAsync();
        }

        private async void Actualizar_Clicked(object sender, EventArgs e)
        {
            // Implementa la lógica para editar una persona aquí
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int personaID)
            {

                await database.DeletePersonaAsync(personaID);
                await DisplayAlert("Éxito", "Persona eliminada correctamente", "Aceptar");
                plist.ItemsSource = await database.GetPersonasAsync();
            }
        }


        private async void Crear_Clicked(object sender, EventArgs e)
        {
            // Implementa la lógica para crear una nueva persona aquí
        }
    }
}

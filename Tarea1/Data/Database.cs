using SQLite;
using Tarea1.Models;

namespace Tarea1.Data
{
    public class Database
    {
        SQLiteAsyncConnection db;

        public Database(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Persona>().Wait();
        }

        public Task<int> Agregar(Persona persona)
        {
            if (persona.ID == 0)
            {
                return db.InsertAsync(persona);
            }
            else
            {
                return db.UpdateAsync(persona);
            }
        }

        public Task<List<Persona>> GetPersonasAsync()
        {
            return db.Table<Persona>().ToListAsync();
        }

        public Task<Persona> GetPersonaByIdAsync(int ID)
        {
            return db.Table<Persona>().Where(a => a.ID == ID).FirstOrDefaultAsync();
        }

        public Task<int> DeletePersonaAsync(int personaID)
        {
            return db.DeleteAsync<Persona>(personaID);
        }
    }
}

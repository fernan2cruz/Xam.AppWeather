namespace Xam.App.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;    
    using SQLite;
    using Xam.App.Data.Entities;    

    public class DataContext
    {
        readonly SQLiteAsyncConnection database;

        public int LastInsertedId { get; set; }

        public DataContext(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<WeatherHistoric>().Wait();
        }

        internal void Delete(object item)
        {
            database.DeleteAsync(item).Wait();
        }

        public async Task<IList<WeatherHistoric>> GetTodoItems()
        {
            var results = await database.QueryAsync<WeatherHistoric>("Select * from WeatherHistoric");

            return results;
        }

        public void Insert(WeatherHistoric item)
        {
            database.InsertAsync(item).Wait();
        }

        internal void Update(WeatherHistoric item)
        {
            database.UpdateAsync(item).Wait();
        }
    }
}

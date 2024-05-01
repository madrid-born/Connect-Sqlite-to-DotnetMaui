using SQLite;

namespace DatabaseTest ;

    public class DBContext
    {
        private const string dbName = "demo_local_db3.db3";
        private readonly SQLiteAsyncConnection _connection;
        

        public DBContext()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, dbName));
            _connection.CreateTableAsync<User>();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _connection.Table<User>().ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _connection.Table<User>().Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task Create(User user)
        {
            await _connection.InsertAsync(user);
        }
        
        public async Task Update(User user)
        {
            await _connection.UpdateAsync(user);
        }

        public async Task Delete(User user)
        {
            await _connection.DeleteAsync(user);
        }
    }
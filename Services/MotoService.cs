using MotoAPP.Models;
using SQLite;

namespace MotoAPP.Services
{
    public class MotoService
    {
        private SQLiteConnection _connection;
        public MotoService()
        {
            // Instanciar a classe de conexão
            DataBaseService dataBaseService = new DataBaseService();

            // Gerar a conexão com o DB
            _connection = dataBaseService.GetConexao();

            _connection.CreateTable<Moto>();
        }
    }
}

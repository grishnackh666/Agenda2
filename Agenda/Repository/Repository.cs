using Agenda.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Agenda.repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _db;
        public Repository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("conexionSql"));
        }

        public People AddPeople(People people)
        {
            var sql = "INSERT INTO people(Name,Firstname,Cell,Email,Country,CreationDate)VALUES(@Name,@Firstname,@Cell,@Email,@Country,@CreationDate)"
            +" SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = _db.Query<int>(sql, people).Single();
            people.idCusmtomer = id;
            return people;
        }

        public void DeletePeople(int id)
        {
            var sql = "DELETE FROM people WHERE idCusmtomer = @idCusmtomer";
            _db.Execute(sql, new { @idCusmtomer = id});
        }

        public List<People> GetPeople()
        {
            var sql = "SELECT * FROM people ";
            return _db.Query<People>(sql).ToList();
        }

        public People GetPeople(int id)
        {
            var sql = "SELECT * FROM people WHERE idCusmtomer=@idCusmtomer";
            return _db.Query<People>(sql,new {@idCusmtomer=id}).Single();
        }

        public People UpdatePeople(People people)
        {
            var sql = "UPDATE people SET Name=@Name,Firstname=@Firstname,Cell=@Cell,Email=@Email,Country=@Country,CreationDate=@CreationDate WHERE idCusmtomer=@idCusmtomer";
            _db.Execute(sql, people);
            return people;
        }
    }
}

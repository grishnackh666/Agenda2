using Agenda.Models;

namespace Agenda.repository
{
    public interface IRepository
    {
        People GetPeople(int id);
        List<People> GetPeople();
        People AddPeople(People people);
        People UpdatePeople(People people);
        void DeletePeople(int id);
    }
}

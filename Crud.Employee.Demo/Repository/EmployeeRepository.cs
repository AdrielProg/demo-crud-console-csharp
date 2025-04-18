using Crud.Employee.Demo.Context;

namespace Crud.Employee.Demo.Repository
{
    public class EmployeeRepository
    {
        private readonly ConsoleContext _context = new ConsoleContext();
        private int _idCounter = 1;

        public int Create(List<Dictionary<string, string?>> attributes)
        {
            _context.Employees[_idCounter] = attributes;
            return _idCounter++;
        }

        public Dictionary<int, List<Dictionary<string, string?>>> GetAll()
        {
            return _context.Employees;
        }

        public bool Delete(int id)
        {
            // Simplificado
            return _context.Employees.Remove(id);
        }

        public bool Update(int id, List<Dictionary<string, string?>> attributes)
        {
            // Simplificado
            if (!_context.Employees.ContainsKey(id))
                return false;
            _context.Employees[id] = attributes;
            return true;
        }
    }
}

using Crud.Employee.Demo.Repository;

namespace Crud.Employee.Demo.UI;

public class ConsoleRequestController(EmployeeRepository repository)
{
    private readonly EmployeeRepository _repository = repository;

    public int CreateEmployee(List<Dictionary<string, string>> attributes)
    {
        return _repository.Create(attributes);
    }

    public Dictionary<int, List<Dictionary<string, string>>> GetAllEmployees()
    {
        return _repository.GetAll();
    }

    public bool UpdateEmployee(int id, List<Dictionary<string, string>> attributes)
    {
        return _repository.Update(id, attributes);
    }

    public bool DeleteEmployee(int id)
    {
        return _repository.Delete(id);
    }
}

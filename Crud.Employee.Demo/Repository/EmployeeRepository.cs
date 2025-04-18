using Crud.Employee.Demo.Context;

namespace Crud.Employee.Demo.Repository;
public class EmployeeRepository(ConsoleContext context)
{
    private readonly ConsoleContext _context = context;
    private int _idCounter = 1;
    private int _taskIdCounter = 1;

    public Dictionary<int, List<Dictionary<string, string>>> GetAllTasks() => _context.Tasks;
    public Dictionary<int, List<Dictionary<string, string>>> GetAll() => _context.Employees;
    public bool Delete(int id) => _context.Employees.Remove(id);

    public int Create(List<Dictionary<string, string>> attributes)
    {
        _context.Employees[_idCounter] = attributes;
        return _idCounter++;
    }

    public bool Update(int id, List<Dictionary<string, string>> attributes)
    {
        if (!_context.Employees.ContainsKey(id))
            return false;
       
        _context.Employees[id] = attributes;
        return true;
    }

    public int AddTaskToEmployee(int employeeId, List<Dictionary<string, string>> taskAttributes)
    {
        foreach (var attr in taskAttributes)
            attr["EmployeeId"] = employeeId.ToString();
        
        _context.Tasks[_taskIdCounter] = taskAttributes;
        return _taskIdCounter++;
    }

    public List<Dictionary<string, string>> GetTasksByEmployeeId(int employeeId)
    {
        var result = new List<Dictionary<string, string>>();
       
        foreach (var task in _context.Tasks.Values)
            foreach (var attr in task)
                if (attr.TryGetValue("EmployeeId", out var empId) && empId == employeeId.ToString())
                    result.Add(attr);

        return result;
    }
}

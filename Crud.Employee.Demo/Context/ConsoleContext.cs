namespace Crud.Employee.Demo.Context;

public class ConsoleContext 
{
    // Banco de dados em memória para funcionários e tarefas.
    public Dictionary<int, List<Dictionary<string, string?>>> Employees = new();
    public Dictionary<int, List<Dictionary<string, string?>>> Tasks = new();

    public ConsoleContext GetContext()
    {
        return this;
    }
}

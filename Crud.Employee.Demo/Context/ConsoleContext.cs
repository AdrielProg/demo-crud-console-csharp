namespace Crud.Employee.Demo.Context;

public class ConsoleContext 
{
    // Banco de dados entre muitas aspas em memória para funcionários e tarefas.
    public Dictionary<int, List<Dictionary<string, string>>> Employees = [];
    public Dictionary<int, List<Dictionary<string, string>>> Tasks = [];

    public ConsoleContext GetContext()
    {
        return this;
    }
}

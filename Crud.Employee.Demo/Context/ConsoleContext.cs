namespace Crud.Employee.Demo.Context
{
    public class ConsoleContext 
    {
        // Banco de dados em memória para funcionários e tarefas.
        public static Dictionary<int, List<Dictionary<string, string?>>> Employees = new Dictionary<int, List<Dictionary<string, string?>>>();
        public static Dictionary<int, List<Dictionary<string, string?>>> Tasks = new Dictionary<int, List<Dictionary<string, string?>>>();

        public ConsoleContext GetContext()
        {
            return this;
        }
    }
}
namespace Crud.Employee.Demo.Context;

    public class ConsoleContext 
    {
        // Banco de dados entre `infinitas aspas` em memória para funcionários e tarefas.
        public static Dictionary<int, List<Dictionary<string, string?>>> Employees = new();
        public static Dictionary<int, List<Dictionary<string, string?>>> Tasks = new();

        public ConsoleContext GetContext()
        {
            return this;
        }
    }

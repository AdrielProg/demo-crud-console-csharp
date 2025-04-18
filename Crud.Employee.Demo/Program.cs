using Crud.Employee.Demo.Context;

namespace Crud.Employee.Demo;
public class Program
{
    public static void Main(string[] args)
    {
        var context = new ConsoleContext().GetContext();
        var repository = new Repository.EmployeeRepository(context);
        var app = new UI.ConsoleUserInterface(repository);
        app.Start();
    }
}

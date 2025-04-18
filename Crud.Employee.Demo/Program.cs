using Crud.Employee.Demo.Context;

namespace Crud.Employee.Demo;
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new ConsoleContext().GetContext();
            
            if (context == null)
            {
                Console.WriteLine("Deu Errado");
                return;
            }
        }
    }



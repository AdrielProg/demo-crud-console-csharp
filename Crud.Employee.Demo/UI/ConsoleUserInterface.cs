using Crud.Employee.Demo.Repository;

namespace Crud.Employee.Demo.UI;
public class ConsoleUserInterface(EmployeeRepository repository)
{
    private readonly ConsoleRequestController _controller = new(repository);

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            ConsoleStyles.WriteHeader("MENU GERENCIAMENTO DE FUNCIONÁRIOS");
            ConsoleStyles.WriteMenuOption("1. Criar Funcionário");
            ConsoleStyles.WriteMenuOption("2. Listar Funcionários");
            ConsoleStyles.WriteMenuOption("3. Atualizar Funcionário");
            ConsoleStyles.WriteMenuOption("4. Excluir Funcionário");
            ConsoleStyles.WriteMenuOption("5. Sair");
            ConsoleStyles.WritePrompt("\nEscolha uma opção: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateEmployee();
                    break;
                case "2":
                    ListEmployees();
                    break;
                case "3":
                    UpdateEmployee();
                    break;
                case "4":
                    DeleteEmployee();
                    break;
                case "5":
                    ConsoleStyles.WriteInfo("Saindo do programa. Até mais!");
                    Thread.Sleep(1000);
                    return;
                default:
                    ConsoleStyles.WriteError("Opção inválida. Tente novamente.\n");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    private void CreateEmployee()
    {
        Console.Clear();
        ConsoleStyles.WriteHeader("Criando um novo funcionário");
        var attributes = CollectEmployeeAttributes();
        int id = _controller.CreateEmployee(attributes);
        ConsoleStyles.WriteSuccess($"Funcionário criado com sucesso com o ID {id}.\n");
        ConsoleStyles.WritePrompt("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    private void ListEmployees()
    {
        Console.Clear();
        ConsoleStyles.WriteHeader("Funcionários cadastrados");
        var employees = _controller.GetAllEmployees();
        
        if (employees.Count == 0)
            ConsoleStyles.WriteInfo("Nenhum funcionário cadastrado.\n");
        
        else
        {
            foreach (var emp in employees)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"ID do Funcionário: {emp.Key}");
                Console.ResetColor();

                foreach (var attributes in emp.Value)
                    foreach (var attribute in attributes)
                        Console.WriteLine($"  {attribute.Key}: {attribute.Value ?? "null"}");
                    
                Console.WriteLine(new string('-', 40));
            }
        }
        ConsoleStyles.WritePrompt("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    private void UpdateEmployee()
    {
        Console.Clear();
        ConsoleStyles.WriteHeader("Atualizar Funcionário");
        ConsoleStyles.WritePrompt("Digite o ID do funcionário que deseja atualizar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var attributes = CollectEmployeeAttributes();
            if (_controller.UpdateEmployee(id, attributes))
                ConsoleStyles.WriteSuccess("Funcionário atualizado com sucesso.\n");
            else
                ConsoleStyles.WriteError("ID inválido ou funcionário não encontrado.\n");
        }
        else
            ConsoleStyles.WriteError("ID inválido.\n");
        
        ConsoleStyles.WritePrompt("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    private void DeleteEmployee()
    {
        Console.Clear();
        ConsoleStyles.WriteHeader("Excluir Funcionário");
        ConsoleStyles.WritePrompt("Digite o ID do funcionário que deseja excluir: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (_controller.DeleteEmployee(id))
                ConsoleStyles.WriteSuccess($"Funcionário com ID {id} removido com sucesso.\n");
            else
                ConsoleStyles.WriteError("ID inválido ou funcionário não encontrado.\n");
        }
        else
            ConsoleStyles.WriteError("ID inválido.\n");
        
        ConsoleStyles.WritePrompt("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    private List<Dictionary<string, string>> CollectEmployeeAttributes()
    {
        var attributesList = new List<Dictionary<string, string>>();
        var attributes = new Dictionary<string, string>();

        ConsoleStyles.WritePrompt("Digite o Nome: ");
        attributes["Nome"] = Console.ReadLine();

        ConsoleStyles.WritePrompt("Digite a Data de Nascimento (dd/MM/yyyy): ");
        attributes["Data de Nascimento"] = Console.ReadLine();

        ConsoleStyles.WritePrompt("Digite o Endereço: ");
        attributes["Endereço"] = Console.ReadLine();

        ConsoleStyles.WritePrompt("Digite o CPF: ");
        attributes["CPF"] = Console.ReadLine();

        attributesList.Add(attributes);
        return attributesList;
    }
}


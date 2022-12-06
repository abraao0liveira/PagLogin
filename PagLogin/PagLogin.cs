using PagLogin.user;

namespace PagLogin;

public class PagLogin
{
    public static void Main()
    {
        var users = new List<User>();
        Menu(users);
    }

    public static void Menu(List<User> users)
    {
        Console.Clear();
        
        Console.WriteLine("***** Login Page *****");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Register");
        Console.WriteLine("0 - Exit");

        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1: Login(users);
                break;
            
            case 2:
            {
                var user = new User("", "");
                user = Register(user);
                
                var userExist = users.FirstOrDefault(u => u.Name == user.Name); // Verificando até chegar ao escolhido
                if (userExist != null)
                {
                    Console.WriteLine("\nEsse nome de usuario já está sendo utilizado.");
                    Thread.Sleep(2000);
                    Menu(users);
                }
                
                users.Add(user);
                Console.WriteLine("Usuario cadastrado!");
                Thread.Sleep(2000);
                Menu(users);
                break;
            }
            
            case 0: System.Environment.Exit(0);
                break;
            
            default: Menu(users);
                break;
        }
    }
    public static void Login(List<User> users)
    {
        Console.Clear();
        
        if (users.Count == 0) // Para nenhum usuario registrado
        {
            Console.WriteLine("O sistema deve conter ao menos 1 usuario!");
            Thread.Sleep(2000);
            Menu(users);
        }

        Console.WriteLine("***** Login *****");
        Console.WriteLine("Name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Password: ");
        var password = Console.ReadLine();

        var user = users.Find(u => u.Name == name && u.Password == password); // Retomando os dados de users para user

        if (user != null)
        {
            Console.WriteLine($"Bem vindo {user.Name}!");
            Thread.Sleep(2000);
            Menu(users);
        }

        Console.WriteLine("\nUm ou mais campos estão incorretos!");
        Thread.Sleep(2000);
        Login(users);
    }
    public static User Register(User user)
    {
        Console.Clear();

        Console.WriteLine("***** Register *****");
        Console.WriteLine("Name: ");
        user.Name = Console.ReadLine(); // Salvando em User
        Console.WriteLine("Password: ");
        user.Password = Console.ReadLine(); // Salvando em User
        
        if (user.Name == string.Empty || user.Password == string.Empty)
        {
            Console.WriteLine("\nUm ou mais campos estão incorretos!");
            Thread.Sleep(2000);
            Register(user);
        }
        return user;
    }
}
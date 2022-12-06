namespace PagLogin.user;

public class User
{
    // CONSULTOR PARA PUXAR OS DADOS
    public User(string name, string password)
    {
        Name = name;
        Password = password;

        List<User> users = new List<User>(); // PARA VARIOS USUARIOS
    }
    // PROPRIEDADES
    public string Name { get; set; }
    public string Password { get; set; }
}
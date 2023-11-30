// See https://aka.ms/new-console-template for more information

var result = EnterUser();
Console.WriteLine($"Фамилия: {result.LastName} \nИмя: {result.Name}") ;

static (string Name, string LastName) EnterUser()
{
    (string Name, string LastName) User;

    User.Name = EnterConsoleString("Введите имя: ");

    User.LastName = EnterConsoleString("Введите Фамилию: ");

    return User;
}

// Ввод данных с консоли
static string EnterConsoleString(string text)
{
    string? result = null;
    while (string.IsNullOrWhiteSpace(result))
    {
        Console.WriteLine(text);
        result = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(result))
        {
            var consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы не ввели данные");
            Console.ForegroundColor = consoleColor;
        }
        else
            break;
    }
   return result;
}


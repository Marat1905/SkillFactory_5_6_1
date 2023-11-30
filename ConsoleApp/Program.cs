// See https://aka.ms/new-console-template for more information

var result = EnterUser();

Console.WriteLine($"Фамилия: {result.LastName} \nИмя: {result.Name} \nВозраст: {result.Age}") ;


static (string Name, string LastName, int Age) EnterUser()
{
    (string Name, string LastName, int Age) User;

    User.Name = EnterConsoleString("Введите имя: ");

    User.LastName = EnterConsoleString("Введите Фамилию: ");

    User.Age = EnterConsoleInt("Введите возраст цифрами: ");
    return User;
}

// Ввод данных с консоли
static string EnterConsoleString(string text, string warningText= "Вы не ввели данные")
{
    string? result = null;
    while (string.IsNullOrWhiteSpace(result))
    {
        Console.Write(text);
        result = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(result))
            WriteWarning(warningText);
        else
            break;
    }
   return result;
}

// Ввод данных с для преобразования в int
static int EnterConsoleInt(string text, string warningText = "Неверный формат данных")
{
    int result = 0;
    while(true)
    {
        var resultText = EnterConsoleString(text, warningText);
        if (!int.TryParse(resultText, out result))
             WriteWarning(warningText);
        else
            break;
    }
    return result;
}

// Выводим в консоль сообщение об ошибке
static void WriteWarning(string warningText)
{
    var consoleColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(warningText);
    Console.ForegroundColor = consoleColor;
}
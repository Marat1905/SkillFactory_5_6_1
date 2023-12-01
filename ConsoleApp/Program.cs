// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;

var result = EnterUser();

Console.WriteLine($"Фамилия: {result.LastName} \nИмя: {result.Name} \nВозраст: {result.Age}") ;

if (result.Pet != null)
    Console.WriteLine($"\n Ваши питомцы:\n\t { string.Join("\n\t", result.Pet)}");


static (string Name, string LastName, int Age, string[]? Pet) EnterUser()
{
    (string Name, string LastName, int Age, string[]? Pet) User;

    User.Name = EnterConsoleString("Введите имя: ");

    User.LastName = EnterConsoleString("Введите Фамилию: ");

    User.Age = EnterConsoleInt("Введите возраст цифрами: ");
   
    User.Pet=null;
    if (EnterConsoleString("Есть ли у Вас питомцы (ДА/НЕТ): ").ToLower() == "Да".ToLower())
    {
        var result = EnterConsoleInt("Укажите кол-во питомцев: ");
        User.Pet = EnterPet(result);
    }

    return User;
}

// Заполнение массива питомцев
static string[] EnterPet(int count)
{
    var Pet = new string[count];

    for (int i = 0; i < Pet.Length; i++)
    {
        Pet[i] = EnterConsoleString("Введите кличку: ");
    }
    return Pet;
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

// Ввод данных с консоли для преобразования в int
static int EnterConsoleInt(string text, string warningText = "Неверный формат данных")
{
    int result = 0;
    while(true)
    {
        var resultText = EnterConsoleString(text, warningText);
        if (!int.TryParse(resultText, out result))
             WriteWarning(warningText);
        else
        {
            if (result <= 0)
                WriteWarning("Значение не может быть ниже или равным нулю");
            else
                break;
        }       
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
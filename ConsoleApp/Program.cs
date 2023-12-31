﻿
var result = EnterUser();

Console.WriteLine($"Фамилия: {result.LastName} \nИмя: {result.Name} \nВозраст: {result.Age}");

if (result.Pet != null)
    Console.WriteLine($"\nВаши питомцы:\n\t {string.Join("\n\t ", result.Pet)}");

WriteColorConsole(result.Colors);




static (string Name, string LastName, int Age, string[]? Pet, string[] Colors) EnterUser()
{
    (string Name, string LastName, int Age, string[]? Pet, string[] Colors) User;

    User.Name = EnterConsoleString("Введите имя: ");

    User.LastName = EnterConsoleString("Введите Фамилию: ");

    User.Age = EnterConsoleInt("Введите возраст цифрами: ");
   
    User.Pet=null;
    if (EnterConsoleString("Есть ли у Вас питомцы (ДА/НЕТ): ").ToLower() == "Да".ToLower())
    {
        var result = EnterConsoleInt("Укажите кол-во питомцев: ");
        User.Pet = EnterPet(result);
    }

    User.Colors = EnterConsoleColor(EnterConsoleInt("Укажите кол-во любимых цветов: "));

    return User;
}

// Заполнение массива любимых цветов
static string[] EnterConsoleColor(int count)
{
    var color = new string[count];
    for (int i = 0; i < color.Length; i++)
    {
        while (true)
        {
            if(Enum.TryParse(EnterConsoleString($"Введите любимый цвет {i+1}: "), true, out ConsoleColor c))
            {
                color[i]=c.ToString();
                break;
            }
            else
                WriteWarning("Неверное название цвета");
        }
    }     
    return color;
} 

// Заполнение массива питомцев
static string[] EnterPet(int count)
{
    var Pet = new string[count];

    for (int i = 0; i < Pet.Length; i++)
    {
        Pet[i] = EnterConsoleString($"Введите кличку питомца {i+1}: ") ;
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

// Выводим в консоль сообщение об ошибке
static void WriteColorConsole(string[] Colors)
{
    if (Colors.Length != 0)
    {
        Console.WriteLine("Ваши любимые цвета: ");
        var consoleColor = Console.ForegroundColor;
        foreach (var color in Colors)
        {
            Enum.TryParse(color, true, out ConsoleColor c);
            Console.ForegroundColor = c;
            Console.WriteLine($"\t {c.ToString()}");
            Console.ForegroundColor = consoleColor;
        }
    }
    else
        Console.WriteLine("У Вас нет любимых цветов");
}
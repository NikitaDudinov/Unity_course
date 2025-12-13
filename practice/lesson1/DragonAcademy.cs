using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- СИСТЕМА УПРАВЛЕНИЯ ЯСЛЯМИ ЗАПУЩЕНА ---");

        // Дракон 1: Огненный
        string name1 = "Игнис";
        string type1 = "Огненный";
        int hunger1 = 50; // 0 - сыт, 100 - очень голоден
        bool isSleeping1 = false;

        // Дракон 2: Лесной
        string name2 = "Терра";
        string type2 = "Лесной";
        int hunger2 = 50; 
        bool isSleeping2 = false;

        while (true)
        {
            Console.WriteLine($"\nСОСТОЯНИЕ ДРАКОНОВ:");
            Console.WriteLine($"{name1} ({type1}): Голод {hunger1} | Спит: {isSleeping1}");
            Console.WriteLine($"{name2} ({type2}): Голод {hunger2} | Спит: {isSleeping2}");

            Console.WriteLine("\nДЕЙСТВИЯ: 1-Кормить Игниса, 2-Уложить Игниса, 3-Кормить Терру, 4-Выход");
            string choice = Console.ReadLine();

            if (choice == 1)
            {
                Console.WriteLine("Вы даете раскаленный уголь Игнису...");
                hunger2 = hunger2 - 20; 
                Console.WriteLine("Хрум-хрум, вкусно!") 
            }
            else if (choice = "2")
            {
                Console.WriteLine("Вы поете колыбельную...");
                Console.WriteLine("Но дракон смотрит на вас и не спит.");
            }
            else if (choice == "3")
            {
                Console.WriteLine("Вы даете волшебную траву Терре...");
                hunger2 = hunger2 - 20;
            }
            else if (choice == "4")
            {
                Console.WriteLine("Смена окончена.");
                break;
            }
        }
    }
}
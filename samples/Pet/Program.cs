//Ты — смотритель космической станции, обнаруживший неизвестную форму жизни.
//Твоя задача — создать программную модель этого организма, обладающего уникальным Именем
//и жизненно важными показателями: Здоровьем, Голодом и запасом Энергии. 
//Тебе предстоит реализовать систему команд, позволяющую кормить питомца для утоления голода, играть с ним, расходуя его силы,
//и укладывать спать для полного восстановления. Программа должна работать в непрерывном цикле, обновляя и показывая состояние
//существа после каждого действия, ведь если его здоровье опустится до нуля, миссия будет считаться проваленной.

Pet pet = new Pet("животное", 100, 30, 70);
Console.WriteLine("Начальное состояние: ");
pet.DisplayState();

while (true)
{
    string command = Console.ReadLine();
    if(command == "feed")
    {
        pet.ToFeed();
    }
    else if(command == "play")
    {
        pet.ToPlay();
    }
    else if (command == "sleep")
    {
        pet.ToSleep();
    }
    else if(command == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Unknow command");
    }
    pet.DisplayState();
}
Console.WriteLine("Вышли из программы");

class Pet
{
    private string _name;
    private int _health;
    private int _hunger;
    private int _energy;

    public Pet(string name,  int health, int hunger, int energy)
    {
        _name = name;
        _health = health;
        _hunger = hunger;
        _energy = energy;
    }

    public void ToSleep()
    {
        Console.WriteLine(_name + " лег спать");
        _health = 100;
        _hunger = 0;
        _energy = 100;
    }

    public void ToPlay()
    {
        Console.WriteLine(_name + " играет");
        if (_energy > 0)
        {
            _energy -= 10;
        }
    }

    public void ToFeed()
    {
        Console.WriteLine(_name + " кушает");
        if (_hunger > 0) 
        {
            _hunger -= 10;
        }
    }

    public void DisplayState()
    {
        Console.WriteLine("Имя: " + _name);
        Console.WriteLine("Здоровье: " + _health);
        Console.WriteLine("Голод: " + _hunger);
        Console.WriteLine("Энергия: " + _energy);
    }

    public string GetName()
    {
        return _name;
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetHunger() 
    {
        return _hunger;
    }

    public int GetEnergy() 
    {
        return _energy;
    }
}


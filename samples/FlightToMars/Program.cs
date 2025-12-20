//Мы находимся в Центре Управления Полетами.
//Наша задача — запустить две ракеты.
//Одна летит на Луну, другая — на Марс.
//Раньше инженеры писали код отдельно для каждой ракеты, дублируя работу,
//и это было долго и неудобно.

//Твоя задача — создать единый чертеж Ракеты, то есть Класс.
//Запомни, что любая ракета должна иметь имя, запас топлива и текущую высоту полета.
//Далее сделай так, чтобы ракеты умели летать, написав специальный метод Fly.
//Когда этот метод вызывается, ракета должна тратить топливо и подниматься выше.
//В финале, в главном центре управления, создай две разные ракеты по этому чертежу и
//запусти их одновременно в цикле, пока у них не кончится топливо.


Rocket rocket = new Rocket("Союз", 100, 0);
Rocket rocket1 = new Rocket("Спутник", 80, 0);

while (rocket.GetFuel() > 0 || rocket1.GetFuel() > 0)
{
    rocket.Fly();
    rocket1.Fly();
}

Console.WriteLine("Высота ракеты " + rocket.GetName() + " " + rocket.GetHeight());
Console.WriteLine("Высота ракеты " + rocket1.GetName() + " " + rocket1.GetHeight());

class Rocket
{
    private string _name;
    private int _fuel;
    private int _height;

    public Rocket(string name, int fuel, int height)
    {
        _name = name;
        _fuel = fuel;
        _height = height;
    }

    public void Fly()
    {
        if(_fuel > 0)
        {
            _fuel -= 10;
            _height += 50;
        }
    }

    public int GetFuel()
    {
        return _fuel;
    }

    public int GetHeight()
    {
        return _height;
    }

    public string GetName()
    {
        return _name;
    }
}
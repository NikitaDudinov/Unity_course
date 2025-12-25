//Наш персонаж владеет оружием, которое со временем становится слишком слабым для битв,
//поэтому он обращается за помощью к опытному кузнецу.
//Тебе предстоит реализовать логику, при которой кузнец изучает переданный ему предмет и проверяет его текущие показатели урона.
//Если у кузнеца достаточно ресурсов для работы, он увеличивает силу этого оружия, тем самым изменяя состояние объекта.
//Очень важно, чтобы метод кузнеца не просто менял цифры в памяти, а возвращал полноценный текстовый отчет о проделанной работе.
//Таким образом, игрок должен получить сообщение о том, стал ли меч острее или для проведения улучшения мастеру не хватило материалов.
//Это упражнение научит тебя тому, как один класс может управлять данными другого и сообщать программе о результате своего
//взаимодействия через возвращаемые значения.

Weapon weapon = new Weapon(4, 20);
Hero hero = new Hero("hero", weapon, 30);
Blacksmith blacksmith = new Blacksmith();
hero.Attack();
hero.Attack();
hero.Attack();
hero.Attack();
hero.Attack();
hero.Attack();
hero.Attack();
blacksmith.Check(hero.GetWeapon(), hero.GetResources());
hero.Attack();

class Weapon
{
    private int _durability;
    private int _damage;

    public Weapon(int durability, int damage)
    {
        _durability = durability;
        _damage = damage;
    }

    public int GetDursbility()
    {
        return _durability;
    }

    public int GetDamage()
    {
        if(_durability > 0)
        {
            return _damage;
        }
        return 1;
    }

    public void Improve(int addedDamage)
    {
        _damage += addedDamage;
        _durability = 100;
        Console.WriteLine("Текущий урон: " + _damage);
        Console.WriteLine("Текущий состояние: " + _durability);
    }

    public void Use()
    {
        _durability--;
        if (_durability < 0)
        {
            _durability = 0;
        }
        Console.WriteLine("Использовалось оружие, текущее состояние: " + _durability);
    }
}

class Hero
{
    private string _name;
    private Weapon _weapon;
    private int _resources;

    public Hero(string name, Weapon weapon, int resources)
    {
        _name = name;
        _weapon = weapon;
        _resources = resources;
    }

    public void Attack()
    {
        int damage = _weapon.GetDamage();
        Console.WriteLine(_name + " атакует с уроном: " + damage);
        _weapon.Use();
    }

    public Weapon GetWeapon()
    {
        return _weapon;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetResources()
    {
        return _resources;
    }
}

class Blacksmith 
{ 
    public void Check(Weapon weapon, int resources)
    {
        if(resources < 10)
        {
            Console.WriteLine("Недостаточно ресурсов, требуется минимально: " + 10);
            return;
        }
        Console.WriteLine("Оружие улучшено на: " + resources);
        weapon.Improve(resources);
    }
}
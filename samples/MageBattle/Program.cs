using System;

namespace MageBattle
{
    // Класс Мага (описание героя)
    public class Mage
    {
        // Характеристики (поля класса)
        private string _name;   // Имя
        private int _health;    // Здоровье
        private int _damage;    // Урон
        private int _mana;      // Мана

        // Конструктор: вызывается при создании нового мага
        public Mage(string name, int health, int damage, int mana)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _mana = mana;
        }

        // Метод: Обычная атака
        public void Attack(Mage enemy)
        {
            Console.WriteLine($"{_name} атакует посохом!");
            enemy.TakeDamage(_damage);
        }

        // Метод: Магическая атака (Огненный шар)
        public void CastFireball(Mage enemy)
        {
            if (_mana >= 10)
            {
                _mana -= 10;
                Console.WriteLine($"{_name} кидает ОГНЕННЫЙ ШАР! (Мана осталась: {_mana})");
                enemy.TakeDamage(_damage * 2); // Двойной урон
            }
            else
            {
                Console.WriteLine($"{_name} пытается колдовать... но маны нет!");
                Attack(enemy); // Если маны нет, бьем посохом
            }
        }

        // Метод: Получение урона
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health < 0)
            {
                _health = 0; // Здоровье не может быть меньше 0
            }
            Console.WriteLine($"   >> {_name} получил {damage} урона. Здоровье: {_health}");
        }

        // Проверка: Жив ли маг?
        public bool IsAlive()
        {
            return _health > 0;
        }

        // Узнать имя (так как поле _name приватное)
        public string GetName()
        {
            return _name;
        }
    }

    // Основная программа
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создаем двух магов
            Mage mage1 = new Mage("Гэндальф", 100, 15, 40);
            Mage mage2 = new Mage("Саруман", 100, 15, 40);

            Random random = new Random();

            Console.WriteLine("--- НАЧАЛО ВЕЛИКОЙ БИТВЫ ---");
            Console.WriteLine($"{mage1.GetName()} VS {mage2.GetName()}");

            // 2. Битва идет, пока оба живы
            while (mage1.IsAlive() && mage2.IsAlive())
            {
                Console.WriteLine("\n--- Новый раунд ---");

                // --- Ход первого мага ---
                // Случайно выбираем: 0 - удар посохом, 1 - магия
                if (random.Next(0, 2) == 0)
                {
                    mage1.Attack(mage2);
                }
                else
                {
                    mage1.CastFireball(mage2);
                }

                // Если второй маг побежден, останавливаем бой сразу
                if (!mage2.IsAlive()) break;

                // --- Ход второго мага ---
                if (random.Next(0, 2) == 0)
                {
                    mage2.Attack(mage1);
                }
                else
                {
                    mage2.CastFireball(mage1);
                }
            }

            // 3. Объявление победителя
            Console.WriteLine("\n--------------------------");
            if (mage1.IsAlive())
            {
                Console.WriteLine($"Победил: {mage1.GetName()}!");
            }
            else
            {
                Console.WriteLine($"Победил: {mage2.GetName()}!");
            }
        }
    }
}
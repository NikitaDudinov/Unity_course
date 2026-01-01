using System;
using System.Collections.Generic;
using System.Linq;

namespace UnderwaterOdyssey
{
    // --- 1. МОДЕЛИ (Наследование и методы доступа) ---
    public class GameObject
    {
        private int _x;
        private int _y;
        private char _symbol;
        private ConsoleColor _color;

        // Явные методы доступа
        public int GetX()
        {
            return _x;
        }
        public int GetY()
        {
            return _y;
        }
        public void SetX(int value)
        {
            _x = value;
        }
        public void SetY(int value)
        {
            _y = value;
        }
        public char GetSymbol()
        {
            return _symbol;
        }
        public ConsoleColor GetColor()
        {
            return _color;
        }

        public GameObject(int x, int y, char symbol, ConsoleColor color)
        {
            _x = x;
            _y = y;
            _symbol = symbol;
            _color = color;
        }
    }

    public class Submarine : GameObject
    {
        private int _oxygen;
        private int _cargo;

        public int GetOxygen()
        {
            return _oxygen;
        }
        public void SetOxygen(int value)
        {
            _oxygen = value;
        }
        public int GetCargo()
        {
            return
                _cargo;
        }
        public void SetCargo(int value)
        {
            _cargo = value;
        }

        public Submarine(int x, int y)
            : base(x, y, 'V', ConsoleColor.Cyan)
        {
        }
    }

    public class Treasure : GameObject
    {
        private bool _isCollected = false;

        public bool GetIsCollected()
        {
            return _isCollected;
        }
        public void SetIsCollected(bool value)
        {
            _isCollected = value;
        }

        public Treasure(int x, int y)
            : base(x, y, '?', ConsoleColor.Yellow)
        {
        }
    }

    // --- 2. ГРАФИКА (Отрисовка) ---
    public static class OceanRenderer
    {
        public static void Render(Submarine sub, GameObject dock, List<Treasure> treasures, int level)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"=== ГЛУБИНА: {level}00м | КИСЛОРОД: {sub.GetOxygen()}л | ЗОЛОТО: {sub.GetCargo()}/{treasures.Count}    ");

            for (int y = 0; y < 11; y++)
            {
                for (int x = 0; x < 35; x++)
                {
                    if (x == sub.GetX() && y == sub.GetY()) Draw(sub);
                    else if (x == dock.GetX() && y == dock.GetY()) Draw(dock);
                    else
                    {
                        var tr = treasures.FirstOrDefault(t => t.GetX() == x && t.GetY() == y && !t.GetIsCollected());
                        if (tr != null) Draw(tr);
                        else Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Draw(GameObject obj)
        {
            Console.ForegroundColor = obj.GetColor();
            Console.Write(obj.GetSymbol() + " ");
            Console.ResetColor();
        }
    }

    // --- 3. ГЛАВНЫЙ МЕНЕДЖЕР (Управление) ---
    class GameManager
    {
        static int level = 1;
        static bool isRunning = true;
        static Submarine player = new Submarine(2, 2);
        static GameObject dockStation = new GameObject(30, 10, 'H', ConsoleColor.Green);
        static List<Treasure> treasures = new List<Treasure>();

        static void Main()
        {
            Console.CursorVisible = false;
            SetupLevel();

            while (isRunning)
            {
                OceanRenderer.Render(player, dockStation, treasures, level);
                HandleInput();
                UpdateLogic();
            }
        }

        static void SetupLevel()
        {
            player.SetX(2); player.SetY(2);
            player.SetOxygen(65 - (level * 5));
            player.SetCargo(0);
            treasures.Clear();
            Random rnd = new Random();
            for (int i = 0; i < level + 1; i++)
                treasures.Add(new Treasure(rnd.Next(5, 30), rnd.Next(2, 11)));
        }

        static void HandleInput()
        {
            if (!Console.KeyAvailable) return;
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow) { player.SetY(player.GetY() - 1); player.SetOxygen(player.GetOxygen() - 1); }
            if (key == ConsoleKey.DownArrow) { player.SetY(player.GetY() + 1); player.SetOxygen(player.GetOxygen() - 1); }
            if (key == ConsoleKey.LeftArrow) { player.SetX(player.GetX() - 1); player.SetOxygen(player.GetOxygen() - 1); }
            if (key == ConsoleKey.RightArrow) { player.SetX(player.GetX() + 1); player.SetOxygen(player.GetOxygen() - 1); }
        }

        static void UpdateLogic()
        {
            // Сбор золота
            foreach (var t in treasures.Where(x => !x.GetIsCollected()))
            {
                if (player.GetX() == t.GetX() && player.GetY() == t.GetY())
                {
                    t.SetIsCollected(true);
                    player.SetCargo(player.GetCargo() + 1);
                }
            }

            // Победа на уровне
            if (player.GetX() == dockStation.GetX() && player.GetY() == dockStation.GetY() && player.GetCargo() == treasures.Count)
            {
                level++;
                if (level > 5) Finish("ОКЕАН ИССЛЕДОВАН! ВЫ - ЛЕГЕНДАРНЫЙ ПИЛОТ!");
                else SetupLevel();
            }

            // Проигрыш
            if (player.GetOxygen() <= 0) Finish("КИСЛОРОД КОНЧИЛСЯ. МИССИЯ ПРОВАЛЕНА.");
        }

        static void Finish(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            isRunning = false;
            Console.ReadKey();
        }
    }
}
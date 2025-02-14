using System;
using ZooSystem;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Program
{
    public static class DIConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<Zoo>();
            services.AddSingleton<IClinic, Clinic>();
            services.AddTransient<IInventory, Table>();
            services.AddTransient<IInventory, Computer>();
            services.AddTransient<IAlive, Monkey>();
            services.AddTransient<IAlive, Tiger>();
            services.AddTransient<IAlive, Rabbit>();
            services.AddTransient<IAlive, Wolf>();

            var result = services.BuildServiceProvider();
            return result;
        }
    }
    class Program
    {
        public static bool isOk1(int num)
        {
            if (num > 0 && num < 11) return true;
            return false;
        }

        public static bool isOk2(int num)
        {
            if (num >= 0 && num < 11) return true;
            return false;
        }
        public static bool isOk3(int num)
        {
            if (num > 0) return true;
            return false;
        }
        static void Main(string[] args)
        {
            string command;
            IServiceProvider serviceProvider = DIConfig.ConfigureServices();
            Zoo zoo = serviceProvider.GetRequiredService<Zoo>();

            while (true)
            {
                try
                {
                    Console.WriteLine("'add_animal' - добавить животное.");
                    Console.WriteLine("'add_inventory' - добавить инвентарь.");
                    Console.WriteLine("'report' - отчет по всем животным и инвентарям.");
                    Console.WriteLine("'food_consumption' - Общее количество кг еды употребляемых животным в день.");
                    Console.WriteLine("'contactable_animals' - показ всех животных, с которыми можно взаимодействовать.");
                    Console.WriteLine("'exit' - выход из программы.");
                    Console.Write("Введите команду: ");
                    command = Console.ReadLine();

                    if (command == "add_animal")
                    {
                        Console.WriteLine("Введите тип животного [rabbit, tiger, monkey, wolf]:");
                        string type = Console.ReadLine();
                        while (type != "rabbit" && type != "tiger" && type != "monkey" && type != "wolf") {
                            Console.WriteLine("Неправильное животное. Введите тип животного [rabbit, tiger, monkey, wolf]:");
                            type = Console.ReadLine();
                        };

                        Console.WriteLine("Введите имя животного: ");
                        string name = Console.ReadLine();


                        int food;
                        Console.WriteLine("Введите целое число > 0: количество еды употребляемый животным в день.");
                        while(!(int.TryParse(Console.ReadLine(), out food) && isOk3(food)))
                        {
                            Console.WriteLine("Неправильное значение для переменной");
                            Console.WriteLine("Введите целое число > 0: количество еды употребляемый животным в день.");
                        }

                        int health;
                        Console.WriteLine("Введите целое число > 0 и <= 10: Уровень здоровья животного.");
                        while (!(int.TryParse(Console.ReadLine(), out health) && isOk1(health)))
                        {
                            Console.WriteLine("Неправильное значение для переменной");
                            Console.WriteLine("Введите целое число > 0 и <= 10: Уровень здоровья животного.");
                        }

                        if (type == "monkey" || type == "rabbit")
                        {
                            int kind;
                            Console.WriteLine("Введите целое число > 0 и <= 10: Уровень доброты животного.");
                            while (!(int.TryParse(Console.ReadLine(), out kind) && isOk2(kind)))
                            {
                                Console.WriteLine("Неправильное значение для переменной");
                                Console.WriteLine("Введите целое число > 0 и <= 10: Уровень здоровья животного.");
                            }

                            if (type == "monkey")
                            {
                                Monkey monkey = new Monkey(name, health, kind, food);
                                zoo.AddAnimal(monkey);
                            }
                            else
                            {
                                Rabbit rabbit = new Rabbit(name, health, kind, food);
                                zoo.AddAnimal(rabbit);
                            }
                        } else
                        {
                            int agg;
                            Console.WriteLine("Введите целое число > 0 и <= 10: Уровень агрессии животного.");
                            while (!(int.TryParse(Console.ReadLine(), out agg) && isOk2(agg)))
                            {
                                Console.WriteLine("Неправильное значение для переменной");
                                Console.WriteLine("Введите целое число >= 0 и <= 10: Уровень агрессии животного.");
                            }

                            int auf_score;
                            Console.WriteLine("Введите целое число >= 0 и <= 10: Уровень АУФности(крутости) животного.");
                            while (!(int.TryParse(Console.ReadLine(), out auf_score) && isOk2(auf_score)))
                            {
                                Console.WriteLine("Неправильное значение для переменной");
                                Console.WriteLine("Введите целое число > 0 и <= 10: Уровень агрессии животного.");
                            }
                            if (type == "tiger")
                            {
                                Tiger tiger = new Tiger(name, health, agg, food, auf_score);
                                zoo.AddAnimal(tiger);
                            }
                            else
                            {
                                Wolf wolf = new Wolf(name, health, agg, food, auf_score);
                                zoo.AddAnimal(wolf);
                            }
                        }

                    }
                    else if (command == "add_inventory") {
                        Console.WriteLine("Введите тип инвентаря [computer, table]:");
                        string type = Console.ReadLine();
                        while (type != "computer" && type != "table")
                        {
                            Console.WriteLine("Введите тип инвентаря [computer, table]:");
                            type = Console.ReadLine();
                        };

                        Console.WriteLine("Введите название модели инвентаря: ");
                        string name = Console.ReadLine();
                        int number;
                        Console.WriteLine("Введите номер интвентаря(целое число):");
                        while (!(int.TryParse(Console.ReadLine(), out number)))
                        {
                            Console.WriteLine("Неправильное значение для переменной");
                            Console.WriteLine("Введите номер интвентаря(целое число):");
                        }
                        if (type == "computer")
                        {
                            Computer computer = new Computer(number, name);
                            zoo.AddInventory(computer);
                        }
                        else
                        {
                            Table table = new Table(number, name);
                            zoo.AddInventory(table);
                        }

                    }
                    else if (command == "report")
                    {
                        zoo.Report();
                    }
                    else if (command == "food_consumption")
                    {
                        Console.Write("Общее количество кг еды употребляемых животным в день: ");
                        Console.WriteLine(zoo.TotalFoodConsumption());
                    }
                    else if (command == "contactable_animals")
                    {
                        Console.WriteLine("Список животных, с которыми можно взаимодействовать:");
                        List<Herbo> res = zoo.ContactableAnimals();
                        foreach (Herbo herbo in res)
                        {
                            Console.WriteLine(herbo.ToString());
                        }
                    }
                    else if (command == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверная команда. Повторите попытку.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: ");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

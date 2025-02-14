using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSystem
{
    internal class Zoo
    {
        private IClinic clinic;
        private List<IAlive> animals = new List<IAlive>(0);
        private List<IInventory> inventories = new List<IInventory>(0);

        public Zoo(IClinic clinic)
        {
            this.clinic = clinic;
        }

        public void AddAnimal(IAlive animal)
        {
            if (clinic.IsHealthy(animal))
            {
                animals.Add(animal);
                Console.WriteLine("Животное успешно добавлено");
            }
            else
            {
                Console.WriteLine("Животное невозможно добавить в зоопарк по состоянию здоровья");
            }
        }

        public void AddInventory(IInventory inventory)
        {
            inventories.Add(inventory);
        }

        public int TotalFoodConsumption()
        {
            if(animals.Count == 0) return 0;
            return animals.Sum(animals => animals.Food);
        }
        
        public List<IAlive> GetAnimalsList {get { return animals; }}
        public List<IInventory> GetInventoriesList { get {  return inventories; }}

        public void Report()
        {
            Console.WriteLine("Отчет по животным: ");
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine($"Количество животных: {animals.Count}");
            Console.WriteLine($"Общее количество кг употребляемых животным в день: {TotalFoodConsumption()}");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Отчет по инвентарю:");
            foreach(var inventory in inventories)
            {
                Console.WriteLine(inventory.ToString());
            }
            Console.WriteLine($"Количество инвентаря: {inventories.Count}");
        }
        public List<Herbo> ContactableAnimals()
        {
            return animals.OfType<Herbo>().Where(animal => animal.KindnessScore > 5).ToList();
        }

    }
}

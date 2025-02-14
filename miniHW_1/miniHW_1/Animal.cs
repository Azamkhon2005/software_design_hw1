using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSystem
{
    public abstract class Animal : IAlive
    {
        private string name;
        private int health;

        public abstract int Food { get; }
        public Animal() { }        
        
        public Animal(string name, int health)
        {
            if (health > 0 && health < 11) {
                this.name = name;
                this.health = health;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(health), $"Значение health должно быть в диапазоне [1, 10]");
            }
            
        }

        public string Name { get { return name; } }

        public int HealthScore { get { return health; } 
            set { 
                if (value > 0 && value < 11) {
                    health = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(health), $"Значение health должно быть в диапазоне [1, 10]");
                }
            } 
        }
    }
}

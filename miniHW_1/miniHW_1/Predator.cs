using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSystem
{
    public abstract class Predator : Animal
    {
        private int aggressionScore;
        public Predator(string name, int health, int aggressionScore) : base(name, health)
        {
            
            if (aggressionScore >= 0 && aggressionScore < 11)
            {
                this.aggressionScore = aggressionScore;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(aggressionScore), $"Значение aggressionScore должно быть в диапазоне [0, 10]");
            }
        }

        public int AggressionScore { get { return aggressionScore; }
            set
            {
                if (value >= 0 && value < 11)
                {
                    aggressionScore = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(aggressionScore), $"Значение aggressionScore должно быть в диапазоне [0, 10]");
                }
            }
        }

        public override abstract int Food { get; }
    }
}

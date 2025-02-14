using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSystem
{

    public abstract class Herbo:Animal
    {

        private int kindnessScore;

        public Herbo() { }
        public Herbo(string name, int hp, int kindnessScore) : base(name, hp)
        {
            if (kindnessScore >= 0 && kindnessScore < 11)
            {
                this.kindnessScore = kindnessScore;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(kindnessScore), $"Значение kindnessScore должно быть в диапазоне [0, 10]");
            }
        }

        public int KindnessScore{ get { return kindnessScore; }
            set
            {
                if (value >= 0 && value < 11)
                {
                    kindnessScore = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(kindnessScore), $"Значение kindnessScore должно быть в диапазоне [0, 10]");
                }
            }
        }

        public override abstract int Food { get; }
    }
}
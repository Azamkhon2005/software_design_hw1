using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooSystem
{
    public class Monkey : Herbo
    {
        private int foodConsume;
        public Monkey() { }

        public Monkey(string name, int health, int kindnessScore, int foodConsume) : base(name, health, kindnessScore)
        {
            if (foodConsume > 0)
            {
                this.foodConsume = foodConsume;
            }
            else { throw new ArgumentOutOfRangeException(nameof(foodConsume), $"Значение foodConsume должно быть > 0"); }
        }
        public override int  Food {get{return foodConsume;} }
        public override string ToString()
        {
            return $"Class: {base.ToString().Split('.')[1]}, Name: {base.Name}, kindnessScore: {base.KindnessScore}, health: {base.HealthScore}, foodConsume: {foodConsume}";
        }
    }

    public class Rabbit : Herbo
    {
        private int foodConsume;
        public Rabbit(string name, int health, int kindnessScore, int foodConsume) : base(name, health, kindnessScore)
        {
            if (foodConsume > 0)
            {
                this.foodConsume = foodConsume;
            }
            else { throw new ArgumentOutOfRangeException(nameof(foodConsume), $"Значение foodConsume должно быть > 0"); }
        }
        public override int Food { get { return foodConsume; } }
        public override string ToString()
        {
            return $"Class: {base.ToString().Split('.')[1]}, Name: {base.Name}, kindnessScore: {base.KindnessScore}, health: {base.HealthScore}, foodConsume: {foodConsume}";
        }
    }


    public class Tiger : Predator
    {
        private int foodConsume;
        private int aufScore;
        public Tiger(string name, int health, int aggressionScore, int foodConsume, int aufScore) : base(name, health, aggressionScore)
        {
            if (foodConsume > 0)
            {
                this.foodConsume = foodConsume;
            }
            else { throw new ArgumentOutOfRangeException(nameof(foodConsume), $"Значение foodConsume должно быть > 0."); }
            if (aufScore >= 0 && aufScore < 11)
            {
                this.aufScore = aufScore;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(aufScore), $"ДАВАЙ НЕ МАРАСИ ДА БРАТ. Значение aufScore должно быть в диапазоне [0, 10]");
            }
        }
        public override int Food { get { return foodConsume;} }

        public void Status()
        {
            if(aufScore > 7) {
                Console.WriteLine("ВУААЙ ЭТО ЧЕ ЗА ЛЕВ ЭТОТ ТИГР!!!");
            }
            else
            {
                Console.WriteLine("НАШЕМУ БРАТУ ТИГРУ НУЖНА ПОДКАЧАТСЯ ДОН!");  
            }
        }
        public override string ToString()
        {
            return $"Class: {base.ToString().Split('.')[1]}, Name: {base.Name}, aggressionScore: {base.AggressionScore}, health: {base.HealthScore}, foodConsume: {Food}";
        }
    }


    public class Wolf : Predator
    {
        private int foodConsume;
        private int aufScore;

        public Wolf(string name, int health, int aggressionScore, int foodConsume, int aufScore) : base(name, health, aggressionScore)
        {
            if (foodConsume > 0)
            {
                this.foodConsume = foodConsume;
            }
            else { throw new ArgumentOutOfRangeException(nameof(foodConsume), $"Значение foodConsume должно быть > 0"); }
            if (aufScore >= 0 && aufScore < 11)
            {
                this.aufScore = aufScore;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(aufScore), $"ДАВАЙ НЕ МАРАСИ ДА БРАТ. Значение aufScore должно быть в диапазоне [0, 10]");
            }
        }
        public override int Food { get { return foodConsume; } }

        public void Status()
        {
            if (aufScore > 7)
            {
                Console.WriteLine("СИЯЙ НАШ БРАТ УОЛК!!!");
            }
            else
            {
                Console.WriteLine("НАШЕМУ БРАТУ УОЛКУ НУЖНА ПАДКАЧАТСЯ ДОН!");
            }
        }

        public override string ToString()
        {
            return $"Class: {base.ToString().Split('.')[1]}, Name: {base.Name}, aggressionScore: {base.AggressionScore}, health: {base.HealthScore}, foodConsume: {Food}";
        }
    }
}

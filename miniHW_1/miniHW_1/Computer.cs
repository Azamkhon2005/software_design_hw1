using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSystem
{
    internal class Computer : IInventory
    {
        private int id;
        private string modelName;
        public Computer(int id, string model_name)
        {
            this.id = id;
            this.modelName = model_name;
        }
        public int Number { get { return id; } }
        public string ModelName { get { return modelName; } }

        public override string ToString()
        {
            return $"Class: {base.ToString().Split('.')[1]}, Number: {id}, ModelName: {modelName}";
        }
    }
}

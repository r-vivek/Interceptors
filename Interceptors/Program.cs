using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interceptors.IC;

namespace Interceptors
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var rex = Freezable.MakeFreezable<Pet>();
            rex.DataReturn();
            rex.Name = "Rex";
            Console.WriteLine(Freezable.IsFreezable(rex)
                ? "Rex is freezable!"
                : "Rex is not freezable. Something is not working");
            Console.WriteLine(rex.ToString());
            Console.WriteLine("Add 50 years");
            rex.Age += 50;
            Console.WriteLine("Age: {0}", rex.Age);
            rex.Deceased = true;

            Console.WriteLine("Deceased: {0}", rex.Deceased);
            Freezable.Freeze(rex);
            try
            {
                rex.Age++;
            }
            catch (ObjectFrozenException ex)
            {
                Console.WriteLine("Oups. it's frozen. Can't change that anymore");
            }
            Console.WriteLine("--- press enter to close");
            Console.ReadLine();

        }
        public class Pet
        {
            public virtual string Name { get; set; }
            public virtual int Age { get; set; }
            public virtual bool Deceased { get; set; }

            public virtual void DataReturn()
            {
                Console.WriteLine("Return the data");
            }
            public override string ToString()
            {
                return string.Format("Name: {0}, Age: {1}, Deceased: {2}", Name, Age, Deceased);
            }
        }
    }
}

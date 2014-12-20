using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace BigIntegerExtenderExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger value;
            do
            {
                Console.Write("Insert a number: ");
            } while (!BigInteger.TryParse(Console.ReadLine(), out value));

            ExampleSqrt(value);
            ExampleSerialization(value);

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }

        static void ExampleSqrt(BigInteger value)
        {
            bool isPerfect;

            var lowerSqrt = value.Sqrt(out isPerfect, false);
            // OR BigIntegerExtender.Sqrt(value, out isPerfect, false);

            var sqrt = value.Sqrt(out isPerfect, true);
            // OR BigIntegerExtender.Sqrt(value, out isPerfect, true);

            Console.WriteLine("Sqrt: " + lowerSqrt);
            Console.WriteLine("Sqrt (round up): " + sqrt);
            Console.WriteLine("Is perfect?: " + isPerfect);
        }

        static void ExampleSerialization(BigIntegerSerializable value)
        {
            var mem = new MemoryStream();
            var bf = new XmlSerializer(value.GetType());
            bf.Serialize(mem, value);
            Console.WriteLine("XML serialization: " + Encoding.UTF8.GetString(mem.ToArray()));
        }
    }
}

BigIntegerExtender
==================
BigIntegerExtender is written in C# and extends System.Numerics.BigInteger to support serialization and the calculation of square roots.
It contains:
* **BigIntegerSerializable**: this enables you to serialize System.Numerics.BigInteger objects.
* **BigIntegerExtender**: it has an extension method that adds the function Sqrt to System.Numerics.BigInteger objects.

Examples
==================
Remember to add System.Numerics.BigInteger, BigIntegerExtender and System.Xml before using this library in your projects.
```cs
using System;
using System.Numerics;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                BigInteger value;
                do
                {
                    Console.Write("Enter a valid number: ");
                } while (!BigInteger.TryParse(Console.ReadLine(), out value));

                try
                {
                    BigInteger sqrt = value.Sqrt();
                    Console.WriteLine(String.Format("Sqrt of {0}: {1}\n", value, sqrt));
                }
                catch(ArithmeticException)
                {
                    Console.WriteLine(String.Format("Sqrt of {0}: NaN\n", value));
                }
            }
        }
    }
}
```
```cs
using System;
using System.Numerics;
using System.Xml.Serialization;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                BigInteger value;
                do
                {
                    Console.Write("Enter a valid number: ");
                } while (!BigInteger.TryParse(Console.ReadLine(), out value));

                var ms = new System.IO.MemoryStream();
                var serializer = new XmlSerializer(typeof(BigIntegerSerializable));
                serializer.Serialize(ms, (BigIntegerSerializable)value);

                Console.Write("\nXML: ");
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(ms.ToArray()));
                Console.WriteLine("\n");
            }
        }
    }
}
```
How to Engage, Contribute and Provide Feedback
==================
1. If you want to contribute, make sure that there is a corresponding issue for your change first. If there is none, create one.
2. Create a fork in GitHub.
3. Create a branch off the master branch with an adequate name.
4. Commit your changes and push your changes to GitHub.
5. Create a pull request against the origin's master branch.

###DOs and DON'Ts
* **DO** follow [C# Coding Conventions](http://msdn.microsoft.com/en-us/library/ff926074.aspx).
* **DO** run all tests in BigIntegerExtenderTests project before committing your changes. When adding new features, include adequate tests for those.
* **DO** run Code Analysis before committing your changes.

License
==================
This project is licensed under the [MIT license](LICENSE).

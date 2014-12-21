BigIntegerExtender
==================
BigIntegerExtender extends System.Numerics.BigInteger to support serialization and the calculation of square roots.
It contains:
* **BigIntegerSerializable**: with this you can serialize System.Numerics.BigInteger objects.
* **BigIntegerExtender**: it has an extension method that add the function Sqrt to System.Numerics.BigInteger objects.

To understand how it works and how to use it, see the Examples (work in progress).

How to Engage, Contribute and Provide Feedback
==================
1. If you want to contribute, make sure that there is a corresponding issue for your change first. If there is none, create one.
2. Create a fork in GitHub.
3. Create a branch off the master branch with an adequate name.
4. Commit your changes and push your changes to GitHub.
5. Create a pull request against the origin's master branch.

##DOs and DON'Ts
* **DO** follow [C# Coding Conventions](http://msdn.microsoft.com/en-us/library/ff926074.aspx).
* **DO** run all tests in BigIntegerExtenderTests project before committing your changes. When adding new features, include adequate tests for those.
* **DO** run Code Analysis before committing your changes.

License
==================
This project is licensed under the [MIT license](LICENSE).

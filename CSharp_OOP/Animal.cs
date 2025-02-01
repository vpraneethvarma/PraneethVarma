using System;

public abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public abstract void MakeSound();

    public virtual void Describe()
    {
        Console.WriteLine($"This is a {Name}.");
    }
}

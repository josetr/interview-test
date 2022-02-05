namespace InterviewTest;

using System;

public class Person
{
    public string Name { get; set; }
    public Guid Id { get; set; }

    protected Person(Guid id, string name)
    {
        Name = name;
        Id = id;
    }

    protected Person() { }

    public override bool Equals(object obj)
    {
        return obj is Person person && Id == person.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

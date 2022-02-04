namespace InterviewTest
{
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

        public Person() { }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Id == ((Person)obj).Id || base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
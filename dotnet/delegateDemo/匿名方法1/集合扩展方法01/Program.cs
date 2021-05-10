using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;//linq

namespace 集合扩展方法01
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] person = new Person[]
            {
                new Person("licy",18),
                new Person("muzilicy",24),
                new Person("muzilicy_0907",27)
            };
            //int sum = person.Sum(p => p.Age);
            //int sum = person.MySum(p => p.Age);
            //Console.WriteLine(sum);

            IEnumerable<Person> persons = person.OrderBy(d => d.Age).ToList();

            Person[] personArr = person.OrderByDescending(d => d.Age).ToArray();

            List<Person> ps3 = persons.ToList();

            Person[] ps4 = personArr.ToArray();

            Console.WriteLine(ps4);
            Console.WriteLine(ps3);
            Console.ReadKey();
        }
    }

    class Person
    {
        public Person(string name,int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }
}

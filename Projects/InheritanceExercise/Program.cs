//Exercise - I
//Part - 1: Creating classes

/*using System;

class A
{
    public void a()
    {
        Console.WriteLine("A");
    }
}

class B
{
    public void b()
    {
        Console.WriteLine("B");
    }
}

class C
{
    public void c()
    {
        Console.WriteLine("C");
    }
}
// Creates instances of A, B, and C, then calls their required methods in order.
class MainClass
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();

        a.a();
        b.b();
        c.c();
    }
}*/
/*using System;

public class A
{
    // Base class method: prints "A"
    public void a()
    {
        Console.WriteLine("A");
    }
}

public class B : A
{
    public void b()
    {
        Console.WriteLine("B");
    }
}

public class C : B
{
    public void c()
    {
        Console.WriteLine("C");
    }
}

public class Program
{
    public static void Main()
    {
        C c = new C();

        c.a();
        c.b();
        c.c();
    }
}*/

//Part-2: Class inheritance

/*using System;

class Person
{
    private string name;
    private string address;

    public Person(string name, string address)
    {
        this.name = name;
        this.address = address;
    }

    public string Show()
    {
        // Name on one line, then address on the next line (with a leading space).
        return $"{name}\n {address}";
    }
}

class Program
{
    static void Main()
    {
        Person ada = new Person("Ada Lovelace", "24 Maddox St. London W1S 2QN");
        Person esko = new Person("Esko Ukkonen", "Mannerheimintie 15 00100\nHelsinki");

        Console.WriteLine(ada.Show());
        Console.WriteLine(esko.Show());
    }
}*/

//Exercise-II
//Part - 1: Person
//Create a class Person

/*using System;

public class Person
{
    private string name;
    private string address;
    public Person(string name, string address)
    {
        this.name = name;
        this.address = address;
    }
    public string Show()
    {
        // Name on one line, then address on the next line (with a leading space).
        return $"{name}\n {address}";
    }
}
public class Student : Person
{
    private int studyCredits;

    public Student(string name, string address) : base(name, address)
    {
        this.studyCredits = 0;
    }

    public int Credits()
    {
        return this.studyCredits;
    }

    public void Study()
    {
        this.studyCredits++;
    }
}
class Program
{
     static void Main()
    {
         Student ollie = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
         Console.WriteLine(ollie.Show());
         Console.WriteLine("Study credits " + ollie.Credits());
         ollie.Study();
         Console.WriteLine("Study credits " + ollie.Credits());
     }
}*/

//Part-2: Student
//Create a class Student, which inherits the class Person.

/*using System;
using System.Net;
using System.Xml.Linq;

public class Person
{
    protected string name;
    protected string address;

    public Person(string name, string address)
    {
        this.name = name;
        this.address = address;
    }

    public virtual string Show()
    {
        return $"{name}\n  {address}";
    }
}

public class Student : Person
{
    private int studyCredits;

    public Student(string name, string address) : base(name, address)
    {
        this.studyCredits = 0;
    }

    public int Credits()
    {
        return this.studyCredits;
    }

    public void Study()
    {
        this.studyCredits++;
    }

    public override string Show()
    {
        return $"{name}\n  {address}\n Study credits {Credits()}";
    }
}

class Program
{
    static void Main()
    {
        Student ollie = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
        Console.WriteLine(ollie.Show());
        ollie.Study();
        Console.WriteLine(ollie.Show());

    }
}*/

//Part-5: List all Persons

public class Person
{
    public string Name { get; }
    public string Address { get; }

    public Person(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public override string ToString()
    {
        return $"{Name}\n {Address}";
    }
}
public class Student : Person
{
    public int StudyCredits { get; private set; }

    public Student(string name, string address)
        : base(name, address)
    {
        StudyCredits = 0;
    }

    public override string ToString()
    {
        return $"{base.ToString()}\n Study credits {StudyCredits}";
    }
}

public class Teacher : Person
{
    public int Salary { get; }

    public Teacher(string name, string address, int salary)
        : base(name, address)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{base.ToString()}\n salary {Salary} euro/month";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
         List<Person> persons = new List<Person>();
         persons.Add(new Teacher("Ada Lovelace", "24 Maddox St. London W1S 2QN", 1200));
         persons.Add(new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028"));
         PrintPersons(persons);
    }

    public static void PrintPersons(List<Person> persons)
    {
        foreach (Person p in persons)
        {
            Console.WriteLine(p.ToString());
        }
    }
}
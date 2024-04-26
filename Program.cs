using System;
using System.Linq;

public class Member
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Birthplace { get; set; }
    public int Age {get; set;}
    public bool IsGraduated { get; set; }
    public string FullName => LastName + ' ' + FirstName;
}
public class Program
{
    public static void Main()
    {
        List<Member> members = new List<Member>
        {
            new Member { FirstName = "Van A", LastName = "Nguyen", Gender = "Male", DateOfBirth = new DateTime(2000, 1, 1), PhoneNumber = "0123456789", Birthplace = "Ha Noi", Age = 24, IsGraduated = true },
            new Member { FirstName = "Van B", LastName = "Nguyen", Gender = "Male", DateOfBirth = new DateTime(2001, 1, 1), PhoneNumber = "0123456789", Birthplace = "Ha Noi", Age = 23, IsGraduated = true },
            new Member { FirstName = "Van C", LastName = "Nguyen", Gender = "Female", DateOfBirth = new DateTime(2002, 1, 1), PhoneNumber = "0123456789", Birthplace = "Ha Noi", Age = 22, IsGraduated = true },
            new Member { FirstName = "Van D", LastName = "Nguyen", Gender = "Male", DateOfBirth = new DateTime(1999, 1, 1), PhoneNumber = "0123456789", Birthplace = "Ha Noi", Age = 25, IsGraduated = true }
        };
        while (true)
        {
            try
            {
                Console.WriteLine("Option: ");
                Console.WriteLine("1. Return a list of members who are Male");
                Console.WriteLine("2. Return the oldest one based on 'Age'");
                Console.WriteLine("3. Return a new list that contains Full Name only ( Full Name = Last Name + First Name)");
                Console.WriteLine("4. Return 3 lists:");
                Console.WriteLine("     List of members who have a birth year of 2000");
                Console.WriteLine("     List of members who have a birth year greater than 2000");
                Console.WriteLine("     List of members who have a birth year less than 2000");
                Console.WriteLine("5. Return the first person who was born in Ha Noi.");
                Console.Write("Enter your choice (1-5): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var malesMember = members.Where(m => m.Gender == "Male");
                        foreach (var member in malesMember)
                        {
                            Console.WriteLine("Name: " + member.FullName);
                        }
                        break;
                    case 2:
                        var oldestMember = members.OrderBy(m => m.DateOfBirth).First();
                        Console.WriteLine ("Oldest member: " + oldestMember.FullName);
                        break;
                    case 3:
                        var fullNames = members.Select(m => m.LastName + ' ' + m.FirstName);
                        foreach (var fullName in fullNames)
                        {
                            Console.WriteLine("Full Name of Member: " + fullName);
                        }
                        break;                    
                    case 4:
                        var bornIn2000 = members.Where (m => m.DateOfBirth.Year == 2000).ToList();
                        var bornBefore2000 = members.Where (m => m.DateOfBirth.Year < 2000).ToList();
                        var bornAfter2000 = members.Where (m => m.DateOfBirth.Year > 2000).ToList();
                        Console.WriteLine("Member born in 2000: ");
                        foreach (var member in bornIn2000)
                        {
                            Console.WriteLine(member.FullName);
                        }
                        Console.WriteLine("Member born after 2000: ");
                        foreach (var member in bornAfter2000)
                        {
                            Console.WriteLine(member.FullName);
                        }
                        Console.WriteLine("Member born before 2000: ");
                        foreach (var member in bornBefore2000)
                        {
                            Console.WriteLine(member.FullName);
                        }
                        break;
                    case 5:
                        var firstBornInHaNoi = members.Where (m => m.Birthplace == "Ha Noi").FirstOrDefault();
                        Console.WriteLine("The First Born in Ha Noi: " + firstBornInHaNoi.FullName);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
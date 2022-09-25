using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP_HW2.Entitities
{
    public class Person
    {
        public static int LastId { get; set; } = 0;

        public Person()
        {

        }

        public Person(string name, string surname, int age, string ımage, IFormFile file)
        {
            Id = ++LastId;
            Name = name;
            Surname = surname;
            Age = age;
            Image = ımage;
            MyFile = file;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }

        public IFormFile  MyFile { get; set; }


        public override string ToString()
        {
            return $"Id: {this.Id}" +
                   $"Name: {this.Name}" +
                   $"Surname: {this.Surname}" +
                   $"Age: {this.Age}" +
                   $"Image: {this.Image}";
        }
    }
}

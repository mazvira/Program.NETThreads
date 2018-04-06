using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Lab5
{
    static class DBAdapter
    {
        public static List<Person> Users { get; }

        static DBAdapter()
        {
            var filepath = Path.Combine(GetAndCreateDataPath(), Person.Filename);
            if (File.Exists(filepath))
            {
               
            }
            else
            {
                Users = new List<Person>();
                for (int i = 0; i < 50; ++i)
                {
                    Person toAdd = new Person($"Olya{i}", $"Petrenko{i}", new DateTime(1996, 5, 23));
                    Users.Add(toAdd);
                }
            }
        }

        internal static Person CreatePerson(string name, string lastName, string email, DateTime dateOfBirth)
        {
            Person person = null;
            try
            {

                person = new Person(name, lastName, email, dateOfBirth);
            }
           
        }


        private static string GetAndCreateDataPath()
        {
           // string dir = StationManager.WorkingDirectory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

    }
}

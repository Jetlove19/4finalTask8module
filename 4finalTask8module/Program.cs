﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _4finalTask8module
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFolder();
            СreateFile();
        }
        public static void СreateFile()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Student[] students =
                 {
             new Student("Евгений", "Группа1", new DateTime(2009, 5, 29)),
             new Student("Паша", "Группа1", new DateTime(2007, 5, 29)),
             new Student("Ваня", "Группа2", new DateTime(2008, 5, 29)),
             new Student("Гриша", "Группа1", new DateTime(2007, 5, 29)),
             new Student("Света", "Группа3", new DateTime(2005, 5, 29)),
             new Student("Вова", "Группа2", new DateTime(2007, 5, 30)),
             new Student("Вася", "Группа3", new DateTime(2007, 5, 30)),
             new Student("Кирилл", "Группа2", new DateTime(2007, 5, 30)),
             new Student("Жора", "Группа1", new DateTime(2007, 5, 30)),
             };
                
                using (var fs = new FileStream(@"\Users\Jetlove\Desktop\Students.dat", FileMode.OpenOrCreate))
                {
                    foreach (Student student in students)
                    {
                        formatter.Serialize(fs, students);
                    }
                    Console.WriteLine("Создан фаил Students.dat и записаны студенты ");
                }

                
                using (var fs = new FileStream(@"\Users\Jetlove\Desktop\Students.dat", FileMode.Open))
                {
                    foreach (Student student in students)
                    {
                        formatter.Deserialize(fs);
                    }

                    using StreamWriter sw = new StreamWriter(@"\Users\Jetlove\Desktop\Group1.txt");
                    foreach (Student student in students)
                    {
                        if (student.Group == "Группа1")
                            sw.WriteLine($"Name: {student.Name} DateOfBirth: {student.DateOfBirth} ");
                    }
                    Console.WriteLine("Cписок Группы 1 создан");

                    using StreamWriter sR = new StreamWriter(@"\Users\Jetlove\Desktop\Group2.txt");
                    foreach (Student student in students)
                    {
                        if (student.Group == "Группа2")
                            sR.WriteLine($"Name: {student.Name} DateOfBirth: {student.DateOfBirth} ");
                    }
                    Console.WriteLine("Cписок Группы 2 создан");
                    using StreamWriter sF = new StreamWriter(@"\Users\Jetlove\Desktop\Group3.txt");
                    foreach (Student student in students)
                    {
                        if (student.Group == "Группа3")
                            sF.WriteLine($"Name: {student.Name} DateOfBirth: {student.DateOfBirth} ");
                    }
                    Console.WriteLine("Cписок Группы 3 создан");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void CreateFolder()
        {
            try
            {
                DirectoryInfo newDirectory = new DirectoryInfo(@"\Users\Jetlove\Desktop\Students");
                if (!newDirectory.Exists)
                    newDirectory.Create();
                Console.WriteLine("Папка создана.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
    }

namespace _10._SoftUni_Course_Planning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> lessons = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "course start")
                {
                    break;
                }
                {
                    string[] tokens = input.Split(':');
                    string command = tokens[0];
                    string lesson = tokens[1];

                    if (command == "Add")
                    {
                        if (lessons.Contains(lesson) == false)
                        {
                            lessons.Add(lesson);
                        }

                    }
                    else if (command == "Insert")
                    {
                        int index = int.Parse(tokens[2]);
                        if (lessons.Contains(lesson) == false)
                        {
                            lessons.Insert(index, lesson);
                        }
                    }
                    else if (command == "Remove")
                    {
                        if (lessons.Contains(lesson) == false)
                        {
                            int index = lessons.IndexOf(lesson);
                            if (lessons.Contains($"{lesson}-Exercise"))
                            {
                                lessons.RemoveAt(index + 1);
                            }
                        }
                        lessons.Remove(lesson);
                    }
                    else if (command == "Swap")
                    {
                        string firstLesson = lesson;
                        string secondLesson = tokens[2];

                        int firstIndex = lessons.IndexOf(firstLesson);
                        int secondIndex = lessons.IndexOf(secondLesson);

                        if (firstIndex == -1 || secondIndex == -1)
                        {
                            continue;
                        }
                        else
                        {
                            lessons[firstIndex] = secondLesson;
                            lessons[secondIndex] = firstLesson;

                            if (lessons.Contains($"{firstLesson}-Exercise"))
                            {
                                string lessonfirstExercise = lessons[firstIndex + 1];
                                lessons.RemoveAt(firstIndex + 1);
                                lessons.Insert(secondIndex + 1, lessonfirstExercise);
                            }
                            if (lessons.Contains($"{secondLesson}-Exercise"))
                            {
                                string lessonsecondExercise = lessons[secondIndex + 1];
                                lessons.RemoveAt(secondIndex + 1);
                                lessons.Insert(firstIndex + 1, lessonsecondExercise);
                            }
                        }

                    }
                    else if (command == "Exercise")
                    {
                        string exercise = $"{lesson}-Exercise";

                        if (lessons.Contains(lesson) == false)
                        {
                            lessons.Add(lesson);
                            lessons.Add(exercise);
                        }
                        if (lessons.Contains(lesson) && lessons.Contains(exercise) == false)
                        {
                            int index = lessons.IndexOf(lesson);
                            lessons.Insert(index + 1, exercise);
                        }
                    }
                }
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                string lesson = lessons[i];
                Console.WriteLine($"{i + 1}.{lesson}");
            }
        }
    }
}


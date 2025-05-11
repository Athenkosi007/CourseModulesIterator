using System;
using System.Collections.Generic;

namespace CourseModuleIteratorPattern
{
    class Program
    {
        static void Main()
        {
            var course = new CourseModuleCollection();

            course.AddModule(new CourseModule("Introduction", "Video", true));
            course.AddModule(new CourseModule("Lesson 1 - Basics", "Reading", true));
            course.AddModule(new CourseModule("Quiz 1", "Quiz", false));
            course.AddModule(new CourseModule("Lesson 2 - Advanced", "Video", false));
            course.AddModule(new CourseModule("Final Exam", "Quiz", false));

            Console.WriteLine("All Modules:");
            var allModules = course.CreateIterator();
            while (allModules.HasNext())
                Console.WriteLine($"- {allModules.Next()}");

            Console.WriteLine("\nUnlocked Modules Only:");
            var unlockedOnly = course.CreateUnlockedIterator();
            while (unlockedOnly.HasNext())
                Console.WriteLine($"- {unlockedOnly.Next()}");

            Console.ReadKey();
        }
    }

    class CourseModule
    {
        public string Title { get; }
        public string Type { get; } // e.g., Video, Reading, Quiz
        public bool IsUnlocked { get; }

        public CourseModule(string title, string type, bool isUnlocked)
        {
            Title = title;
            Type = type;
            IsUnlocked = isUnlocked;
        }

        public override string ToString()
            => $"{Title} [{Type}] {(IsUnlocked ? "✅" : "🔒")}";
    }

    interface ICourseModuleIterator
    {
        bool HasNext();
        CourseModule Next();
    }

    class CourseModuleCollection
    {
        private List<CourseModule> _modules = new();

        public void AddModule(CourseModule module) => _modules.Add(module);

        public ICourseModuleIterator CreateIterator()
            => new AllModuleIterator(_modules);

        public ICourseModuleIterator CreateUnlockedIterator()
            => new UnlockedModuleIterator(_modules);

        private class AllModuleIterator : ICourseModuleIterator
        {
            private List<CourseModule> _modules;
            private int _index = 0;

            public AllModuleIterator(List<CourseModule> modules)
            {
                _modules = modules;
            }

            public bool HasNext() => _index < _modules.Count;

            public CourseModule Next() => _modules[_index++];
        }

        private class UnlockedModuleIterator : ICourseModuleIterator
        {
            private List<CourseModule> _modules;
            private int _index = 0;

            public UnlockedModuleIterator(List<CourseModule> modules)
            {
                _modules = modules;
            }

            public bool HasNext()
            {
                while (_index < _modules.Count)
                {
                    if (_modules[_index].IsUnlocked)
                        return true;
                    _index++;
                }
                return false;
            }

            public CourseModule Next() => _modules[_index++];
        }
    }
}

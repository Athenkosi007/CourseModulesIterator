# 🎓 Course Modules Iterator Pattern (C# Console App)

This project demonstrates the **Iterator Design Pattern** in C# using a real-world example of **course modules** in an educational or e-learning system.

---

## 🧠 What Is the Iterator Pattern?

The **Iterator Pattern** provides a way to **access elements of a collection sequentially without exposing its underlying representation**. It promotes loose coupling and cleaner abstraction when working with complex data structures.

---

## 📘 Scenario: Course Modules in a Learning System

Imagine an online learning platform that contains various types of modules for each course:  
- 📺 Video Lessons  
- 📄 Reading Materials  
- 📝 Quizzes  

Some modules may be **locked**, and users may only progress through **unlocked modules**.

---

## 🧱 Implementation

This console app demonstrates:
- A `CourseModule` class representing a module.
- A `CourseModuleCollection` that stores a list of modules.
- Two iterators:
  - `AllModuleIterator`: Traverses all modules.
  - `UnlockedModuleIterator`: Traverses only unlocked modules.

---

## 🧪 Output Example


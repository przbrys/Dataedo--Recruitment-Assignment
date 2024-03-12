# Dataedo--Recruitment-Assignment
A friend asked you to do a code review. What will you notice when viewing the following code?
Prepare a list of comments in text form and propose the correct code. Clone the following
repository, make corrections and send a link to the repository with the corrected code.

My list of comments:
1. In the Main method, there is a typo: "dataa.csv" instead of "data.csv."
2. If you use properties, keep the pattern consistent among them; write them the same way.
3. Are NumberOfChildren, Schema, and ParentName properties or fields? If they are fields, you forgot { get; set; }. Otherwise, make them private, use camelCase, and create full properties.
4. "Name" in ImportedObject is unnecessary. You already have Name in ImportedObjectBaseClass, which you inherit.
5. Why does the ImportAndPrintData method in the DataReader class have "bool printData = true" as a parameter? It is never used in the implementation; it is always true. When you call this method and pass false as an argument, it won't work either.
6. The code does not take into account the case that the line from the data.csv file may be empty.
7. The code does not take into account the case that the data may not be valid. Your value [i] may not exist. In that case, value = 6 will be equal to "not transferred."
8. Programmers count from 0! Use "<" or "<=" in: "for (int i = 0; i <= importedLines.Count; i++)" or you will get a System.ArgumentOutOfRangeException.
9. If you initialized the list like this: ImportedObjects = new List<ImportedObject>() { new ImportedObject() }; in the first iteration of foreach, you will try to operate on null and get a System.NullReferenceException. I do not know why you keep an empty Imported object. Initialize in construdtor
10. You may use +=1 rather than importedObject.NumberOfChildren = 1 + importedObject.NumberOfChildren.
11. You can use "&&" in if statements.
12. Why did you use Console.ReadLine at the end of ImportAndPrintData?
13. Your "assign number of children" can be optimized. Your computational complexity is ~~ O(n^2). In case of using dictionaries, you can achieve ~~ O(2n).
14. Your code causes misunderstanding. Your class is named DataReader, but here you read, process, sort, and change the format of your data. A better way is to create classes as: DataProcessor, DataReader, DataPrinter. It would be more intuitive. Remember about the Single Responsibility Principle (SOLID).
15. Split code. Don't write whole program into one method.
16. Your PrintData has a computational complexity of O(n^3)!!!
17. Use parametric constructors for creating and initializing objects.
18. Your print does not recognize nullable and non-nullable.
19. When you compare strings, the size of letters matters, e.g., 'A' and 'a' in ASCII have different numerations.
20. In data.csv, there exist columns that have no table declarations in the input file. You lose data.
21. Your way of doing this task is not optimal. Think about how to solve your task. Keeping everything in one object cause a lot of trouble.

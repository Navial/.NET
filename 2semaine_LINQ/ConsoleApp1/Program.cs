using LINQDataContext;

DataContext dc = new DataContext();

Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{

    Console.WriteLine("---DEMO---");
    Console.WriteLine(jdepp.Last_Name + jdepp.First_Name);
}


Console.WriteLine("\n---EX2.2---");
var allStudents = (from Student student in dc.Students
                    select new {
                            Last_Name= student.Last_Name, 
                            First_Name = student.First_Name, 
                            Id = student.Student_ID,
                            Birth_Date = student.BirthDate
                    });

foreach(var s in allStudents)
{
    Console.WriteLine("(" + s.Id + ") " + s.Last_Name + " " + s.First_Name + " : " + s.Birth_Date);
}

Console.WriteLine("\n---EX3.1---");
var studentsBefore1955 = (from Student student in dc.Students
                            where student.BirthDate.Year < 1955
                            select new {
                                Last_Name = student.Last_Name,
                                First_Name = student.First_Name,
                                Year_Result = student.Year_Result
                            });

foreach (var s in studentsBefore1955)
{
    string status = s.Year_Result >= 12 ? "OK" : "KO";
    Console.WriteLine(s.Last_Name + " " + s.First_Name + " | year result : " + s.Year_Result + " : " + status);
}

Console.WriteLine("\n---EX3.4---");
var studentsOrderByNoteAbove3 = (from Student student in dc.Students
                          where student.Year_Result >= 3
                          orderby student.Year_Result descending
                          select new
                          {
                              Last_Name = student.Last_Name,
                              First_Name = student.First_Name,
                              Year_Result = student.Year_Result
                          });

foreach (var s in studentsOrderByNoteAbove3)
{
    Console.WriteLine(s.Last_Name + " " + s.First_Name + " | year result : " + s.Year_Result );
}

Console.WriteLine("\n---EX3.5---");
var studentsFromSection1110 = (from Student student in dc.Students
                                 where student.Section_ID == 1110
                                 orderby student.Last_Name descending
                                 select new
                                 {
                                     Last_Name = student.Last_Name,
                                     First_Name = student.First_Name,
                                     Year_Result = student.Year_Result
                                 });

foreach (var s in studentsFromSection1110)
{
    Console.WriteLine(s.Last_Name + " " + s.First_Name + " | year result : " + s.Year_Result);
}

Console.WriteLine("\n---EX4.1---");
var averageYearResult = (from Student student in dc.Students
                               select student.Year_Result
                               );

Console.WriteLine("Average : " + averageYearResult.Average());

Console.WriteLine("\n---EX4.5---");
var studentsCount = (from Student student in dc.Students
                               select new
                               {
                                   Id = student.Student_ID
                               });

// IEnumerable<IGrouping<int, int>> maxNoteBySection 

Console.WriteLine("Number of students : " + studentsCount.Count());

Console.WriteLine("\n---EX5.1---");

var maxResultsPerSection = from student in dc.Students
                           group student by student.Section_ID into studentGroup
                           select new
                           {
                               Section = studentGroup.Key,
                               Max_Result = (from s in studentGroup
                                             select s.Year_Result).Max()
                           };

foreach (var item in maxResultsPerSection)
{
    Console.WriteLine("Section: " + item.Section + " | Max Year Result: " + item.Max_Result);
}

Console.WriteLine("\n---EX5.3---");

var resultatMoyenParMois = (from student in dc.Students
                            where student.BirthDate.Year >= 1970 &&
                            student.BirthDate.Year <= 1985
                            group student by student.BirthDate.Month into studentGroup
                            select new
                            {
                                BirthMonth = studentGroup.Key,
                                AVG_Result = (from s in studentGroup
                                              select s.Year_Result).Average()
                            }
                            );

foreach (var item in resultatMoyenParMois)
{
    Console.WriteLine("Birth month: " + item.BirthMonth + " | AVG Year Result: " + item.AVG_Result);
}

Console.WriteLine("\n---EX5.5---");

var courseSectionProfessor = from course in dc.Courses
                             join professor in dc.Professors on course.Professor_ID equals professor.Professor_ID
                             join section in dc.Sections on professor.Section_ID equals section.Section_ID
                             select new
                             {
                                 Course_name = course.Course_Name,
                                 Section_name = section.Section_Name,
                                 Professor = professor.Professor_Surname
                             };
foreach (var item in courseSectionProfessor)
{
    Console.WriteLine($"Course Name: {item.Course_name}, Section Name: {item.Section_name}, Professor Name: {item.Professor}");
}


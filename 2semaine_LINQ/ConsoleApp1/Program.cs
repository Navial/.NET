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
var bestResult = (from Student student in dc.Students
                  group by student.Section_ID
                         select student.Year_Result
                               );

int max = bestResult.Max();
Console.WriteLine("Max : " + max);

Console.WriteLine("\n---EX5.3---");

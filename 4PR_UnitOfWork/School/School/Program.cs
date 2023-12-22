using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using School.Models;
using School.Repository;
using School.UnitOfWork;
using Section = School.Models.Section;

/*
BaseRepositorySQL<Section> rSec = new BaseRepositorySQL<Section>(sc);
BaseRepositorySQL<Student> rStu = new BaseRepositorySQL<Student>(sc);
*/
SchoolContext sc = new SchoolContext();

StudentRepositorySQLServer sRepo = new StudentRepositorySQLServer(sc);

IUnitOfWork unitOfWork = new UnitOfWorkSQLServer(sc);

IRepository<Section> rSec =  unitOfWork.SectionsRepository;
IStudentRepository rStu =  unitOfWork.StudentsRepository;


var nSecInfo = new Section
{
    Name = "secInfo"
};

var nSecDiet = new Section
{
    Name = "secDiet"
};

rSec.Save(nSecInfo, s => s.Name.Equals(nSecInfo.Name));
rSec.Save(nSecDiet, s => s.Name.Equals(nSecDiet.Name));
/*
addSection(nSecInfo);
addSection(nSecDiet);
*/
var secInfo = rSec.SearchFor(s => s.Name.Equals("secInfo")).FirstOrDefault();
var secDiet = rSec.SearchFor(s => s.Name.Equals("secDiet")).FirstOrDefault();

var studinfo1 = new Student
{
    Name = "Denis",
    Firstname = "Victor",
    Section = secInfo,
    YearResult = 100
};
var studinfo2 = new Student
{
    Name = "Mondovits",
    Firstname = "Béné",
    Section = secInfo,
    YearResult = 110
};
var studdiet = new Student
{
    Name = "Denis",
    Firstname = "Alexis",
    Section = secDiet,
    YearResult = 120
};

rStu.Save(studinfo1, s => s.Name.Equals(studinfo1.Name) && s.Firstname.Equals(studinfo1.Firstname));
rStu.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
rStu.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));


var studsBySec = sRepo.GetStudentBySectionOrderByYearResult();

foreach (Student s in studsBySec)
{
    Console.WriteLine("SECTION : " + s.Section.Name + " STUD : " + s.Name + " YEAR_RESULT : " + s.YearResult);
}

/*
addStudent(studinfo1);
addStudent(studinfo2);
addStudent(studdiet);

void addSection(Section sec)
{
    if (rSec.SearchFor(s => s.Name.Equals(sec.Name)).IsNullOrEmpty())
    {
        Console.WriteLine("Add " + sec.Name);
        rSec.Insert(sec);
    }
}

void addStudent(Student stud)
{
    if (rStu.SearchFor(s => s.Name.Equals(stud.Name) && s.Firstname.Equals(stud.Firstname)).IsNullOrEmpty())
    {
        Console.WriteLine("Add " + stud.Name);
        rStu.Insert(stud);
    }
}
*/

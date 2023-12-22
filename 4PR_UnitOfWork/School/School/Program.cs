using Microsoft.IdentityModel.Tokens;
using Repository;
using School.Models;
using System.Collections;
using static System.Collections.Specialized.BitVector32;
using Section = School.Models.Section;

SchoolContext sc = new SchoolContext();
BaseRepositorySQL<Section> rSec = new BaseRepositorySQL<Section>(sc);
BaseRepositorySQL<Student> rStu = new BaseRepositorySQL<Student>(sc);




var nSecInfo = new Section
{
    Name = "secInfo"
};

var nSecDiet = new Section
{
    Name = "secDiet"
};

addSection(nSecInfo);
addSection(nSecDiet);

var secInfo = rSec.SearchFor(s => s.Name.Equals("secInfo")).First();
var secDiet = rSec.SearchFor(s => s.Name.Equals("secDiet")).First();

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
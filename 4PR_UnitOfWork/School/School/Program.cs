using Microsoft.IdentityModel.Tokens;
using Repository;
using School.Models;
using System.Collections;
using static System.Collections.Specialized.BitVector32;
using Section = School.Models.Section;

SchoolContext sc = new SchoolContext();
BaseRepositorySQL<Section> rSec = new BaseRepositorySQL<Section>(sc);
BaseRepositorySQL<Student> rStu = new BaseRepositorySQL<Student>(sc);




var secInfo = new Section
{
    Name = "secInfo"
};

var secDiet = new Section
{
    Name = "secDiet"
};

if(rSec.SearchFor(s => s.Name.Equals(secDiet.Name)).IsNullOrEmpty())
{
    rSec.Insert(secDiet);

}
if (rSec.SearchFor(s => s.Name.Equals(secInfo.Name)).IsNullOrEmpty())
{
    rSec.Insert(secDiet);
}

var sections = rSec.GetAll();

foreach (var sec in sections)
{
    Console.WriteLine(sec.Name);
}

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

rStu.Insert(studinfo1);
if (rStu.SearchFor(s => s.Name.Equals(studinfo1.Name) && s.Firstname.Equals(studinfo1.Firstname)).IsNullOrEmpty())
{
    rStu.Insert(studinfo1);
}
if (rStu.SearchFor(s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname)).IsNullOrEmpty())
{
    rStu.Insert(studinfo2);
}
if (rStu.SearchFor(s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname)).IsNullOrEmpty())
{
    rStu.Insert(studdiet);
}
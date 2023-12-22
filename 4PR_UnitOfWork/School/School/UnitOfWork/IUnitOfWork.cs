using School.Models;
using School.Repository;

namespace School.UnitOfWork
{
    interface IUnitOfWork
    {
        IRepository<Section> SectionsRepository { get; }

        IStudentRepository StudentsRepository { get; }
    }
}

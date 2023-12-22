using School.Repository;
using SchoolProject.Repository;
using School.Models;

namespace School.UnitOfWork
{
    class UnitOfWorkMemory : IUnitOfWork
    {
        private SectionRepositoryMemory _sectionsRepository;

        private StudentRepositoryMemory _studentsRepository;

        public UnitOfWorkMemory()
        {
            this._sectionsRepository = new SectionRepositoryMemory();
            this._studentsRepository = new StudentRepositoryMemory();
        }

        public IRepository<Section> SectionsRepository
        {
            get { return this._sectionsRepository; }
        }

        public IStudentRepository StudentsRepository
        {
            get { return this._studentsRepository; }
        }
    }
}

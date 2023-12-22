using Repository;
using School.Models;
using School.Repository;

namespace School.UnitOfWork
{
    class UnitOfWorkSQLServer : IUnitOfWork
    {
        private readonly SchoolContext _context;

        private StudentRepositorySQLServer _studentRepository;

        private BaseRepositorySQL<Section> _sectionsRepository;


        public UnitOfWorkSQLServer(SchoolContext context)
        {
            this._context = context;
            this._studentRepository = new StudentRepositorySQLServer(context);
            this._sectionsRepository = new BaseRepositorySQL<Section>(context);

        }

        public IStudentRepository StudentsRepository
        {
            get { return this._studentRepository; }
        }

        public IRepository<Section> SectionsRepository
        {
            get { return this._sectionsRepository; }
        }
    }
}


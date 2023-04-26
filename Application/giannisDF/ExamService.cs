using Microsoft.Extensions.DependencyInjection;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.giannisDF
{
    public class ExamService
    {

        public IExamRepository examRepository;
        private readonly IServiceProvider _serviceProvider;

        

        public ExamService(IServiceProvider iserviceProvider )
        {
            _serviceProvider = iserviceProvider;
        }

        public void ApplyImplementation(ExamRepositoryImplementations implementation)
        {
            var examRepos = _serviceProvider.GetServices<IExamRepository>();
            foreach (var repo in examRepos.ToList())
            {
                if (repo.Implementation == implementation)
                {
                    examRepository = repo;
                }
            }
        }
    }

    

    
}

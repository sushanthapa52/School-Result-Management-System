using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSServices.Services
{
    public class UserService : Service<User, int>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;   
        }

       

        public async Task<User> SignInValidation(string? email, string? password)
        {
          var user= await _repository.FindBy(x=>x.UserEmail == email);
            
            if (user != null)
            {
                var pass = user.FirstOrDefault(x => x.UserPassword == password);
                if (pass != null)
                

            }
        }

        public Task<IEnumerable<User>> ValidatePassword(User user)
        {
            throw new NotImplementedException();
        }
    }
}

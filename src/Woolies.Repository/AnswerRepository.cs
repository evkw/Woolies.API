using Woolies.Abstractions.Repositories;
using Woolies.Models;

namespace Woolies.repository
{
    public class AnswerRepository : IAnswerRepository
    {
        public User GetUserAnswer()
        {
            return new User("Evan Wallance", "a4bd6f4e-aaba-4b32-8a20-98c247590e3b");
        }
    }
}

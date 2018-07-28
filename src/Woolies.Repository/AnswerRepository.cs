using Woolies.Abstractions.Repositories;
using Woolies.Models;

namespace Woolies.repository
{
    public class AnswerRepository : IAnswerRepository
    {
        public User GetUserAnswer()
        {
            return new User("test", "1234-455662-22233333-3333");
        }
    }
}

using woolies.abstractions.Repositories;
using woolies.models;

namespace woolies.repository
{
    public class AnswerRepository : IAnswerRepository
    {
        public User GetUserAnswer()
        {
            return new User("test", "1234-455662-22233333-3333");
        }
    }
}

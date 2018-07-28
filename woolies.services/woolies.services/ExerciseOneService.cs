using woolies.abstractions.Repositories;
using woolies.abstractions.Services;
using woolies.models;

namespace woolies.services
{
    public class ExerciseOneService: IExerciseOneService
    {
        private readonly IAnswerRepository answerRepo;

        public ExerciseOneService(IAnswerRepository answerRepo)
        {
            this.answerRepo = answerRepo;
        }

        public User HandleRequest()
        {
            return this.answerRepo.GetUserAnswer();
        }
    }
}

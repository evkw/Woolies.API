using Woolies.Abstractions.Repositories;
using Woolies.Abstractions.Services;
using Woolies.Models;

namespace Woolies.Services
{
    public class ExerciseOneService: IExerciseOneService
    {
        private readonly IAnswerRepository _answerRepo;

        public ExerciseOneService(IAnswerRepository answerRepo)
        {
            this._answerRepo = answerRepo;
        }

        public User HandleRequest()
        {
            return this._answerRepo.GetUserAnswer();
        }
    }
}

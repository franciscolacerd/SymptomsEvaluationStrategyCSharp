using Evaluation.Entities;

namespace Evaluation.Contracts
{
    public interface IEvaluationSymptomsStrategy
    {
        Entities.Evaluation EvaluateSymptoms(Pacient pacient);
    }
}
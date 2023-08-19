using Evaluation.Contracts;

namespace Evaluation.Entities
{
    public class Doctor
    {
        private IEvaluationSymptomsStrategy _strategy;

        public void DefineStrategy(IEvaluationSymptomsStrategy strategy)
        {
            this._strategy = strategy;
        }

        public Entities.Evaluation EvalutateSymptoms(Pacient pacient)
        {
            return this._strategy.EvaluateSymptoms(pacient);
        }
    }
}
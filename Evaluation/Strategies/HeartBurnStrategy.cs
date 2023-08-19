using Evaluation.Contracts;
using Evaluation.Entities;

namespace Evaluation.Strategies
{
    public class HeartBurnStrategy : IEvaluationSymptomsStrategy
    {
        public Entities.Evaluation EvaluateSymptoms(Pacient pacient)
        {
            if (pacient.Symptoms.Count == 1 &&
                pacient.Symptoms.Contains(Symptoms.ChestPain))
            {
                return new Entities.Evaluation { IsHeartBurn = true, Message = Illness.HearthBurn };
            }
            else
            {
                return new Entities.Evaluation { Message = Illness.NotHearthBurn };
            }
        }
    }
}
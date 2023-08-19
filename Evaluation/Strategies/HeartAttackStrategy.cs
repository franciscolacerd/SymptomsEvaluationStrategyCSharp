using Evaluation.Contracts;
using Evaluation.Entities;

namespace Evaluation.Strategies
{
    public class HeartAttackStrategy : IEvaluationSymptomsStrategy
    {
        public Entities.Evaluation EvaluateSymptoms(Pacient pacient)
        {
            if (pacient.Symptoms.Contains(Symptoms.ChestPain) &&
                pacient.Symptoms.Contains(Symptoms.NumbnessInArm))
            {
                return new Entities.Evaluation { IsHeartAttack = true, Message = Illness.HearthAttack };
            }
            else
            {
                return new Entities.Evaluation { Message = Illness.NotHearthAttack };
            }
        }
    }
}
using Evaluation.Entities;
using Evaluation.Strategies;
using FluentAssertions;

namespace UnitTests
{
    public class EvaluationUnitTests
    {
        private Pacient _pacient;

        [SetUp]
        public void Setup()
        {
            this._pacient = new Pacient("francisco lacerda", 45);
        }

        [Test]
        public void Should_ConfirmHeartBurn_ReturnHeartBurn()
        {
            // Arrange
            var symptoms = new List<string>
            {
                Symptoms.ChestPain
            };

            // Act
            this._pacient.AddSymptoms(symptoms);

            var doctor = new Doctor();

            doctor.DefineStrategy(new HeartBurnStrategy());

            var evaluation = doctor.EvaluateSymptoms(this._pacient);

            // Assert
            evaluation.IsHeartBurn.Should().BeTrue();

            evaluation.Message.Should().Be(Illness.HearthBurn);
        }

        [Test]
        public void Should_ConfirmHeartBurn_ReturnNotHeartBurn()
        {
            // Arrange
            var symptoms = new List<string>
            {
                Symptoms.NumbnessInArm
            };

            // Act
            this._pacient.AddSymptoms(symptoms);

            var doctor = new Doctor();

            doctor.DefineStrategy(new HeartBurnStrategy());

            var evaluation = doctor.EvaluateSymptoms(this._pacient);

            // Assert
            evaluation.IsHeartBurn.Should().BeFalse();

            evaluation.Message.Should().Be(Illness.NotHearthBurn);
        }

        [Test]
        public void Should_ConfirmHeartAttack_ReturnHeartAttack()
        {
            // Arrange
            var symptoms = new List<string>
            {
                Symptoms.ChestPain,
                Symptoms.NumbnessInArm
            };

            // Act
            this._pacient.AddSymptoms(symptoms);

            var doctor = new Doctor();

            doctor.DefineStrategy(new HeartAttackStrategy());

            var evaluation = doctor.EvaluateSymptoms(this._pacient);

            // Assert
            evaluation.IsHeartAttack.Should().BeTrue();

            evaluation.Message.Should().Be(Illness.HearthAttack);
        }

        [Test]
        public void Should_ConfirmHeartAttack_ReturnNotHeartAttack()
        {
            // Arrange
            var symptoms = new List<string>
            {
                Symptoms.ChestPain
            };

            // Act
            this._pacient.AddSymptoms(symptoms);

            var doctor = new Doctor();

            doctor.DefineStrategy(new HeartAttackStrategy());

            var evaluation = doctor.EvaluateSymptoms(this._pacient);

            // Assert
            evaluation.IsHeartAttack.Should().BeFalse();

            evaluation.Message.Should().Be(Illness.NotHearthAttack);
        }

        [Test]
        public void Should_TryConfirmHeartBurnAndThenTryConfirmHeartAttack_ReturnHeartAttack()
        {
            // Arrange
            var symptoms = new List<string>
            {
                Symptoms.ChestPain,
                Symptoms.NumbnessInArm
            };

            this._pacient.AddSymptoms(symptoms);

            var doctor = new Doctor();

            // Act
            /*HeartBurn Strategy*/

            doctor.DefineStrategy(new HeartBurnStrategy());

            var evaluation = doctor.EvaluateSymptoms(this._pacient);

            // Assert
            evaluation.IsHeartBurn.Should().BeFalse();

            evaluation.Message.Should().Be(Illness.NotHearthBurn);

            // Act
            /*HeartAttack Strategy*/

            doctor.DefineStrategy(new HeartAttackStrategy());

            evaluation = doctor.EvaluateSymptoms(this._pacient);

            // Assert
            evaluation.IsHeartAttack.Should().BeTrue();

            evaluation.Message.Should().Be(Illness.HearthAttack);
        }
    }
}
# Symptoms Evaluation - Strategy Pattern - C#
Strategy Pattern C# implementation of an Hospital Symptoms Evaluation System

In this example, multiple strategies are defined for patient symptom evaluation by a Doctor. The HeartBurnStrategy defines a set of criteria and logic to assess symptoms associated with heartburn or indigestion. On the other hand, the HeartAttackStrategy defines a distinct set of criteria and logic to evaluate symptoms that could indicate a potential heart attack. By employing a range of strategies, the Doctor can accurately assess various health conditions based on the presented symptoms and provide appropriate medical care or recommendations.

------

In computer programming, the strategy pattern (also known as the policy pattern) is a behavioral software design pattern that enables selecting an algorithm at runtime. Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use.

![Strategy_pattern_UML](https://upload.wikimedia.org/wikipedia/commons/4/45/W3sDesign_Strategy_Design_Pattern_UML.jpg)

https://en.wikipedia.org/wiki/Strategy_pattern

------

## C# Implementation

### 1. Declare Hospital entities 

#### Pacient
```c#
     public class Pacient
   {
       public string Name { get; private set; }

       public int Age { get; private set; }

       public List<string> Symptoms { get; private set; }

       public Pacient(string name, int age)
       {
           Name = name;

           Age = age;
       }

       public void AddSymptoms(List<string> symptoms)
       {
           this.Symptoms = symptoms;
       }
   }
```

#### Doctor
```c#
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
```
...Evaluation, Illness, Symptoms.

### 2. Declare the handler interface
```c#
    public interface IEvaluationSymptomsStrategy
    {
        Entities.Evaluation EvaluateSymptoms(Pacient pacient);
    }
```

### 3. Declare concrete strategies subclasses

#### HeartBurnStrategy
```c#
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
```

#### HeartAttackStrategy
```c#
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
```

### 4. Unit test it (NUnit)

```c#
  public class EvaluationUnitTests
  {
      private Pacient _pacient;

      [SetUp]
      public void Setup()
      {
          this._pacient = new Pacient("francisco lacerda", 45);
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

          var evaluation = doctor.EvalutateSymptoms(this._pacient);

          // Assert
          evaluation.IsHeartBurn.Should().BeFalse();

          evaluation.Message.Should().Be(Illness.NotHearthBurn);

          // Act
          /*HeartAttack Strategy*/

          doctor.DefineStrategy(new HeartAttackStrategy());

          evaluation = doctor.EvalutateSymptoms(this._pacient);

          // Assert
          evaluation.IsHeartAttack.Should().BeTrue();

          evaluation.Message.Should().Be(Illness.HearthAttack);
      }
  }
```

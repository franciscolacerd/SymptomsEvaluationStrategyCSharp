namespace Evaluation.Entities
{
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
}
using Bogus;
using Newtonsoft;
using Domain;
using static Bogus.DataSets.Name;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace TestJsonCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Randomizer.Seed = new Random(8675309);

            //var ScenarioTypes = new List<ScenarioType>();

            //foreach (var value in Enum.GetValues(typeof(ScenarioType)))
            //{
            //    ScenarioTypes.Add(new ScenarioType { ScenarioType = (ScenarioType)value });
            //}

            var numFaker = new Faker();

            // case multiple option 1 correct per question
            var localId = 1;
            //var examFaker = new Faker<Exam>()
            //    .RuleFor(x => x.Id, f => localId++)
            //    .RuleFor(x => x.MarkingState, f => MarkingState.UnMarked)
            //    .RuleFor(x => x.MaximumScore, f => 0)
            //    .RuleFor(x => x.OverallExamScore, f => null);
            //.RuleFor(x => x.Sections, f => null);



            //var optionIds = 1;
            var optionFaker = new Faker<Option>()
                .RuleFor(x => x.MarkValue, f => 1)
                .RuleFor(x => x.Text, f => f.Random.Words(4));
            //.RuleFor(x=> x.IsCorrect, f=> f.Random.Bool())
            //.RuleFor(x=> x.Selected, f=> f.Random.Bool())


            var questionFaker = new Faker<Question>()
                .RuleFor(x => x.Body, f => $"{f.Random.Words(15)} ???")
                .RuleFor(x => x.QuestionType, f => QuestionType.MCQOneCorrect)
                //.RuleFor(x=>x.ScenarioType, f=> f.ScenarioType[Random.Number(1,3)])
                .RuleFor(x => x.ScenarioType, f => f.PickRandom<ScenarioType>())
                .RuleFor(x => x.MaximumMarks, f => f.Random.Number(1, 5))
                .RuleFor(x => x.AwardedMarks, f => null)
                .RuleFor(x => x.OptionsAvailable, f =>
                    {
                        var options = optionFaker.Generate(4);
                        options[1].IsCorrect = true;
                        options[numFaker.Random.Number(0, 3)].Selected = true;

                        return options;
                    });

            var sectionFaker = new Faker<Section>()
                .RuleFor(x => x.Description, f => f.Random.Words(10))
                .RuleFor(x => x.Weight, f => (float)0.2)
                .RuleFor(x => x.Questions, f =>
                {
                    var questions = questionFaker.Generate(5);
                    return questions;
                });


            var examFaker = new Faker<Exam>()
                .RuleFor(x => x.MarkingState, f => MarkingState.UnMarked)
                .RuleFor(x => x.OverallExamScore, f => null)
                .RuleFor(x => x.Sections, f =>
                {
                    var sections = sectionFaker.Generate(5);
                    return sections;
                });

            var testExam = examFaker.Generate(1);


            // Calculate Exam's maximun score

            foreach (Exam exam in testExam) 
            {
                int maxScore = 0;
                foreach(Section section in exam.Sections)
                {
                    foreach(Question question in section.Questions)
                    {
                        maxScore += question.MaximumMarks;
                    }
                }
                exam.MaximumScore = maxScore;
            }


            var json = JsonConvert.SerializeObject(testExam, Formatting.Indented);

            Console.WriteLine(json);
            File.WriteAllText("MCQ1CorrectPerQ.json", json);
            //Console.ReadLine();

        }

        public void Optionmaker()
        {

        }
    }
}
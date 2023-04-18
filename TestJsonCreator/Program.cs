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
            // Seed the randomizer with a fixed value for consistent results
            Randomizer.Seed = new Random(8675309);

            //var ScenarioTypes = new List<ScenarioType>();

            //foreach (var value in Enum.GetValues(typeof(ScenarioType)))
            //{
            //    ScenarioTypes.Add(new ScenarioType { ScenarioType = (ScenarioType)value });
            //}

            // Define a Faker object for generating random data
            var numFaker = new Faker();

            // case multiple option 1 correct per question
            var localId = 1;
            //var examFaker = new Faker<Exam>()
            //    .RuleFor(x => x.Id, f => localId++)
            //    .RuleFor(x => x.MarkingState, f => MarkingState.UnMarked)
            //    .RuleFor(x => x.MaximumScore, f => 0)
            //    .RuleFor(x => x.OverallExamScore, f => null);
            //.RuleFor(x => x.Sections, f => null);



            // var optionIds = 1;
            // Define a Faker object for generating Option objects with random data
            var optionFaker = new Faker<Option>()
                .RuleFor(x => x.MarkValue, f => 1)
                .RuleFor(x => x.Text, f => f.Random.Words(4));
            //.RuleFor(x=> x.IsCorrect, f=> f.Random.Bool())
            //.RuleFor(x=> x.Selected, f=> f.Random.Bool())

            // Define a Faker object for generating Question objects with random data
            var questionFaker = new Faker<Question>()
                .RuleFor(x => x.Body, f => $"{f.Random.Words(15)} ???")
                .RuleFor(x => x.QuestionType, f => QuestionType.MCQOneCorrect)
                //.RuleFor(x=>x.ScenarioType, f=> f.ScenarioType[Random.Number(1,3)])
                .RuleFor(x => x.ScenarioType, f => f.PickRandom<ScenarioType>())
                .RuleFor(x => x.MaximumMarks, f => f.Random.Number(1, 5))
                .RuleFor(x => x.AwardedMarks, f => null)
                .RuleFor(x => x.OptionsAvailable, f =>
                    {
                        // Generate 4 Option objects
                        var options = optionFaker.Generate(4);

                        //options[1].IsCorrect = true;
                        // Set one of the options to be the correct answer
                        options[numFaker.Random.Number(0, 3)].IsCorrect = true;

                        //options[1].Selected = true;
                        // Set one of the options to be selected by default
                        options[numFaker.Random.Number(0, 3)].Selected = true;

                        return options;
                    });

            // Define a Faker object for generating Section objects with random data
            var sectionFaker = new Faker<Section>()
                .RuleFor(x => x.Description, f => f.Random.Words(10))
                .RuleFor(x => x.Weight, f => (float)0.2)
                .RuleFor(x => x.Questions, f =>
                {
                    // Generate 5 Question objects
                    var questions = questionFaker.Generate(5);
                    return questions;
                });

            // Define a Faker object for generating Exam objects with random data
            var examFaker = new Faker<Exam>()
                .RuleFor(x => x.MarkingState, f => MarkingState.UnMarked)
                .RuleFor(x => x.OverallExamScore, f => null)
                .RuleFor(x => x.Sections, f =>
                {
                    // Generate 5 Section objects
                    var sections = sectionFaker.Generate(5);
                    return sections;
                });

            // Generate a single Exam object with the Faker object
            var testExam = examFaker.Generate(1);


            // Calculate the maximum score for the exam
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

            // Convert the exam object to JSON with indentation for readability
            var json = JsonConvert.SerializeObject(testExam, Formatting.Indented);

            Console.WriteLine(json);
            File.WriteAllText("MCQ1CorrectPerQ.json", json);
            //Console.ReadLine();

        }

        // Define a method for creating Option objects
        public void Optionmaker()
        {

        }
    }
}
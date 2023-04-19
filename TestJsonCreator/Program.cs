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

            var numFaker = new Faker();

            // case multiple option 1 correct per question

            // creates options for questions
            var optionFaker = new Faker<Option>()
                .RuleFor(x => x.MarkValue, f => 1)
                .RuleFor(x => x.Text, f => f.Random.Words(4));

            //creates options and adds a selected and correct option
            var questionFaker = new Faker<Question>()
                .RuleFor(x => x.Body, f => $"{f.Random.Words(15)} ???")
                .RuleFor(x => x.QuestionType, f => QuestionType.MCQOneCorrect)
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
            //creates a Section
            var sectionFaker = new Faker<Section>()
                .RuleFor(x => x.Description, f => f.Random.Words(10))
                .RuleFor(x => x.Weight, f => (float)0.2)
                .RuleFor(x => x.Questions, f =>
                {
                    // Generate 5 Question objects
                    var questions = questionFaker.Generate(5);
                    return questions;
                });


            // Creates an umarked exam
            var examFaker = new Faker<Exam>()
                .RuleFor(x => x.MarkingState, f => MarkingState.UnMarked)
                .RuleFor(x => x.OverallExamScore, f => null)
                .RuleFor(x => x.Sections, f =>
                {
                    // Generate 5 Section objects
                    var sections = sectionFaker.Generate(5);
                    return sections;
                });


            var testExam = examFaker.Generate();


            // Calculate Exam's maximun score
            int maxScore = 0;
            foreach (Section section in testExam.Sections)
            {
                foreach (Question question in section.Questions)
                {
                    maxScore += question.MaximumMarks;
                }
            }
            testExam.MaximumScore = maxScore;
          

            //var json = JsonConvert.SerializeObject(testExam, Formatting.Indented);

            Console.WriteLine(json);
            File.WriteAllText("MCQ1CorrectPerQ.json", json);
            //Console.ReadLine();

        }
    }
}
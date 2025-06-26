using DevMindSpeedGame.Models.Entites;
using System.Data;

namespace DevMindSpeedGame
{
    public static class GenerateMathQuestion
    {
        public static MathQuestion GenerateQuestion(int difficulty)
        {
            var operators = new[] { "+", "-", "*", "/" };
            string question;
            Random random = new Random();


            switch (difficulty)
            {
                case 1:
                    var num1d1 = random.Next(1, 10);
                    var num2d1 = random.Next(1, 10);
                    var op1d1 = operators[random.Next(0, operators.Length)];
                    question = $"{num1d1} {op1d1} {num2d1}";

                    var result1 = new DataTable().Compute(question, null);
                    float answer1 = Convert.ToSingle(result1);
                    return new MathQuestion
                    {
                        CurrentQuestion = question,
                        Answer = answer1,
                        Time = DateTime.Now
                    };
                case 2:
                    int num1d2 = random.Next(10, 100);
                    int num2d2 = random.Next(10, 100);
                    int num3d2 = random.Next(10, 100);
                    string op1d2 = operators[random.Next(0, operators.Length)];
                    string op2d2 = operators[random.Next(0, operators.Length)];
                    question = $"{num1d2} {op1d2} {num2d2} {op2d2} {num3d2}";

                    var result2 = new DataTable().Compute(question, null);
                    float answer2 = Convert.ToSingle(result2);
                    return new MathQuestion
                    {
                        CurrentQuestion = question,
                        Answer = answer2,
                        Time = DateTime.Now
                    };
                case 3:
                    int num1d3 = random.Next(100, 1000);
                    int num2d3 = random.Next(100, 1000);
                    int num3d3 = random.Next(100, 1000);
                    int num4d3 = random.Next(100, 1000);
                    string op1d3 = operators[random.Next(0, operators.Length)];
                    string op2d3 = operators[random.Next(0, operators.Length)];
                    string op3d3 = operators[random.Next(0, operators.Length)];
                    question = $"{num1d3} {op1d3} {num2d3} {op2d3} {num3d3} {op3d3} {num4d3}";
                    var result3 = new DataTable().Compute(question, null);
                    float answer3 = Convert.ToSingle(result3);
                    return new MathQuestion
                    {
                        CurrentQuestion = question,
                        Answer = answer3,
                        Time = DateTime.Now
                    };
                case 4:
                    int num1d4 = random.Next(1000, 10000);
                    int num2d4 = random.Next(1000, 10000);
                    int num3d4 = random.Next(1000, 10000);
                    int num4d4 = random.Next(1000, 10000);
                    int num5d4 = random.Next(1000, 10000);
                    string op1d4 = operators[random.Next(0, operators.Length)];
                    string op2d4 = operators[random.Next(0, operators.Length)];
                    string op3d4 = operators[random.Next(0, operators.Length)];
                    string op4d4 = operators[random.Next(0, operators.Length)];
                    question = $"{num1d4} {op1d4} {num2d4} {op2d4} {num3d4} {op3d4} {num4d4} {op4d4} {num5d4}";
                    var result4 = new DataTable().Compute(question, null);
                    float answer4 = Convert.ToSingle(result4);
                    return new MathQuestion
                    {
                        CurrentQuestion = question,
                        Answer = answer4,
                        Time = DateTime.Now
                    };
                default:
                    return new MathQuestion
                    {
                        CurrentQuestion = "Invalid difficulty level",
                        Answer = 0,
                        Time = DateTime.Now
                    };
            }
        }
    }
}

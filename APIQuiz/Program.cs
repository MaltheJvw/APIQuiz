using APIQuiz;

QuizConfigurations configs = new QuizConfigurations();
string getCategory = configs.GetCategory().ToString();
string getLimit = configs.GetLimit().ToString();
string getDifficulty = configs.GetDifficulty().ToString();




ApiHandler handler = new ApiHandler();
List<Format> api = handler.ConvertApi(getCategory, getLimit, getDifficulty);

if (api.Count == 0)
{
    Console.WriteLine("No questions found. Please try again later.");
    return;
}
//foreach
foreach (var question in api)
{
    DisplayQuestion(question);
    string userAnswer = GetUserAnswer(question);

    bool isCorrect = CheckAnswer(question, userAnswer);
    if (isCorrect)
    {
        Console.WriteLine("Correct!");
    }
    else
    {
        Console.WriteLine("Incorrect.");
    }

    Console.WriteLine();
}

static void DisplayQuestion(Format question)
{
    Console.WriteLine(question.question);
    foreach (var answer in question.answers)
    {
        if (!string.IsNullOrEmpty(answer.Value))
        {
            Console.WriteLine($"{answer.Key.Last()}. {answer.Value}");
        }
    }

}


static string GetUserAnswer(Format question)
{
    Console.Write("Your answer: ");
    return Console.ReadLine();
}

static bool CheckAnswer(Format question, string userAnswer)
{
    if (question.correct_answers.TryGetValue($"answer_{userAnswer}_correct", out string isCorrect))
    {
        return isCorrect == "true";
    }
    return false;
}
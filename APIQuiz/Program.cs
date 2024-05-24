using APIQuiz;



QuizConfigurations configs = new QuizConfigurations();
string getCategory = configs.GetCategory().ToString();

string getLimit = configs.GetLimit().ToString();
string getDifficulty = configs.GetDifficulty().ToString();




ApiHandler handler = new ApiHandler();
List<Format> api = handler.ConvertApi(getCategory, getLimit, getDifficulty);


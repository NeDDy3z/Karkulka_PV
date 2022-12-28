public class Question
{
    private string ask;

    private string correctAnswer;
    private string wrongAnswer1;
    private string wrongAnswer2;

    private bool solved;

    public string Ask { get => ask; set => ask = value; }
    public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
    public string WrongAnswer1 { get => wrongAnswer1; set => wrongAnswer1 = value; }
    public string WrongAnswer2 { get => wrongAnswer2; set => wrongAnswer2 = value; }
    public bool Solved { get => solved; set => solved = value; }

    public Question(string ask, string correctAnswer, string wrongAnswer1, string wrongAnswer2, bool solved)
    {
        this.ask = ask;
        this.correctAnswer = correctAnswer;
        this.wrongAnswer1 = wrongAnswer1;
        this.wrongAnswer2 = wrongAnswer2;
        this.solved = solved;
    }

    public override string ToString()
    {
        return "Question: " + ask + "; Answers [Correct,Wrong,Wrong]: [" + correctAnswer + ", " + wrongAnswer1 + ", " + wrongAnswer2 + "]; Solved: " + solved;
    }
}

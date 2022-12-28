using UnityEngine;

public class Executer : MonoBehaviour
{
    public QuestionBuilder questionBuilder;
    public MapBuilder mapBuilder;
    public GameLogic gameLogic;


    void Start()
    {
        questionBuilder.MyStart();

        mapBuilder.MyStart();

        gameLogic.MyStart();
    }

}

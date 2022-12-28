using UnityEngine.Tilemaps;

public class TileInfo
{
    private int x;
    private int y;
    private Tile tileType;

    private Question assignedQuestion;

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public Tile TileType { get => tileType; set => tileType = value; }
    public Question AssignedQuestion { get => assignedQuestion; set => assignedQuestion = value; }

    public TileInfo(int x, int y, Tile tileType, Question assignedQuestion)
    {
        this.x = x;
        this.y = y;
        this.tileType = tileType;
        this.assignedQuestion = assignedQuestion;
    }


    public override string ToString()
    {
        return "Pos: [" + x + "," + y + "] Tile: " + tileType.ToString() + " " + assignedQuestion.ToString();

    }
}

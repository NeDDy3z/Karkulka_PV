using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class MapBuilder : MonoBehaviour
{
    public Tilemap tileMap;
    public Vector3Int position;

    public Tile start;
    public Tile finish;

    public Tile neutral;
    public Tile recharge;
    public Tile randomTeleport;
    public Tile question;

    public QuestionBuilder questionBuilder;

    private Dictionary<int, Tile> tileDictionary = new Dictionary<int, Tile>();
    public List<TileInfo> myTileList = new List<TileInfo>();
    public List<Question> myQuestionList = new List<Question>();

    Random rand = new Random();

    public void MyStart()
    {
        tileDictionary.Add(0, start);
        tileDictionary.Add(1, finish);
        tileDictionary.Add(2, neutral);
        tileDictionary.Add(3, recharge);
        tileDictionary.Add(4, randomTeleport);
        tileDictionary.Add(5, question);

        int counter = 0;
        //Put tiles into position
        for (int i = -3; i <= 3; i++) //X coor
        {
            for (int j = 3; j >= -3; j--) //Y coor
            {
                int rTile = rand.Next(2, 6); //random num for type of tile
                if (counter > 25) counter = 0;

                if (rTile == 5)
                {
                    myTileList.Add(new TileInfo(i, j, tileDictionary[rTile], myQuestionList[counter]));
                    tileMap.SetTile(new Vector3Int(i, j, 0), tileDictionary[rTile]);
                    counter++;
                }
                else
                {
                    myTileList.Add(new TileInfo(i, j, tileDictionary[rTile], null));
                    tileMap.SetTile(new Vector3Int(i, j, 0), tileDictionary[rTile]);
                }
            }
        }

        myTileList[0] = new TileInfo(-3, 3, tileDictionary[0], null); //Start
        tileMap.SetTile(new Vector3Int(-3, 3, 0), start);

        myTileList[48] = new TileInfo(3, -3, tileDictionary[1], null); //Finish
        tileMap.SetTile(new Vector3Int(3, -3, 0), finish);

        Debug.Log("MapBuilder - done.");
    }

    public List<TileInfo> getMyTileMapList()
    {
        return myTileList;
    }

    public int getTileType(int posX, int posY)
    {
        int tempGet = 0;
        foreach (var pair in tileDictionary)
        {
            for (int i = 0; i < myTileList.Count; i++)
            {
                if (pair.Value == myTileList[i].TileType && posX == myTileList[i].X && posY == myTileList[i].Y)
                {
                    if (pair.Value == myTileList[i].TileType) tempGet = pair.Key;
                }
            }
        }
        return tempGet;
    }

    public TileInfo getTileByPos(int posX, int posY)
    {
        TileInfo tItemp = null;

        foreach (var tile in myTileList)
        {
            if (tile.X == posX && tile.Y == posY) tItemp = tile;
        }

        return tItemp;
    }

}

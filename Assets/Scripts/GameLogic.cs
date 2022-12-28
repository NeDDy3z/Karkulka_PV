using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Random = System.Random;

public class GameLogic : MonoBehaviour
{
    public MapBuilder mapBuilder;

    public GameObject player;
    public PlayerController playerController;
    public Transform movingPointgm;
    private Vector3 prevPosition;

    public Image panoImage;
    public TextMeshProUGUI promptText;
    public Button button1;
    public Button button2;
    public Button button3;

    public Image item1;
    public Image item2;
    public Image item3;
    public Image item4;
    public Image item5;

    public List<Image> inventoryList = new List<Image>();
    public Dictionary<string, Image> invDic = new Dictionary<string, Image>();

    Random rand = new Random();

    private int stateint;
    private bool repeate;
    private bool win;
    private bool wolfAppearedOnLastTile;

    public void MyStart()
    {
        playerController = player.gameObject.GetComponent<PlayerController>();
        prevPosition = player.transform.position;

        inventoryList.Add(item1);
        inventoryList.Add(item2);

        invDic.Add("KrabiËka suöenek", item3);
        invDic.Add("M1A2-SEPv4 Abrams", item4);
        invDic.Add("JablÌËko", item5);

        panoImage.gameObject.SetActive(false);
        promptText.gameObject.SetActive(true);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);

        Debug.Log("GameLogic - done.");
    }

    void Update()
    {
        if (ComparePositions())
        {
            PlayerMoved();
            prevPosition = player.transform.position;
        }

        if (repeate) PlayerMoved();

        checkWin();
        if (win)
        {
            playerController.movementEnabled = false;

            panoImage.gameObject.SetActive(false);
            promptText.gameObject.SetActive(true);

            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
        }

        InventoryDisplay();
    }

    bool ComparePositions()
    {
        if (player.transform.position.x == prevPosition.x + 1f ||
            player.transform.position.x == prevPosition.x - 1f ||
            player.transform.position.y == prevPosition.y + 1f ||
            player.transform.position.y == prevPosition.y - 1f)
        {
            return true;
        }
        else return false;
    }

    void PlayerMoved()
    {
        Debug.Log("Player moved.\n" +
                "[" + prevPosition.x + ", " + prevPosition.y + "] -> [" + (int)player.transform.position.x + ", " + (int)player.transform.position.y + "] " +
                "[ " + mapBuilder.getTileByPos((int)prevPosition.x, (int)prevPosition.x).TileType + " ] -> [ " + mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).TileType + " ]" +
                "Last tile wofl? " + wolfAppearedOnLastTile
                );


        stateint = mapBuilder.getTileType((int)player.transform.position.x, (int)player.transform.position.y);
        switch (stateint)
        {
            case 0: //start
                promptText.text = "Move you lazy muppet!";
                break;

            case 1: //finish
                promptText.text = "OMB (” m˘j boûe) tys fakticky vyhr·l.";
                break;

            case 2:
                promptText.text = "VyhlÌdka";
                Wolf();
                break;

            case 3: //recharge
                if (inventoryList.Count <= 1)
                {
                    promptText.text = "Doöel jsi na mÏstsk˝ trh, pokud m·ö z·jem m˘ûeö si nÏco ukradnout. NabÌzÌ se:";

                    button1.GetComponentInChildren<TextMeshProUGUI>().text = "KrabiËka suöenek";
                    button2.GetComponentInChildren<TextMeshProUGUI>().text = "M1A2-SEPv4 Abrams";
                    button3.GetComponentInChildren<TextMeshProUGUI>().text = "JablÌËko";

                }
                else
                {
                    promptText.text = "Doöel jsi na mÏstsk˝ trh, mohl/a bys si nÏco Ëmajznout ale m·ö pln˝ b·gel.";
                    button1.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    button2.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    button3.GetComponentInChildren<TextMeshProUGUI>().text = "";
                }
                break;

            case 4: //randomteleport
                promptText.text = "Spadnul jsi do otev¯enÈho kan·lu a silnÈ odpadnÌ vody tÏ odnesly kamsi do pryË.";

                StartCoroutine(Teleport());
                break;

            case 5: //question
                DisplayQuestion();

                if (!mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.Solved)
                {
                    playerController.movementEnabled = false;

                }
                else
                {
                    playerController.movementEnabled = true;

                    button1.gameObject.SetActive(false);
                    button2.gameObject.SetActive(false);
                    button3.gameObject.SetActive(false);
                }
                break;

            default:
                break;
        }

        //disable/enable -> btn/img/text
        switch (stateint)
        {
            case 0 or 1:
                panoImage.gameObject.SetActive(false);
                promptText.gameObject.SetActive(true);

                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);

                wolfAppearedOnLastTile = false;
                break;

            case 2:
                panoImage.gameObject.SetActive(true);
                promptText.gameObject.SetActive(true);

                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                break;

            case 3:
                panoImage.gameObject.SetActive(false);
                promptText.gameObject.SetActive(true);

                button1.gameObject.SetActive(true);
                button2.gameObject.SetActive(true);
                button3.gameObject.SetActive(true);
                break;

            case 4:
                panoImage.gameObject.SetActive(false);
                promptText.gameObject.SetActive(true);

                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);

                wolfAppearedOnLastTile = false;
                break;

            case 5:
                panoImage.gameObject.SetActive(false);
                promptText.gameObject.SetActive(true);

                if (mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.Solved)
                {
                    button1.gameObject.SetActive(false);
                    button2.gameObject.SetActive(false);
                    button3.gameObject.SetActive(false);
                }
                else
                {
                    button1.gameObject.SetActive(true);
                    button2.gameObject.SetActive(true);
                    button3.gameObject.SetActive(true);
                }

                wolfAppearedOnLastTile = false;
                break;

        }
    }

    void DisplayQuestion()
    {
        promptText.SetText(mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.Ask);
        Question qTemp = mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion;

        int rAnswer = rand.Next(3) + 1;
        switch (rAnswer)
        {
            case 1:
                button1.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.CorrectAnswer;
                button2.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.WrongAnswer1;
                button3.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.WrongAnswer2;
                break;
            case 2:
                button2.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.WrongAnswer1;
                button1.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.WrongAnswer2;
                button3.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.CorrectAnswer;
                break;
            case 3:
                button1.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.WrongAnswer2;
                button2.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.CorrectAnswer;
                button3.GetComponentInChildren<TextMeshProUGUI>().text = qTemp.WrongAnswer1;
                break;
        }

    }

    void OnClickCheckEvent()
    {
        switch (stateint)
        {
            case 3:
                if (wolfAppearedOnLastTile)
                {
                    win = true;
                    promptText.text = "Prohr·l/a jsi.\nZdrûel ses, vlk tÏ p¯edbÏhnul a seûral tvoju b·brli.";
                }
                else
                {
                    foreach (var pair in invDic) if (pair.Key == EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text) inventoryList.Add(pair.Value);
                    StartCoroutine(InvokeRepeate());
                }
                break;

            case 5:
                if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text == mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.CorrectAnswer)
                {
                    mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.Ask = "OdpovÏdÏl/a jsi spr·vnÏ. M˘ûeö pokraËovat.";
                    mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.Solved = true;

                    StartCoroutine(InvokeRepeate());
                }
                else
                {
                    if (inventoryList.Count == 0)
                    {
                        promptText.text = "Prohr·l/a jsi.";
                        win = true;
                    }
                    else
                    {
                        mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.Ask = "äpatnÏ. Na nohu ti spadla traverza. O pomoc jsi poû·dal/ a kolemjdoucÌho v˝mÏnou za jeden ze sv˝ch p¯edmÏt˘.M˘ûeö pokraËovat.";
                        mapBuilder.getTileByPos((int)player.transform.position.x, (int)player.transform.position.y).AssignedQuestion.Solved = true;

                        inventoryList.RemoveAt(inventoryList.Count - 1);

                        StartCoroutine(InvokeRepeate());
                    }
                }
                break;
        }

    }

    void checkWin()
    {
        if ((int)player.transform.position.x == 3 && (int)player.transform.position.y == -3)
        {
            promptText.text = "Vyhr·l/a jsi.";
            win = true;
        }
    }

    void InventoryDisplay()
    {
        item1.gameObject.SetActive(false);
        item2.gameObject.SetActive(false);
        item3.gameObject.SetActive(false);
        item4.gameObject.SetActive(false);
        item5.gameObject.SetActive(false);

        foreach (Image i in inventoryList)
        {
            i.gameObject.SetActive(true);
        }
    }

    void Wolf()
    {
        if (rand.Next(5) == 1)
        {
            promptText.text = "Narazil/a jsi na vlka, ale utekl/a jsi. D·vej si pozor aù se nezdrûÌö.";
            wolfAppearedOnLastTile = true;
        }
        else wolfAppearedOnLastTile = false;
    }

    IEnumerator Teleport()
    {
        Debug.Log("TeleportRequest");

        float rX = rand.Next(-3, 3);
        float rY = rand.Next(-3, 3);

        playerController.movementEnabled = false;
        yield return new WaitForSeconds(1f);

        movingPointgm.transform.position = new Vector3(rX, rY, 0f);
        player.transform.position = new Vector3(rX, rY, 0f);

        yield return new WaitForSeconds(2f);
        playerController.movementEnabled = true;

        InvokeRepeate();
    }

    IEnumerator InvokeRepeate()
    {
        repeate = true;
        yield return new WaitForEndOfFrame();
        repeate = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Grid")]
    public Text[] grid;
    public int playerPressGrid;

    [Header("Player")]
    public string[] player;
    public string playerTurn;

    private List<string> playerPosition;
    [SerializeField] private List<Button> history;
    [SerializeField] private List<Button> redoHistory;
    private bool undoState;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        //SetTurnPlayer();
        undoState = false;
        history = new List<Button>();
        redoHistory = new List<Button>();
        UIManager.instance.undoBTN.onClick.AddListener(() => UndoHistory());
        UIManager.instance.redoBTN.onClick.AddListener(() => RedoHistory());
        var random = Random.Range(0, 2);
        Debug.Log(random);
        SetTurnPlayer(player[random]);
        SetIndicator(player[random]);
    }

    void SetIndicator(string player1)
    {
        UIManager.instance.player1.transform.Find("Text").GetComponent<Text>().text = player1;
        UIManager.instance.player1.GetComponent<Image>().color = UIManager.instance.turnerColor;
        UIManager.instance.player2.GetComponent<Image>().color = UIManager.instance.unturnColor;
        playerPosition = new List<string>();
        playerPosition.Add(player1);
        if (player1 == "X")
        {
            UIManager.instance.player2.transform.Find("Text").GetComponent<Text>().text = "O";
            playerPosition.Add("O");
        }
        else
        {
            UIManager.instance.player2.transform.Find("Text").GetComponent<Text>().text = "X";
            playerPosition.Add("X");
        }

    }
    void SetTurnPlayer(string player)
    {
        playerTurn = player;
    }
    void SwitchTurn()
    {
        if (playerTurn == "X")
        {
            playerTurn = "O";
        }
        else
        {
            playerTurn = "X";
        }

        if (playerPosition[0] == playerTurn)
        {
            //Player1's Turn
            UIManager.instance.player1.GetComponent<Image>().color = UIManager.instance.turnerColor;
            UIManager.instance.player2.GetComponent<Image>().color = UIManager.instance.unturnColor;
        }
        else
        {
            //Player2's Turn
            UIManager.instance.player2.GetComponent<Image>().color = UIManager.instance.turnerColor;
            UIManager.instance.player1.GetComponent<Image>().color = UIManager.instance.unturnColor;
        }
    }

    public void EndTurnEvent(Button buttonPress)
    {
        SetUpHistory(buttonPress);
        if (grid[0].text == playerTurn && grid[1].text == playerTurn && grid[2].text == playerTurn)
        {
            FinishGame();

        }
        else if (grid[3].text == playerTurn && grid[4].text == playerTurn && grid[5].text == playerTurn)
        {
            FinishGame();
        }
        else if (grid[6].text == playerTurn && grid[7].text == playerTurn && grid[8].text == playerTurn)
        {
            FinishGame();
        }
        else if (grid[0].text == playerTurn && grid[3].text == playerTurn && grid[6].text == playerTurn)
        {
            FinishGame();
        }
        else if (grid[1].text == playerTurn && grid[4].text == playerTurn && grid[7].text == playerTurn)
        {
            FinishGame();
        }
        else if (grid[2].text == playerTurn && grid[5].text == playerTurn && grid[8].text == playerTurn)
        {
            FinishGame();
        }
        else if (grid[0].text == playerTurn && grid[4].text == playerTurn && grid[8].text == playerTurn)
        {
            FinishGame();
        }
        else if (grid[2].text == playerTurn && grid[4].text == playerTurn && grid[6].text == playerTurn)
        {
            FinishGame();
        }
        else if (playerPressGrid >= 9)
        {
            DrawEvent();
        }
        else
        {
            SwitchTurn();
        }

    }

    public void FinishGame()
    {
        //แจ้งว่าใครเป็นผู้ชนะ
        //มีปุ่มให้ play again
        //ออกจาก app
        UIManager.instance.finishPanel.gameObject.SetActive(true);
        UIManager.instance.finishPanel.Find("WhoWin").GetComponent<Text>().text = playerTurn + "'s Win!!";
        UIManager.instance.finishPanel.Find("Play Again").GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlayAgain()));
    }

    public void DrawEvent()
    {
        UIManager.instance.finishPanel.gameObject.SetActive(true);
        UIManager.instance.finishPanel.Find("WhoWin").GetComponent<Text>().text = "X O Draw!!";
        UIManager.instance.finishPanel.Find("Play Again").GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlayAgain()));
    }

    public IEnumerator PlayAgain()
    {
        var loadAsync = SceneManager.LoadSceneAsync("GamePlay");

        while (!loadAsync.isDone)
        {
            yield return null;
        }
    }


    public void SetUpHistory(Button button)
    {
        history.Add(button);
        if (undoState)
        {
            redoHistory.Clear();
        }
    }

    void SetUpUndoHistory(Button button)
    {
        history.Add(button);
        redoHistory.RemoveAt(0);
    }
    void UndoHistory()
    {
        if (history.Count == 0) return;
        //delete last history
        //var backup = history[history.Count - 1];
        undoState = true;
        SwitchTurn();
        redoHistory.Add(history[history.Count - 1]);
        history[history.Count - 1].GetComponent<Button>().interactable = true;
        history[history.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
        history.RemoveAt(history.Count - 1);
    }

    void RedoHistory()
    {
        //if (redoHistory.Count == 0) return;
        if (redoHistory.Count == 0)
        {
            undoState = false;
            return;
        }

        redoHistory[0].transform.Find("Text").GetComponent<Text>().text = playerTurn;
        SwitchTurn();
        redoHistory[0].GetComponent<Button>().interactable = false;
        SetUpUndoHistory(redoHistory[0]);
        
        //if (redoHistory.Count == 0)
        //{
        //    undoState = false;
        //    return;
        //}
       
    }
}

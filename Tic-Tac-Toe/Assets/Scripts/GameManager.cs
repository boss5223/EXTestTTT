using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if(playerTurn == "X")
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

    public void EndTurnEvent()
    {
        if (grid[0].text == playerTurn && grid[1].text == playerTurn && grid[2].text == playerTurn) 
        {
            Debug.Log("End Game!!");
   
        }
        else if (grid[3].text == playerTurn && grid[4].text == playerTurn && grid[5].text == playerTurn) 
        {
 
        }
        else if (grid[6].text == playerTurn && grid[7].text == playerTurn && grid[8].text == playerTurn)
        {
           
        }
        else if (grid[0].text == playerTurn && grid[3].text == playerTurn && grid[6].text == playerTurn) 
        {
           
        }
        else if (grid[1].text == playerTurn && grid[4].text == playerTurn && grid[7].text == playerTurn) 
        {
           
        }
        else if (grid[2].text == playerTurn && grid[5].text == playerTurn && grid[8].text == playerTurn) 
        {
           
        }
        else if (grid[0].text == playerTurn && grid[4].text == playerTurn && grid[8].text == playerTurn) 
        {
         
        }
        else if (grid[2].text == playerTurn && grid[4].text == playerTurn && grid[6].text == playerTurn) 
        {
            
        }
        else if (playerPressGrid >= 9)
        {
           
        }
        else
        {
            SwitchTurn();
        }

    }
}

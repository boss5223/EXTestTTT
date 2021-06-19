using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string playerTurn;

    private void Awake()
    {
        instance = this;
    }

    void SetTurnPlayer(string player)
    {
        playerTurn = player;
    }
}

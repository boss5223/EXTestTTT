using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button gridButton;
    public Text gridText;
    public string player;
    private GridSpace grid;

    private void Start()
    {
        gridButton.onClick.AddListener(() => SetGridSpace());
    }
    public GridSpace SetGridSpace()
    {
        player = GameManager.instance.playerTurn;
        gridText.text = player;
        gridButton.interactable = false;
        GameManager.instance.EndTurnEvent();
        return this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Indicator")]
    public GameObject player1;
    public GameObject player2;


    [Header("Color")]
    public Color turnerColor;
    public Color unturnColor;

    [Header("UI")]
    public Transform finishPanel;

    [Header("Control")]
    public Button undoBTN;
    public Button redoBTN;

    private void Awake()
    {
        instance = this;
    }
}

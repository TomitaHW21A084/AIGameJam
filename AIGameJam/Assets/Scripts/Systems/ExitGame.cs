using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public static ExitGame instance;

    public static bool hasFinishedGame;

    [SerializeField] private GameObject endBoard;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
        hasFinishedGame = false;
    }

    public void EndGame()
    {
        // TODO:　ゲームの結果を表示する
        Debug.Log($"ゲーム終了！");
        hasFinishedGame = true;
        endBoard.SetActive(true);
        
    }
}

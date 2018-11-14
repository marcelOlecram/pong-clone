using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_GameOver : MonoBehaviour {

    #region variables
    // public
    public GameObject gameOverUI;
    // private
    private bool isGameOver = false;
    private GameManager gameManager;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
        gameManager.GameOverEvent += GameOver;
    }

    private void OnDisable()
    {
        gameManager.GameOverEvent -= GameOver;
    }
	#endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GetComponent<GameManager>();
        isGameOver = false;
        gameOverUI.SetActive(isGameOver);
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(isGameOver);
    }
	#endregion
}

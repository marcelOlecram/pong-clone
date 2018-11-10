using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_TogglePause : MonoBehaviour {

    #region variables
    // public
    public GameObject pauseUI;
    // private
    private bool isPaused = false;
    private GameManager gameManager;
	#endregion
	
	#region UnityMethods
	private void OnEnable () {
        SetInitialReferences();
        gameManager.TogglePauseEvent += TogglePause;
	}

    private void OnDisable()
    {
        gameManager.TogglePauseEvent -= TogglePause;
    }

    // Update is called once per frame
    private void Update () {
        CheckForPauseToggleRequest();
	}
	#endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GetComponent<GameManager>();
        pauseUI.SetActive(isPaused);
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Debug.Log("pause pressed");
        pauseUI.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    private void CheckForPauseToggleRequest()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameManager.isGameOver)
        {
            gameManager.CallTogglePauseEvent();
        }
    }
	#endregion
}

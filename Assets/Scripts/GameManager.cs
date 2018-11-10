using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region delegates
    public delegate void GameManagerEventHandler();

    public event GameManagerEventHandler GoToMenuEvent;
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler TogglePauseEvent;
    public event GameManagerEventHandler GameOverEvent;
    #endregion

    #region variables
    // public
    public bool isPaused = false;
    public bool isGameOver = false;
    // private
    #endregion

    #region UnityMethods
	#endregion
	
	#region MyMethods
    public void CallGoToMenuEvent() {
        if (GoToMenuEvent != null) {
            GoToMenuEvent();
        }
    }
    public void CallRestartLevelEvent() {
        if (RestartLevelEvent != null) {
            RestartLevelEvent();
        }
    }
    public void CallTogglePauseEvent() {
        if (TogglePauseEvent != null) {
            isPaused = !isPaused;
            TogglePauseEvent();
        }
    }
    public void CallGameOverEvent() {
        if (GameOverEvent != null) {
            isGameOver = true;
            GameOverEvent();            
        }
    }
    #endregion
}

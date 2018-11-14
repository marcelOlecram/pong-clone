using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour {
    // TODO implement delegates and stuff
    #region delegates
    public delegate void GameLogicManagerEventHandler();

    public event GameLogicManagerEventHandler BallDestroyEvent;
    public event GameLogicManagerEventHandler BallSpawnEvent;
    #endregion

    #region variables
    // public
    // private
    [SerializeField]
    private GameObject ballInGame;
    #endregion

    #region UnityMethods
	#endregion
	
	#region MyMethods
    public void CallBallDestroyEvent()
    {
        if (BallDestroyEvent != null)
        {
            BallDestroyEvent();
        }
    }

    public void CallBallSpawnEvent()
    {
        if (BallSpawnEvent != null)
        {
            BallSpawnEvent();
        }
    }

    public void SetBallInGame(GameObject ball)
    {
        ballInGame = ball;
    }
    #endregion
}

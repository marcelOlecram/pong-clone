using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour {

    #region variables
    // public
    // private
    private GameLogicManager gameLogicManager;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
        gameLogicManager.BallDestroyEvent += Destroy;
    }

    private void OnDisable()
    {
        gameLogicManager.BallDestroyEvent -= Destroy;
    }
	#endregion
	
	#region MyMethods
    private void Destroy()
    {
        gameLogicManager.CallBallSpawnEvent();
        Destroy(this.gameObject);
    }

    private void SetInitialReferences()
    {
        gameLogicManager = GameObject.FindGameObjectWithTag("GameLogicManager").GetComponent<GameLogicManager>();
    }
	#endregion
}

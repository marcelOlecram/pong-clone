using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_GoToMenu : MonoBehaviour {

    #region variables
    // public
    // private
    private GameManager gameManager;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
        gameManager.GoToMenuEvent += GoToMenu;
    }

    private void OnDisable()
    {
        gameManager.GoToMenuEvent -= GoToMenu;
    }
	#endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void GoToMenu()
    {
        Debug.Log("Go To Menu");
    }
	#endregion
}

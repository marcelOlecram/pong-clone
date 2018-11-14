using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_RestartLevel : MonoBehaviour {

    #region variables
    // public
    // private
    private GameManager gameManager;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
        gameManager.RestartLevelEvent += RestartScene;
    }

    private void OnDisable()
    {
        gameManager.RestartLevelEvent -= RestartScene;
    }
    #endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	#endregion
}

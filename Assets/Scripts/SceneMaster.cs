using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour {

    #region variables
    // public
    public string sceneToGo;
	// private
	#endregion
	
	#region UnityMethods
	#endregion
	
	#region MyMethods
    public void QuitApplication()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneToGo);
    }
	#endregion
}

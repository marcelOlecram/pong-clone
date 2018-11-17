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
        StartCoroutine(Wait());
        SceneManager.LoadScene(sceneToGo);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
    }
	#endregion
}

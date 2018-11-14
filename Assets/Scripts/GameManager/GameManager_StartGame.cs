using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_StartGame : MonoBehaviour {

    #region variables
    // public
    public Text startTimer;
    public float waitingTime;
    public GameObject startPanel;
    // private
    private GameManager gameManager;
    private GameLogicManager gameLogicManager;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
        gameManager.StartGameEvent += gameLogicManager.CallBallSpawnEvent;
    }

    private void OnDisable()
    {
        gameManager.StartGameEvent -= gameLogicManager.CallBallSpawnEvent;
    }
    // Use this for initialization
    private void Start () {
        SetInitialReferences();
        StartCoroutine(WaitToActuallyStart());
	}
	#endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GetComponent<GameManager>();
        gameLogicManager = GameObject.FindGameObjectWithTag("GameLogicManager").GetComponent<GameLogicManager>();
        startPanel.SetActive(true);
    }

    private IEnumerator WaitToActuallyStart()
    {
        while (waitingTime > 0)
        {
            yield return null;
            waitingTime -= Time.deltaTime;
            startTimer.text = Mathf.Ceil(waitingTime).ToString();
        }
        gameManager.CallStartGameEvent();
        yield return new WaitForSeconds(0.2f);
        startPanel.SetActive(false);
    }
	#endregion
}

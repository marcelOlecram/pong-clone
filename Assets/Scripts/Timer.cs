using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    #region variables
    // public
    public float initialTime;
    public Text gameTimer;
    // private
    private float currentTime;
    private GameManager gameManager;
    #endregion
    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
        gameManager.StartGameEvent += StartCounting;
    }

    private void OnDisable()
    {
        gameManager.StartGameEvent -= StartCounting;
    }
    // Use this for initialization
    private void Start () {
        SetInitialReferences();
        //StartCounting();
	}
	
	// Update is called once per frame
	private void Update () {
        
	}
	#endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        currentTime = initialTime;
        UpdateUI(gameTimer);
    }

    private void UpdateUI(Text uiText)
    {
        gameTimer.text = string.Format("{0:00}", Mathf.Ceil(currentTime));
    }

    private IEnumerator Counting()
    {
        while(currentTime >= 0f)
        {
            currentTime -= Time.deltaTime;
            yield return null;
            UpdateUI(gameTimer);
        }
        gameManager.CallGameOverEvent();
    }

    public void StartCounting()
    {
        StartCoroutine(Counting());
    }
	#endregion
}

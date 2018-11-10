using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    #region variables
    // public
    public float initialTime;
    public Text timer;
    // private
    private float currentTime;
    private GameManager gameManager;
	#endregion
	#region UnityMethods
	// Use this for initialization
	private void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	private void Update () {
        if (currentTime >= 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
            return;
        }
        gameManager.CallGameOverEvent();
	}
	#endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        currentTime = initialTime;
        UpdateUI();
    }

    private void UpdateUI()
    {
        timer.text = string.Format("{0:00}", Mathf.Ceil(currentTime));
    }
	#endregion
}

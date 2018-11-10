using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour {

    #region variables
    // public
    public Text scoreText;
    // private
    private GameObject collidedObject;
    private int score;
	#endregion
	
	#region UnityMethods
	// Use this for initialization
	private void Start () {
        SetInitialReferences();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObject = collision.gameObject;
        Destroy(collidedObject);
        score++;
        UpdateUI();
    }
    #endregion

    #region MyMethods
    private void UpdateUI()
    {
        scoreText.text = score.ToString();
    }

    private void SetInitialReferences()
    {
        score = 0;
        UpdateUI();
    }
    #endregion
}

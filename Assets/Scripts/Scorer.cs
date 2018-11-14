using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour {

    #region variables
    // public
    public Text scoreText;
    // private
    private GameLogicManager gameLogicManager;
    private GameObject collidedObject;
    private int score;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
    }

    private void OnDisable()
    {
    }
    // Use this for initialization
    private void Start () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObject = collision.gameObject;
        ScorePlayer();
        UpdateUI();
        gameLogicManager.CallBallDestroyEvent();
    }
    #endregion

    #region MyMethods
    private void UpdateUI()
    {
        scoreText.text = score.ToString();
    }

    private void SetInitialReferences()
    {
        gameLogicManager = GameObject.FindGameObjectWithTag("GameLogicManager").GetComponent<GameLogicManager>();
        score = 0;
        UpdateUI();
    }

    private void ScorePlayer()
    {
        score++;
    }
    #endregion
}

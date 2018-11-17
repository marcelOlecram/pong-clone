using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingUIAnimation : MonoBehaviour {

    #region variables
    // public
    // private
    [SerializeField]
    private string fadeTriggerName;
    private Animator _animator;
    private GameManager gameManager;
	#endregion
	
	#region UnityMethods
	private void OnEnable () {
        SetInitialReferences();
        gameManager.StartGameEvent += PlayFade;
	}
	
	private void OnDisable () {
        gameManager.StartGameEvent -= PlayFade;
    }

    private void Start()
    {
        SetInitialReferences();
    }
    #endregion

    #region MyMethods
    private void SetInitialReferences()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _animator = GetComponent<Animator>();
    }

    public void PlayFade()
    {
        _animator.SetTrigger(fadeTriggerName);
    }
	#endregion
}

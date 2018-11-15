using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIAnimation : MonoBehaviour {

    #region variables
    // public
    // private
    [SerializeField]
    private string fadeOutTriggerName;
    [SerializeField]
    private string fadeInTriggerName;
    //private GameManager gameManager;
    private Animator _animator;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        SetInitialReferences();
    }

    private void OnEnable () {
        //gameManager.TogglePauseEvent += FadeOut;
        FadeIn();
	}
	
	private void OnDisable () {
        //gameManager.TogglePauseEvent -= FadeOut;
        FadeOut();
    }
	#endregion
	
	#region MyMethods
    private void SetInitialReferences()
    {
        //gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _animator = GetComponent<Animator>();
    }

    private void FadeOut()
    {
        _animator.SetTrigger(fadeOutTriggerName);
    }

    private void FadeIn()
    {
        _animator.SetTrigger(fadeInTriggerName);
    }
	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    #region variables
    // public
    public float _forceMagnitude = 5f;
    // private
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
    }
    #endregion

    #region MyMethods
    private void SetForce()
    {
        _direction = Random.insideUnitCircle.normalized;
        _rigidbody.AddForce(_direction * _forceMagnitude, ForceMode2D.Impulse);
    }

    private void SetInitialReferences()
    {
        _rigidbody = GetComponent<Rigidbody2D>();       
    }

    public void SetForceAndDirection(float forceMagnitude, Vector2 direction)
    {
        _forceMagnitude = forceMagnitude;
        _direction = direction.normalized;
        _rigidbody.AddForce(_direction * _forceMagnitude, ForceMode2D.Impulse);
    }
	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    #region variables
    // public
    public GameObject ballPrefab;
    public Vector2 spawnDirection;
    public float spawnForce;
    // private
    [SerializeField]
    private GameObject currentBall;
    private float forceIncrement = 0.1f;    
    private GameLogicManager gameLogicManager;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        SetInitialReferences();
        gameLogicManager.BallSpawnEvent += SpawnBall;
    }

    private void OnDisable()
    {
        gameLogicManager.BallSpawnEvent -= SpawnBall;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + new Vector3(spawnDirection.x, spawnDirection.y)));
    }
    #endregion

    #region MyMethods
    private void SetInitialReferences()
    {
        //SpawnBall();
        gameLogicManager = GameObject.FindGameObjectWithTag("GameLogicManager").GetComponent<GameLogicManager>();
    }

    public void SpawnBall()
    {
        spawnDirection = GenRandomDirection();
        currentBall = Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
        currentBall.GetComponent<Ball>().SetForceAndDirection(spawnForce, spawnDirection);
        spawnForce += forceIncrement;

        gameLogicManager.SetBallInGame(currentBall);
    }

    private Vector2 GenRandomDirection()
    {
        Vector2 newDir = new Vector2();
        newDir.x = Random.Range(-1f, 1f);
        newDir.y = Random.Range(-0.6f, 0.6f);
        return newDir.normalized;
    }
	#endregion
}

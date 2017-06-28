
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaveGenerator : MonoBehaviour
{


    #region Variables
    [Header ("Private Fields")]
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private int WaveSize = 0;   //  Size of the Waves
    [SerializeField]
    private float SpawnInterval = 0; //  Time between each Object spawn
    private Transform SpawnPosition;
    [Header ("Spawning Area")]
    //  Boundary of spawning Area. (X = Minimum | Y = Maximum)
    [SerializeField]
    private Vector2 ClampX;
    [SerializeField]
    private Vector2 ClampY;

	#endregion

	#region BuildIn Methods
	void Start ()
	{
        SpawnPosition = GameObject.Find ("SpawnPosition").transform;    //  Find the GameObject to spawn at
        StartCoroutine (Spawner ());
	
	}

	

	void Update ()
	{
		
         
	
	}
	#endregion

	#region Custom Methods
    IEnumerator Spawner ()
    {
        while (Master.Lifes > -1)
        {
            for (int i = 0; i < WaveSize; i++)
            {
                Instantiate (EnemyPrefab, new Vector3 (Random.Range (ClampX.x, ClampX.y), Random.Range (ClampY.x, ClampY.y), SpawnPosition.position.z), SpawnPosition.rotation);
                yield return new WaitForSeconds (SpawnInterval);
            }
        }
    }
	#endregion

}

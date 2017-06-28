
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraLogic : MonoBehaviour
{


    #region Variables
    [Header ("Private Fields")]
    [SerializeField]
    private float OffsetY; 
    [SerializeField]
    private float DistanceToTarget; //  Distance to Target on the Z-Axis
    [SerializeField]
    private Transform Target;
	#endregion

	#region BuildIn Methods
	void Start ()
	{
		
		
	
	}

	

	void FixedUpdate ()
	{
        if (Target)
        {
            transform.position = new Vector3 (Target.position.x, Target.position.y + OffsetY, Target.position.z + DistanceToTarget);    //  Follow the player around
        }
        

	
	}
	#endregion

	#region Custom Methods
	#endregion

}

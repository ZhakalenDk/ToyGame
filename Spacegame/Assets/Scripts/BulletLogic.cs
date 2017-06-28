
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletLogic : MonoBehaviour
{


    #region Variables
    [Header ("Private Fields")]
    [SerializeField]
    private Vector3 VelocityVector;
    private Rigidbody Rigid;
	#endregion

	#region BuildIn Methods
	void Start ()
	{

        Rigid = GetComponent<Rigidbody> ();
        Rigid.velocity = VelocityVector;
	
	}

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy (other.gameObject);
            Destroy (gameObject);
        }
    }
    #endregion

    #region Custom Methods
    #endregion

}

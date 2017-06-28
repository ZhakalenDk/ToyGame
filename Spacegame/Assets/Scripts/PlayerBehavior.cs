
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerBehavior : MonoBehaviour
{


    #region Variables
    [Header ("Private fields")]
    [SerializeField]
    private float Force = 0;
    private Rigidbody Rigid;
    [SerializeField]
    private Transform Model;

    [Header ("Fire Function")]
    [SerializeField]
    private float ShootingInterval = 0;
    private float InternalInterval;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private Transform BulletSpawn;

    [Header ("Boundary")]
    [SerializeField]
    private float ClampXMin = 0;
    [SerializeField]
    private float ClampXMax = 0;
    [SerializeField]
    private float ClampYMin = 0;
    [SerializeField]
    private float ClampYMax = 0;
    

	#endregion

	#region BuildIn Methods
	void Start ()
	{
        InternalInterval = ShootingInterval;
        Rigid = GetComponent<Rigidbody> ();
	
	}

	

	void Update ()
	{

        Movement ();
        FireFunction ();

	}
	#endregion

	#region Custom Methods
    private void Movement ()
    {
        float Horizontal = Input.GetAxis ("Horizontal");
        float Vertical = Input.GetAxis ("Vertical");

        //  Movement and rotaion of GamneObject
        if (Horizontal > 0)
        {
            Rigid.AddRelativeForce (transform.right * Force * Time.deltaTime, ForceMode.Impulse);
            Model.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, -15);
        }
        if (Horizontal < 0)
        {
            Rigid.AddRelativeForce (-transform.right * Force * Time.deltaTime, ForceMode.Impulse);
            Model.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, 15);
        }
        //  Reset Rotation
        else if (Horizontal == 0 && Horizontal == 0)
        {
            Model.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, 0);
        }

        if (Vertical > 0)
        {
            Rigid.AddRelativeForce (transform.up * Force * Time.deltaTime, ForceMode.Impulse);
        }
        if (Vertical < 0)
        {
            Rigid.AddRelativeForce (-transform.up * Force * Time.deltaTime, ForceMode.Impulse);
        }

        /*Boundary*/
        if (transform.position.x < ClampXMin || transform.position.x > ClampXMax)
        {
            transform.position = new Vector3 (Mathf.Clamp (transform.position.x, ClampXMin, ClampXMax), transform.position.y, transform.position.z);
        }
        if (transform.position.y < ClampYMin || transform.position.y > ClampYMax)
        {
            transform.position = new Vector3 (transform.position.x, Mathf.Clamp (transform.position.y, ClampYMin, ClampYMax), transform.position.z);
        }
    }

    private void FireFunction ()
    {
        InternalInterval -= Time.deltaTime;

        if (Input.GetButton ("Jump") && InternalInterval < 0)
        {
            Instantiate (BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
            InternalInterval = ShootingInterval;
        }
    }
	#endregion

}

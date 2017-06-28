
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyLogic : MonoBehaviour
{


    #region Variables
    [Header ("Private Fields")]
    private Rigidbody Rigid;
    [SerializeField]
    private Vector3 VelocityVector; //  Vector for setting the Velocity of this GameObject

    [Header ("Enemy Properties")]
    [SerializeField]
    private float Damage;
    public float _Damage
    {
        get
        {
            return Damage;
        }
        set
        {
            Damage = Random.Range((Damage / 2), Damage);
        }
    }
    [SerializeField]
    private int Value;
	#endregion

	#region BuildIn Methods
	void Start ()
	{
        _Damage = Damage;
        Rigid = GetComponent<Rigidbody> ();
        Rigid.velocity = VelocityVector * Time.deltaTime;
        /*DEBUG/*///Master.ShipShield -= Damage;/*DEBUG*/
	
	}

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            Master.ShipShield -= Damage;
            Destroy (gameObject);
        }

        if (other.tag == "Bullet")
        {
            Master.Coins += Value;
            Master.Points += Value;
        }
    }
    #endregion

    #region Custom Methods
    #endregion

}

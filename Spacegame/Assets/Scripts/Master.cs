
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{


    #region Variables
    [Header ("Game Stats")]
    public static int Lifes = 3;
    public static int Points = 0;
    public static float ShipShield = 100;
    public static int Coins;
    [SerializeField]
    private float _Coins = Coins;

    [Header ("Text")]
    public Text Life, Point, currency, Shield;
	#endregion

	#region BuildIn Methods
	void Start ()
	{
	
	}

	

	void Update ()
	{
        Life.text = "Lifes: " + Lifes;
        Point.text = "Points: " + Points;
        currency.text = "Coins: " + Coins;
        Shield.text = "Shield: " + ShipShield.ToString("00") + "%";

        /*Game Over and decreasing in "Health"*/
        if (ShipShield < 0)
        {
            Lifes -= 1;
            ShipShield = 100;
            if (Lifes < 0)
            {
                Debug.Log ("Game Over");
                Destroy (GameObject.FindGameObjectWithTag ("Player"));
            }
        }
        /*DEBUG*/
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log (ShipShield);
            Debug.Log (Lifes);
        }
        /*DEBUG*/
	
	}
	#endregion

	#region Custom Methods
	#endregion

}

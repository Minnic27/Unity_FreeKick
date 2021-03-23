using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject ball;

    public float ballDistance = 2f;
    public float ballThrowingForce = 5f;

    Vector3 shootingArc;

    private int randomIntZ;
    private int randomIntY;

    private bool holdingBall = true;
    

    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;

        randomIntZ = Random.Range(50, 100);
        randomIntY = Random.Range(100, 150);
        shootingArc = new Vector3(0, randomIntY, randomIntZ);

    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(shootingArc.normalized * ballThrowingForce);
                holdingBall = false;
            }
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Checker")
        {
            Debug.Log("SCORE!!");
        }
    }
}

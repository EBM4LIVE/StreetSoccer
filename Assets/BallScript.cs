using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public float ballSpeed;
    private Vector2 forceDirection;
    private float length;
    //Ball State
    enum State
    {
        OnIdle,
        Onshoot,
        Onhit
    }
    State currentState;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = State.OnIdle;
        Debug.Log(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        OnIdle();
        OnShoot();
        if(currentState == State.Onshoot)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                forceDirection = PoolScript.mousePos - new Vector2(transform.position.x, transform.position.y);
                length = Vector2.Distance(PoolScript.mousePos, transform.position);
                rb.gravityScale = 34;
                transform.localScale =transform.localScale*length/100 ;
                if (transform.localScale.x <1)
                {
                    transform.localScale = new Vector3(1, 1); 
                }

            }
            if (ballSpeed == 0)
            {
                rb.gravityScale = 1f;
            }
        }

    }

    private void FixedUpdate()
    {
        OnShoot();
       
       
    }




    //StateMachine
    void ChangeState( State state)
    {
        currentState = state;
        Debug.Log(currentState);
    }
    //States

   void OnIdle()
    {
        if(currentState == State.OnIdle)
        {



            //Trasition State
            //Idle to Shoot
            if (Input.GetMouseButtonDown(0))
            {
                ChangeState(State.Onshoot);
            }
        }
    }

    void OnShoot()
    {
        if(currentState == State.Onshoot)
        {
            BallShoot();

        }
    }
    void Onhit()
    {
        if(currentState == State.Onhit)
        {

        }
    }











    //Actions
    void BallShoot()
    {
      
      
        if (PoolScript.mousePos != null)
        {
            


            rb.velocity = forceDirection * ballSpeed * Time.deltaTime;
            //rb.AddForce(forceDirection* ballSpeed * Time.deltaTime, ForceMode2D.Impulse);


            float multiplier = 3;
            ballSpeed -= ballSpeed* multiplier * Time.deltaTime;
            if (ballSpeed <= 1)
            {
                ballSpeed = 0;
            }



        }


       
    }


    
}

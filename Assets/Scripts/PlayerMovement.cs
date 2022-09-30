using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats playerStats;
    Rigidbody rb;
    public float speed = 3;

    public Animator anim;

    public bool isMoving;
    public bool isDashing;

    float dashTime;
    public float dashSpeed;
    public float startDashTime;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            rb.velocity = move * playerStats.mSpeed;
            anim.SetFloat("speed", rb.velocity.magnitude);
            //Debug.Log(rb.velocity.magnitude);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Roll in this direction
                Debug.Log("Space pressed");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    dir = hit.point - transform.position;

                    isDashing = true;
                    playerStats.invulnerable = true;
                    //Debug.Log(dir);

                    //transform.LookAt(new Vector3(hit.point.x, hit.point.z));
                    //transform.localposition = new Vector3(hit.point.x, hit.point.z) * 0.3f;
                }
            }
        }
        else
        {
            dashTime -= Time.deltaTime;
            rb.velocity = rb.velocity.normalized * dashSpeed;
            if(dashTime <= 0)
            {
                dashTime = startDashTime;
                playerStats.invulnerable = false;
                isDashing = false;
            }
        }

        if (rb.velocity.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }
}

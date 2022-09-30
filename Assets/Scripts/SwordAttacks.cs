using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttacks : MonoBehaviour
{
    public PlayerStats playerStats;

    Vector3 drawDir;
    public Animator anim;

    public int currAnim = 1;
    public bool casting = false;

    bool castCombo;

    public float afterCast;
    public float timer;

    public LayerMask layerToHit;

    bool charging;

    public GameObject fullSwingTrigger;

    public float chargeTime;

    public int chargeAmount;

    public float swingDamage;

    private void Start()
    {
        currAnim = 1;
        casting = false;
        swingDamage = playerStats.damage;
    }
    private void Update()
    {
        
        if (castCombo)
        {
            timer += Time.deltaTime;
            if (timer >= 1.8f)
            {
                currAnim = 1;
                anim.Play("Idle");
                timer = 0;
                castCombo = false;
            }
        }
        //Left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            if(!casting && !charging)
            {
                //cast basic attack in dir of the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Vector3 dir = hit.point - transform.parent.position;
                    Vector3 newDir = new Vector3(dir.x, 1, dir.z);
                    //Debug.Log(dir);
                    BasicAttack(newDir);
                    drawDir = newDir;
                    timer = 0;
                    casting = true;
                    castCombo = true;
                    StartCoroutine(CastAnimation());
                }
            }
            else
            {
                //StartCoroutine(CastAfter());
            }
        }

        if(Input.GetMouseButton(1))
        {
            if(!casting)
            {
                ChargingSwing();
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            if (charging)
            {
                FullSwing(chargeAmount);
            }
        }

    }

    void ChargingSwing()
    {
        if (chargeAmount < 3)
        {
            castCombo = false;
            timer = 0;

            //start charging the full swing
            charging = true;

            chargeTime += Time.deltaTime;
            if (chargeTime >= 1)
            {
                if (chargeAmount < 3)
                {
                    chargeAmount++;
                }
                else
                {
                    FullSwing(chargeAmount);
                }
                chargeTime = 0;
            }

            anim.Play("SwordCharge");
        }

    }

    void FullSwing(int charges)
    {
        swingDamage *= charges;
        fullSwingTrigger.SetActive(true);
        //anim.Play("FullSwing");
        chargeTime = 0;
        chargeAmount = 0;
        StartCoroutine(CastFullSwing());
        //cant attack while this is playing
    }

    void BasicAttack(Vector3 dir)
    {
        //Sphere cast next to the player
        //

        RaycastHit hit;
        if(Physics.SphereCast(transform.parent.position, 1, dir, out hit, 5f))
        {
            Debug.Log(hit.collider.gameObject);
            if(hit.collider.GetComponent<Enemy>())
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(playerStats.damage);
            }
        }
    }

    IEnumerator CastFullSwing()
    {
        anim.Play("FullSwing");
        yield return new WaitForSeconds(0.48f);
        casting = false;
        charging = false;
        fullSwingTrigger.SetActive(false);
        swingDamage = playerStats.damage;
    }
    IEnumerator CastAnimation()
    {
        anim.Play("Swing" + currAnim);
        //afterCast = castTime + 0.2f;
        yield return new WaitForSeconds(0.25f);
        casting = false;
        if(currAnim < 3)
        {
            currAnim++;
        }
        else
        {
            currAnim = 1;
        }
        //If click again within .2 seconds of this animation ending, cast the next animation, else we go back to idle
    }
    IEnumerator CastAfter()
    {
        yield return new WaitForSeconds(afterCast - 0.2f);
        StartCoroutine(CastAnimation());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(drawDir, 1);
    }
}

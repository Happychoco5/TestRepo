using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;

    public Animator anim;

    public bool tookDamage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage()
    {

    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            //Die
            //anim.Play("Death");
            Destroy(gameObject, 2);
            //Debug.Log("Dead");
            //explode?
        }
        if (!tookDamage)
        {
            //Change to flash red or something else
                anim.Play("TakeDamage");
                tookDamage = true;
                StartCoroutine(DamageTimer());
        }

    }

    IEnumerator DamageTimer()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        tookDamage = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Deal damage to player
            Debug.Log("Dealing damage to player");
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}

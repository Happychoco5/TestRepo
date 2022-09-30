using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float damage;
    public float mSpeed;
    public float atkSpeed;
    public float luck;

    public bool invulnerable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        //invulnerable while dashing
        if(!invulnerable)
        {
            health -= damageToTake;

            if(health < 0)
            {
                //die
            }
        }
    }
}

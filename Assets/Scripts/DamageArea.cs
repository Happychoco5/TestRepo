using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float damage;
    public float size;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(size, size, size);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Dealt damage to player");
            other.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public float x;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector2 dir = hit.point - transform.localPosition;
            float dot = Vector2.Dot(dir, transform.right);

            //transform.LookAt(new Vector3(hit.point.x, hit.point.z));
            //transform.localposition = new Vector3(hit.point.x, hit.point.z) * 0.3f;
        }
    }
}

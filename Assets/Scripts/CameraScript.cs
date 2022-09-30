using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;

    public LayerMask thisLayer;

    public PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, player, ref velocity, smoothTime);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, thisLayer))
        {
            Vector3 dir = hit.point - transform.localPosition;
            float dot = Vector2.Dot(dir, transform.right);


            Vector3 targetPosition = new Vector3(playerPosition.position.x + (dir.x * 0.1f), transform.position.y, (playerPosition.position.z + (dir.z * 0.1f)) - 30f);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            //transform.LookAt(new Vector3(hit.point.x, hit.point.z));
            //transform.localposition = new Vector3(hit.point.x, hit.point.z) * 0.3f;
        }
    }
}

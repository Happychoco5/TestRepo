using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class HandHolders : MonoBehaviour
{
    public GameObject LHandIK;
    public GameObject RHandIK;

    public Transform LHandHolder;
    public Transform RHandHolder;

    public IKManager2D ikManager2D;

    public LimbSolver2D rLimbSolver;
    public LimbSolver2D lLimbSolver;

    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        ikManager2D.weight = 1;
    }

    // Update is called once per frame
    
    void Update()
    {
        //LHandIK.transform.position = LHandHolder.position;
        //RHandIK.transform.position = RHandHolder.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 mousePos = hit.point;
            Vector3 dir = mousePos - transform.position;
            float dot = Vector3.Dot(dir, transform.right);

            if (dot < 0)
            {
                //left
                Vector3 scale = transform.parent.localScale;
                scale.x = -1;
                transform.parent.localScale = scale;

                //rLimbSolver.flip = false;
                //lLimbSolver.flip = false;

            }
            else
            {
                //right
                Vector3 scale = transform.parent.localScale;
                scale.x = 1;
                transform.parent.localScale = scale;

                //rLimbSolver.flip = true;
                //lLimbSolver.flip = true;
            }
        }

    }
}

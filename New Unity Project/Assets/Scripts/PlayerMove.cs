using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float rotationMin;
    public float rotationMax;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    public float xStep;
    public float zStep;
    public float rotationStep;
    public int secondsAtEachPosition;

    public float xCurr,zCurr,rotationCurr;
    // Start is called before the first frame update
    void Start()
    {
        xCurr = xMin;
        zCurr = zMin;
        rotationCurr = rotationMin;
        StartCoroutine(movePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator movePlayer()
    {

        this.transform.position = new Vector3(xCurr, 1.0f, zCurr);
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotationCurr, this.transform.eulerAngles.z);
        yield return new WaitForSeconds(secondsAtEachPosition);
        xCurr += xStep;

        if (zCurr >= zMax)
        {
            
            rotationCurr += rotationStep;
            zCurr = zMin;
            xCurr = xMin;
        }


        if (xCurr >= xMax)
        {
            zCurr += zStep;
            xCurr = xMin;
        }
        
        

        if (rotationCurr<=rotationMax)
            StartCoroutine(movePlayer());

    }
}

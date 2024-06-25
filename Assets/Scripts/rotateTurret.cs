using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class rotateTurret : MonoBehaviour
{
    Transform target;
    public GameObject turret;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            target = other.gameObject.transform;
            turret.transform.LookAt(target.position);
            Debug.Log("targeting");
        }
    }
}

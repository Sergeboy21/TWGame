using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    public float range;
    public float fireRate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public LayerMask layer;
    public SphereCollider sphere;
    

    private float fireCountdown;

    private void Start()
    {
        sphere.radius = range;
    }

    void Update()
    {
        if (fireCountdown <= 0f)
        {
            TargetEnemy();
            fireCountdown = fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    

    void TargetEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("shooting");
                Shoot(hit.transform);
            }
        }

        Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, layer);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.name);
            //hitCollider.SendMessage("AddDamage");
        }
    }

    void Shoot(Transform Enemy)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, range);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrowd : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

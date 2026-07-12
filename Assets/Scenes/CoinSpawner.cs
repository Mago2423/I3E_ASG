using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoinSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject explosion;
    bool touched = false;
    public int Interact = 0;

    public void Interactcube()
    {
        Interact++;
        if(Interact >= 3)
        {
            touched = true;
        }
        if(touched)
        {
            var spawnedObject = Instantiate(objectToSpawn,transform.position + new Vector3(0,1,0), transform.rotation);
            var explosionObject = Instantiate(explosion,transform.position + new Vector3(0,1,0), transform.rotation, spawnedObject.transform);
            Destroy(gameObject);
            Destroy(explosionObject,2);
        }
    }
}

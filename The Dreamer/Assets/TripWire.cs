using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripWire : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject toyPrefab;
    public float explosionRadius = 3f;
    public float explosionForce = 300f;
    public Transform explosionPoint;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            spawnToys();
        }
        else
            return;
    }

    void spawnToys()
    {
        for (int i = 0; i < 6; i++)
        {
            // Instantiate the toy at the explosion point
            GameObject toyInstance = Instantiate(toyPrefab, explosionPoint.position, Random.rotation);
            

            // Apply explosion force
            Rigidbody rb = toyInstance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 explosionDirection = (toyInstance.transform.position - explosionPoint.position).normalized;
                rb.AddForce(explosionDirection * explosionForce);
            }
        }
    }
}

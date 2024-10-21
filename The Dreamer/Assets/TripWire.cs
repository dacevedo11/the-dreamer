using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripWire : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject[] toyPrefabs;
    public int numberOfToys = 4;
    public float explosionRadius = 5.0f;
    public float explosionForce = 500.0f;
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
        }

        // Create and scatter toys
            for (int i = 0; i < numberOfToys; i++)
            {
                // Randomly select a toy prefab to instantiate
                GameObject toyPrefab = toyPrefabs[Random.Range(0, toyPrefabs.Length)];
                
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

            // Destroy the tripwire after it triggers   Destroy(gameObject);
    }
}

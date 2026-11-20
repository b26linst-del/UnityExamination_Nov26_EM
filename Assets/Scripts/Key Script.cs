using System;
using Unity.VisualScripting;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Vector3 playerPos;

    [SerializeField] private float smoothTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Globals.Key = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.Key)
        {
            transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref playerPos, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Spelare nyckel!");
            Globals.Key = true;
        }
    }
}

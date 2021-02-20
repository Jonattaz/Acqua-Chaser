using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    // Variables
    private GameManager GameManager;

    public int pointValue;

    private GameObject enemy;

    private AudioSource audioSource;
    public AudioClip well;



    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        audioSource.clip = well;
        audioSource.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        // Activate the sound when the player collects the well
        audioSource.Play();
        audioSource.clip = well;


        // When collected destroy the enemy, the object and update the score
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.UpdateScore(pointValue);
            Destroy(enemy);


        }


    }



}





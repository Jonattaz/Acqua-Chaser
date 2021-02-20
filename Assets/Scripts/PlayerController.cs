using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;

    public float speed = 5.0f;
    private float verticalInput;
    private float horizontalInput;
    private float powerUpStrength = 50.0f;

    private bool hasPowerUp = false;


    public GameObject powerUpIndicator;
    public GameObject powerUpDeact;

    protected Joystick joystick;

    private Animator playerAnim;

    private AudioSource cactus;
    public AudioClip cactusSound;


    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        cactus = GetComponent<AudioSource>();
        joystick = FindObjectOfType<Joystick>();
        playerRb = gameObject.GetComponent<Rigidbody>();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerAnim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    // Method that controls the player's movement
    private void Movement()
    {
        // Makes the player move horizontaly and verticaly
        playerRb.velocity = new Vector3(joystick.Horizontal * 100f,
            playerRb.velocity.y, joystick.Vertical * 100f);




        // Controls the animation and rotation
        if (joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            playerAnim.SetFloat("Speed_f", 8);
            Quaternion rotation =
                Quaternion.LookRotation(playerRb.velocity);
            playerRb.transform.rotation = rotation;

        }
        else
        {
            playerAnim.SetFloat("Speed_f", 5);
        }


    }


    public void OnTriggerEnter(Collider other)
    {
        // If the player collides with PowerUp
        if (other.CompareTag("PowerUp"))
        {

            cactus.clip = cactusSound;
            cactus.Play();
            Destroy(other.gameObject);
            if (hasPowerUp == false)
            {
                hasPowerUp = true;
                StartCoroutine(PowerUpCountDownRoutine());
            }


        }

    }

    // Responsible for the time that the power up will work
    IEnumerator PowerUpCountDownRoutine()
    {

        if (hasPowerUp)
        {
            // Activates the powerUp color green
            powerUpIndicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(6 + 1);
            powerUpIndicator.gameObject.SetActive(false);

            // Activates the powerUp color red
            powerUpDeact.gameObject.SetActive(true);
            yield return new WaitForSeconds(4 + 1);
            powerUpDeact.gameObject.SetActive(false);
            hasPowerUp = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        //Activates the GameOver if the player collides with enemy without powerup
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == false)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
        else if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == true)
        {
            // Variables
            Rigidbody enemyRigibody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromPlayer = (collision.gameObject.transform.position - transform.position);

            // Makes the enemy fly away from the player
            enemyRigibody.AddForce(awayfromPlayer * powerUpStrength, ForceMode.Impulse);

        }
    }





}




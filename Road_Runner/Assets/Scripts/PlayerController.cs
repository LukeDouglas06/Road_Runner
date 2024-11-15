using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Include this to work with UI components

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    private Animator playerAnim;
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public bool gameOver = false;

    // Reference to the GameManager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("gameObject")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // Calling the GameOver method from GameManagr
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}

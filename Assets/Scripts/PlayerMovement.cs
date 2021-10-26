using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to control the players movement 
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerMove;
    private Vector2 movementController;
    public float _moveSpeed = 3f; // default movement speed for the player
    private Vector2 startPosition;
    private Vector3 startTurnPosition; 
    public static PlayerMovement instance; // instance of PlayerController class
    public GameController player;

    // Awake is called when the script instance is being loaded. Checks to make sure the instance is not null and assigns it to this class
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        _moveSpeed = 0.0f;
       playerMove.velocity = Vector2.zero;
        playerMove.angularVelocity = 0f;
    }

    // Start is called before the first frame update. Gets Rigidbody for Player's movement and start position
    public void StartGame()
    {
        _moveSpeed = 3f;
        playerMove = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Takes in keyboard inputs and translate them to horizontal and vertical movements of the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Adds continous force to the player as long as keyboard input is pushed
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        playerMove.AddForce(movement * _moveSpeed);


        // rotates the player to the direction that the keyboard inputs are recieved
        Vector3 rotationDirection = movement;
        float angle = Mathf.Atan2(rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        

    }


    // Moves the player in any direction with force
    void movePlayer(Vector2 direction)
    {
        playerMove.AddForce(direction * _moveSpeed);

    }
    
}

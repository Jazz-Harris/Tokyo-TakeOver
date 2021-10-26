using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the AI's behaviour

public class AIController : MonoBehaviour
{
    public static AIController instance;
    public Transform player;
    public bool moveAI;
    public float moveSpeed = 2.5f;
    private Rigidbody2D enemyRB;
    private Vector2 movement;

    // Awake is called when the script instance is being loaded. Checks to make sure the instance is not null and assigns it to this class
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody2D>();
        enemyRB.velocity = Vector2.zero;
        enemyRB.angularVelocity = 0f;
        moveAI = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (moveAI == true)
        {

            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemyRB.rotation = angle;
            direction.Normalize();
            movement = direction;
        }

    }

    // 
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {

        if (Vector2.Distance(transform.position, player.position) > 1.5f)
        {
            enemyRB.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }


    }

    public void moveEnemyAtStart()
    {
        moveAI = true;
        StartCoroutine(waitForPlayerToStart());
    }

    IEnumerator waitForPlayerToStart()
    {
        yield return new WaitForSeconds(3f);
    }
}

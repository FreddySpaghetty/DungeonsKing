using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
       Transform player;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    //public float speedEnemy = 5;
    //public float speedEnemyFollow = 10;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    //private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    // combat
    public int maxHealth = 100;
    int currentHealth;
    //private bool _stealth = true;
    void Awake(){
        _rb = this.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        calcuateNewMovementVector();

        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {   /*
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, _movement, 10);
        if(hitInfo.collider != null){

            if(hitInfo.collider.CompareTag("Player")){
                _stealth = false;
                Debug.Log("scoperto");
            }
        }*/
        if(player != null){
            if(Vector3.Distance(player.position, transform.position) < 5){
            Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            direction.Normalize();
            _movement = direction;
            moveCharacter(_movement);
        
            turnEnemy((player.position.x - transform.position.x));
            }else {
                if(Time.time - latestDirectionChangeTime > directionChangeTime){
                latestDirectionChangeTime = Time.time;
                calcuateNewMovementVector();
                }
                transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
            }  
        }
    }
        void moveCharacter (Vector2 direction){
            _rb.MovePosition((Vector2)transform.position + (direction * 10 * Time.deltaTime));
        }
         void calcuateNewMovementVector(){
            //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
            movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            movementPerSecond = movementDirection * 2;
            turnEnemy(movementDirection.x);
 }
        void turnEnemy(float direction){
            if(direction < 0){
                transform.localScale = new Vector2(-1.3f,1.3f);
            }else{
                transform.localScale = new Vector2(1.3f,1.3f);
            }
        }

        public void takeDamage(int damage){
            currentHealth -= damage;
            //hurt aniation
            if(currentHealth <= 0){
                die();
                ScoreScript.instance.addPoint();
                ScoreScript.instance.countKill();
            }
        }
        void die(){
            GetComponent<Collider2D>().enabled = false; 
            this.gameObject.SetActive(false);
            }
        
    
}

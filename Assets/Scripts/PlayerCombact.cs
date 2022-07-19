using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombact : MonoBehaviour
{
    public static PlayerCombact instance;
    public Animator animator;
    public Transform attackPoint;
    public Transform playerPosition;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayers;
    private InputController _inputController;
    public Collider2D[] hitEnemy;
    void Awake(){
        _inputController = new InputController();
    }
    void Start(){
    }
    void OnEnable(){
        _inputController.Enable();
    }
    void OnDisable(){
        _inputController.Disable();
    }
    void Update()
    {
        _inputController.InputAction.Attack.performed += ctx => attack();
    }
    public void PowerUpAttack()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().money>=10)
        {
        
        attackDamage=AfterDeathManager.Load().attack+1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().money-=10;
        Destroy(GameObject.FindGameObjectWithTag("PwrUpAttack"));
        }
    }


    void attack(){
        //float attackInput = _inputController.InputAction.Attack.ReadValue<float>();
        //attack animations
        animator.SetTrigger("Attack");
        SoundManagerScriptOther.PlaySound("sword");
        // detect enemies to attack
        if (animator.GetFloat("xDir")==1){
            this.hitEnemy = Physics2D.OverlapCircleAll(new Vector2 (playerPosition.position.x+attackRange,playerPosition.position.y), attackRange, enemyLayers);
            }
        if(animator.GetFloat("xDir")==-1){
            this.hitEnemy = Physics2D.OverlapCircleAll(new Vector2 (playerPosition.position.x-attackRange,playerPosition.position.y), attackRange, enemyLayers);
        }
        if(animator.GetFloat("yDir")==1){
            this.hitEnemy = Physics2D.OverlapCircleAll(new Vector2 (playerPosition.position.x,playerPosition.position.y+attackRange), attackRange, enemyLayers);
        }
        if(animator.GetFloat("yDir")==-1){
            this.hitEnemy = Physics2D.OverlapCircleAll(new Vector2 (playerPosition.position.x,playerPosition.position.y-attackRange), attackRange, enemyLayers);
        }

        foreach(Collider2D enemy in hitEnemy){
            Debug.Log("attaccato" + enemy.name);
            enemy.GetComponent<EnemyManager>().takeDamage(attackDamage);
            Instantiate(Resources.Load("SlashBlood",typeof(GameObject)),enemy.transform.position,Quaternion.Euler(0,0,Random.Range(0,360)));
        }
        //damage enemy
    }
}

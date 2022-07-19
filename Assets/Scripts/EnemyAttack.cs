using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static EnemyAttack instance;
    Transform player;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamamge = 30;
    public LayerMask playerLayer;
    [SerializeField] private float _attackSpeed = 2;
    [SerializeField] private float _canAttack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < 2){
            if (_attackSpeed <= _canAttack) {
            attack();
            _canAttack = 0f;
     }else{
        _canAttack += Time.deltaTime;
     }
        }
    }
     void attack(){
            animator.SetTrigger("Attack");
            Collider2D[] hitplayer =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
            foreach(Collider2D player in hitplayer){
                player.GetComponent<PlayerManager>().takeDamage(attackDamamge);
            }
     }

    public void defUP()
    {
        attackDamamge -= 1;
    }
}

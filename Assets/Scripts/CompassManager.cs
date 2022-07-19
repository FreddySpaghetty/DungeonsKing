using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
    Transform player;
    GameObject exit;
    Image compass;
    GameObject target;
    GameObject[] arrayOfEnemy;
    GameObject[] arrayEnemy1;
    GameObject[] arrayEnemy2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        exit = GameObject.FindGameObjectWithTag("Exit");
        compass = GameObject.FindGameObjectWithTag("Compass").GetComponent<Image>();
    }

    // Update is called once per frame
    /// <summary>
    /// 
    
    void Update()
    {
        SumListEnemy();
        whoIsTarget();
        Debug.Log(target);

        Vector3 directionTarget = player.position - target.transform.position;
        float angle = Mathf.Atan2(directionTarget.x, directionTarget.y) * Mathf.Rad2Deg;
        compass.rectTransform.rotation = Quaternion.Euler(0f,0f, -angle-180);
    } 
    void SumListEnemy(){
        arrayEnemy1 = MapManager.instance.whoIsSpawnEnemy1();
        arrayEnemy2 = MapManager.instance.whoIsSpawnEnemy2();
        arrayOfEnemy = new GameObject[arrayEnemy1.Length + arrayEnemy2.Length];

        arrayEnemy1.CopyTo(arrayOfEnemy, 0);
        arrayEnemy2.CopyTo(arrayOfEnemy, arrayEnemy1.Length);
    }
    void whoIsTarget(){
        float closestDistance = Mathf.Infinity;
        if(arrayOfEnemy.Length == 0){
            target.transform.position = new Vector3(0f,0f,0f);
        }else {
        foreach(GameObject enemy in arrayOfEnemy){
            float distance = Vector3.Distance(player.position, enemy.transform.position );
            if(distance < closestDistance){
                target = enemy;
                closestDistance = distance;
            }
        }
        }

    }
}

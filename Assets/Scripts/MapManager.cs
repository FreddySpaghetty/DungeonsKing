using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    private GameObject roomsData;
    private GameObject templates;
    public int level;
    public GameObject[] enemySpawned1;
    public GameObject[] enemySpawned2;
    public bool levelFinish=false;
    private Vector2[] positions= {new Vector2( 0, 0 )};
    public int countEnemy1=0;
    public int countEnemy2=0;
    public bool spawned=false;
    
    // Save system

    public GameObject playerManagerScript;
    public GameObject playerCombactScript;
    public GameObject scoreScript;



    //
    void Awake(){
        instance = this;
    }
    void Start()
    {
        this.level=1;
        GenerateMap(1);
        if (AfterDeathManager.Load()!=null)
        {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().maxHealth=AfterDeathManager.Load().health;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().speed=AfterDeathManager.Load().speed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombact>().attackDamage=AfterDeathManager.Load().attack;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().money=0;
        }
        else
        {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().maxHealth=100;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().speed=2f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombact>().attackDamage=20;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().money=0;
        }
    }
    public void LevelUp(){
        this.level=this.level+1;
    }
    public void ResetLevelFinish(){
        this.levelFinish=false;
    }
    public void GenerateMap(int lvl){
        roomsData=Instantiate(Resources.Load("RoomsData", typeof(GameObject))) as GameObject;
        roomsData.GetComponent<RoomsData>().Init(lvl,lvl);
        Instantiate(Resources.Load("NESW",typeof(GameObject)),new Vector2(0,0),Quaternion.identity);
        Instantiate(Resources.Load("Floor",typeof(GameObject)),new Vector2(0,0),Quaternion.identity);
        //GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().wait(5);
        Invoke("ChangeRooms",1f);
        Invoke("Spawn",2f);
        Invoke("DestroyAllSpawnPoints",1f);
        //Instantiate(Resources.Load("Floor",typeof(GameObject)),new Vector2(0,0),Quaternion.identity);
    }

    void Update()
    {
        if(this.spawned)
        CheckEnemyAlive();
    }
    void CheckEnemyAlive()
    {
        if (this.levelFinish==false)
        {
            this.enemySpawned1=GameObject.FindGameObjectsWithTag("Enemy1");
            this.countEnemy1=0;
            foreach(GameObject gameobj in this.enemySpawned1)
            {
                if(gameobj.active)
                {

                    this.countEnemy1=this.countEnemy1+1;
                }
            }
            this.enemySpawned2=GameObject.FindGameObjectsWithTag("Enemy2");
            this.countEnemy2=0;
            foreach(GameObject gameobj in this.enemySpawned2)
            {
                if(gameobj.active)
                {

                    this.countEnemy2=this.countEnemy2+1;
                }
            }
            if(this.countEnemy1 + this.countEnemy2 ==0)
            {
                print("ioDovreiInstanziare");
                Instantiate(Resources.Load("Exit",typeof(GameObject)),new Vector2(0,0),Quaternion.identity);
                this.levelFinish=true;
                this.spawned=false;
            }
        }
    }
    void DestroyAllSpawnPoints(){
            foreach(GameObject gameobj in GameObject.FindGameObjectsWithTag("SpawnPoint"))
            {
                Destroy(gameobj);
            }
    }

    void ChangeRooms()
    {
        this.roomsData.GetComponent<RoomsData>().ChangeRoom();
    }
    void Spawn()
    {
        for (int x=0 ; x<roomsData.GetComponent<RoomsData>().positions.Count;x++ )
        this.roomsData.GetComponent<RoomsData>().SpawnStuffs(roomsData.GetComponent<RoomsData>().positions[x],GameObject.FindGameObjectWithTag("Templates").GetComponent<Templates>().randomFloorTile,20);
        for (int x=0 ; x<roomsData.GetComponent<RoomsData>().positions.Count;x++ )
        this.roomsData.GetComponent<RoomsData>().SpawnStuffsNoRotation(roomsData.GetComponent<RoomsData>().positions[x],GameObject.FindGameObjectWithTag("Templates").GetComponent<Templates>().enemyArray,5);
        this.spawned=true;
        for (int x=0 ; x<roomsData.GetComponent<RoomsData>().positions.Count;x++ )
        this.roomsData.GetComponent<RoomsData>().SpawnStuffsNoRotation(roomsData.GetComponent<RoomsData>().positions[x],GameObject.FindGameObjectWithTag("Templates").GetComponent<Templates>().powerUp,10);
    }
    public int countFinaleKill(){
        return countEnemy1 + countEnemy2;
    }
    public GameObject[] whoIsSpawnEnemy1(){
        return enemySpawned1;
    }
     public GameObject[] whoIsSpawnEnemy2(){
        return enemySpawned2;
    }
}

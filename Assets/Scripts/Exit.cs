using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject mapManager;
    private int actualLevel;
    private GameObject[] RoomsData;
    private GameObject[] Wall;
    private GameObject[] Floor;

    private GameObject[] FloorRandomTile;

    private GameObject[] Enemy1;

    private GameObject[] Soda;

    private GameObject[] Money;

    private GameObject[] Life;

    private GameObject[] SlashBlood;





    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {


        Destroy(gameObject);
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Exit"));
        }
    }
    void OnDestroy() {
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("RoomsData"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Wall"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Floor"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("FloorRandomTile"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Enemy1"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Soda"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Money"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Food"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("Life"));
        DestroyObjectInArray(GameObject.FindGameObjectsWithTag("SlashBlood"));

        GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().LevelUp();
        actualLevel=GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().level;
        GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().ResetLevelFinish();
        GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().GenerateMap(actualLevel);
    }
    void DestroyObjectInArray( GameObject[] goArray )
    {
        foreach( GameObject obj in goArray )
        {
            Destroy(obj);
        }
    }
    void wait( )
    {
    }

}

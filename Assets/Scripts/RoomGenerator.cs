using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    /*
    //private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private GameObject tmp;
    private Vector2[] takenPosition;
    private int otherSpawnRoomDoor;
    */
    private Templates templates;
    public int spawnDirection;
    private bool spawned = false;
    void Start(){
        templates = GameObject.FindGameObjectWithTag("Templates").GetComponent<Templates>();
        Invoke("Spawn",0.2f);
    }


    void Spawn()
    {
        if(spawned==false)
        {

            if( spawnDirection==1 && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().xlimit>=Mathf.Abs(transform.position.x)) && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().ylimit>=Mathf.Abs(transform.position.y)))
            {   print("N");
                int rand=Random.Range(0,templates.nordRooms.Length);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().intantiateRoom(templates.nordRooms[rand],transform.position);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCount();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCountBot();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsPosition(transform.position);
                GameObject.Instantiate(Resources.Load("Floor",typeof(GameObject)),new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
            }

            else if ( spawnDirection==2 && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().xlimit>=Mathf.Abs(transform.position.x)) && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().ylimit>=Mathf.Abs(transform.position.y)))
            {   print("E");
                int rand=Random.Range(0,templates.eastRooms.Length);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().intantiateRoom(templates.eastRooms[rand],transform.position);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCount();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCountTop();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsPosition(transform.position);
                GameObject.Instantiate(Resources.Load("Floor",typeof(GameObject)),new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
            }

            else if ( spawnDirection==3 && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().xlimit>=Mathf.Abs(transform.position.x)) && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().ylimit>=Mathf.Abs(transform.position.y)))
            {   print("S");
                int rand=Random.Range(0,templates.southRooms.Length);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().intantiateRoom(templates.southRooms[rand],transform.position);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCount();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCountLeft();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsPosition(transform.position);
                GameObject.Instantiate(Resources.Load("Floor",typeof(GameObject)),new Vector2(transform.position.x,transform.position.y),Quaternion.identity);

            }
            else if ( spawnDirection==4 && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().xlimit>=Mathf.Abs(transform.position.x)) && (GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().ylimit>=Mathf.Abs(transform.position.y)))
            {   print("W");
                int rand=Random.Range(0,templates.westRooms.Length);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().intantiateRoom(templates.westRooms[rand],transform.position);
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCount();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsCountRight();
                GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().addRoomsPosition(transform.position);
                GameObject.Instantiate(Resources.Load("Floor",typeof(GameObject)),new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
            }
            spawned=true;
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}

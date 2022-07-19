using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsData : MonoBehaviour
{
    //public Vector2[] positions= {new Vector2( 0, 0 )};
    public List<Vector2> positions = new List<Vector2>();
    [SerializeField] public List<int[]> needDoors = new List<int[]>();
    public List<string> roomName = new List<string>();
    public List<GameObject> roomsArray;
    public List<int[]> roomsDoors = new List<int[]>();
    public List<GameObject> enemyArray;

    public int roomsCount=0;
    public int roomsCountTop;
    public int roomsCountRight;
    public int roomsCountBot;
    public int roomsCountLeft;
    public int xlimit;
    public int ylimit;
    public bool stopGeneration=false;
    public int spawnedEnemyNumber;

    public void Init(int xlimit, int ylimit){
        this.xlimit=xlimit*10;
        this.ylimit=ylimit*10;
    }

    IEnumerator WaitDummyCoroutine(int seconds)
    {

        yield return new WaitForSeconds(seconds);

    }
    public void wait(int seconds){
        StartCoroutine(WaitDummyCoroutine(seconds));
    }


    //RIPARTIRE DA QUI

    public void ChangeRoom()
    {   this.wait(3);
        print("QUIIIIIIchangeroomInRoomsData");
        print(this.positions.Count);
        for (int i = 0; i < this.positions.Count; i++)
        {
            
            //StartCoroutine(WaitDummyCoroutine());
            this.needDoors.Insert(i,new int[4] { 0, 0, 0, 0 });
            
            if(!(this.positions.IndexOf(new Vector2(this.positions[i].x, this.positions[i].y+10))==-1))
            if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[i].x, this.positions[i].y+10))].Contains("S"))
                
                    this.needDoors[i][0]=1;
            
            if(!(this.positions.IndexOf(new Vector2(this.positions[i].x+10, this.positions[i].y))==-1))
            if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[i].x+10, this.positions[i].y))].Contains("W"))
                
                    this.needDoors[i][1]=1;
            
            if(!(this.positions.IndexOf(new Vector2(this.positions[i].x, this.positions[i].y-10))==-1))
            if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[i].x, this.positions[i].y-10))].Contains("N"))

                    this.needDoors[i][2]=1;

            if(!(this.positions.IndexOf(new Vector2(this.positions[i].x-10, this.positions[i].y))==-1))
            if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[i].x-10, this.positions[i].y))].Contains("E"))

                    this.needDoors[i][3]=1;
        }

/*
        this.needDoors[this.positions.IndexOf(new Vector2(0, 10))][2]=1;
        this.needDoors[this.positions.IndexOf(new Vector2(10, 0))][3]=1;
        this.needDoors[this.positions.IndexOf(new Vector2(0, -10))][0]=1;
        this.needDoors[this.positions.IndexOf(new Vector2(-10, 0))][1]=1;
*/





    for (int i = 0; i < this.positions.Count; i++)
        {   
/*             print("position "+ i);
            print(this.needDoors[i][0]);
            print(this.needDoors[i][1]);
            print(this.needDoors[i][2]);
            print(this.needDoors[i][3]);
            print("end \n"); */
            if(this.positions[i]==new Vector2(0, 10)){this.needDoors[i][2]=1;}
            if(this.positions[i]==new Vector2(10, 0)){this.needDoors[i][3]=1;}
            if(this.positions[i]==new Vector2(0, -10)){this.needDoors[i][0]=1;}
            if(this.positions[i]==new Vector2(-10, 0)){this.needDoors[i][1]=1;}

            if(this.needDoors[i][0]==1 && this.needDoors[i][1]==0 && this.needDoors[i][2]==0 && this.needDoors[i][3]==0)
            {
                
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="N";
                this.roomsDoors[i]=this.needDoors[i];
            }
            else if(this.needDoors[i][0]==0 && this.needDoors[i][1]==1 && this.needDoors[i][2]==0 && this.needDoors[i][3]==0)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("ENoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="E";
                this.roomsDoors[i]=this.needDoors[i];
            }
            else if(this.needDoors[i][0]==0 && this.needDoors[i][1]==0 && this.needDoors[i][2]==1 && this.needDoors[i][3]==0)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("SNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="S";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==0 && this.needDoors[i][1]==0 && this.needDoors[i][2]==0 && this.needDoors[i][3]==1)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("WNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="W";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==1 && this.needDoors[i][1]==1 && this.needDoors[i][2]==0 && this.needDoors[i][3]==0)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NENoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="NE";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==0 && this.needDoors[i][1]==1 && this.needDoors[i][2]==1 && this.needDoors[i][3]==0)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("ESNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="ES";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==0 && this.needDoors[i][1]==0 && this.needDoors[i][2]==1 && this.needDoors[i][3]==1)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("SWNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="SW";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==1 && this.needDoors[i][1]==0 && this.needDoors[i][2]==0 && this.needDoors[i][3]==1)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NWNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="NW";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==1 && this.needDoors[i][1]==0 && this.needDoors[i][2]==1 && this.needDoors[i][3]==0)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NSNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="NS";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==0 && this.needDoors[i][1]==1 && this.needDoors[i][2]==0 && this.needDoors[i][3]==1)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("EWNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="EW";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==1 && this.needDoors[i][1]==1 && this.needDoors[i][2]==1 && this.needDoors[i][3]==0)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NESNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="NES";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==0 && this.needDoors[i][1]==1 && this.needDoors[i][2]==1 && this.needDoors[i][3]==1)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("ESWNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="ESW";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            else if(this.needDoors[i][0]==1 && this.needDoors[i][1]==0 && this.needDoors[i][2]==1 && this.needDoors[i][3]==1)
            {
                  Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NSWNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="NSW";
                this.roomsDoors[i]=this.needDoors[i];
            }
            else if(this.needDoors[i][0]==1 && this.needDoors[i][1]==1 && this.needDoors[i][2]==0 && this.needDoors[i][3]==1)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NEWNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="NEW";
                this.roomsDoors[i]=this.needDoors[i];
            }
            else if(this.needDoors[i][0]==1 && this.needDoors[i][1]==1 && this.needDoors[i][2]==1 && this.needDoors[i][3]==1)
            {
                Destroy(this.roomsArray[i].gameObject);
                this.roomsArray.Remove(this.roomsArray[i]);
                this.roomsArray.Insert(i,Instantiate(Resources.Load("NESWNoSpawn",typeof(GameObject)),new Vector2(this.positions[i].x,this.positions[i].y),Quaternion.identity) as GameObject);
                this.roomName[i]="NESW";
                this.roomsDoors[i]=this.needDoors[i];
            }            
            



            for (int q = 0; q < this.positions.Count; q++)
            {

                this.needDoors[q][0]=0;
                this.needDoors[q][1]=0;
                this.needDoors[q][2]=0;
                this.needDoors[q][3]=0;


                if(!(this.positions.IndexOf(new Vector2(this.positions[q].x, this.positions[q].y+10))==-1))
                if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[q].x, this.positions[q].y+10))].Contains("S"))

                        this.needDoors[q][0]=1;

                if(!(this.positions.IndexOf(new Vector2(this.positions[q].x+10, this.positions[q].y))==-1))
                if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[q].x+10, this.positions[q].y))].Contains("W"))

                        this.needDoors[q][1]=1;

                if(!(this.positions.IndexOf(new Vector2(this.positions[q].x, this.positions[q].y-10))==-1))
                if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[q].x, this.positions[q].y-10))].Contains("N"))

                        this.needDoors[q][2]=1;

                if(!(this.positions.IndexOf(new Vector2(this.positions[q].x-10, this.positions[q].y))==-1))
                if(this.roomName[this.positions.IndexOf(new Vector2(this.positions[q].x-10, this.positions[q].y))].Contains("E"))

                        this.needDoors[q][3]=1;
                if(this.positions[q]==new Vector2(0, 10)){this.needDoors[q][2]=1;}
                if(this.positions[q]==new Vector2(10, 0)){this.needDoors[q][3]=1;}
                if(this.positions[q]==new Vector2(0, -10)){this.needDoors[q][0]=1;}
                if(this.positions[q]==new Vector2(-10, 0)){this.needDoors[q][1]=1;}
            }
        }
    }

    public void CleanObject(GameObject parentObject){

        for (var z = parentObject.transform.childCount - 1; z >= 0; z--)
            {
                while (parentObject.transform.childCount > 0)
                {
                    foreach (Transform child in parentObject.transform)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
    }
    public void SpawnEnemy(){


        this.wait(3);
        
        print("Sono dentro a Spawn");
        GameObject[] enemyTemplateArray=GameObject.FindGameObjectWithTag("Templates").GetComponent<Templates>().randomFloorTile;
        print("COUNTSPAWN"+GameObject.FindGameObjectWithTag("RoomsData").GetComponent<RoomsData>().positions.Count);
        for(int i=0; i<4;i++){
        int spawnPosition=Random.Range(0,1);
//        print("x "+this.positions[spawnPosition].x+"      y "+ this.positions[spawnPosition].y);
        Vector2 positionNE3 = new Vector2(this.positions[i].x+3+Random.Range(-0.2f,0.2f),this.positions[i].y+3+Random.Range(-0.2f,0.2f));
        Vector2 positionES3 = new Vector2(this.positions[i].x+3+Random.Range(-0.2f,0.2f),this.positions[i].y-3+Random.Range(-0.2f,0.2f));
        Vector2 positionSW3 = new Vector2(this.positions[i].x-3+Random.Range(-0.2f,0.2f),this.positions[i].y-3+Random.Range(-0.2f,0.2f));
        Vector2 positionWN3 = new Vector2(this.positions[i].x-3+Random.Range(-0.2f,0.2f),this.positions[i].y+3+Random.Range(-0.2f,0.2f));

        Vector2 positionNE2 = new Vector2(this.positions[i].x+2+Random.Range(-0.2f,0.2f),this.positions[i].y+2+Random.Range(-0.2f,0.2f));
        Vector2 positionES2 = new Vector2(this.positions[i].x+2+Random.Range(-0.2f,0.2f),this.positions[i].y-2+Random.Range(-0.2f,0.2f));
        Vector2 positionSW2 = new Vector2(this.positions[i].x-2+Random.Range(-0.2f,0.2f),this.positions[i].y-2+Random.Range(-0.2f,0.2f));
        Vector2 positionWN2 = new Vector2(this.positions[i].x-2+Random.Range(-0.2f,0.2f),this.positions[i].y+2+Random.Range(-0.2f,0.2f));

        Vector2 positionNE1 = new Vector2(this.positions[i].x+1+Random.Range(-0.2f,0.2f),this.positions[i].y+1+Random.Range(-0.2f,0.2f));
        Vector2 positionES1 = new Vector2(this.positions[i].x+1+Random.Range(-0.2f,0.2f),this.positions[i].y-1+Random.Range(-0.2f,0.2f));
        Vector2 positionSW1 = new Vector2(this.positions[i].x-1+Random.Range(-0.2f,0.2f),this.positions[i].y-1+Random.Range(-0.2f,0.2f));
        Vector2 positionWN1 = new Vector2(this.positions[i].x-1+Random.Range(-0.2f,0.2f),this.positions[i].y+1+Random.Range(-0.2f,0.2f));

        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionNE1,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionES1,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionSW1,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionWN1,Quaternion.Euler(0,0,Random.Range(0,360)));}


        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionNE2,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionES2,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionSW2,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionWN2,Quaternion.Euler(0,0,Random.Range(0,360)));}


        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionNE3,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionES3,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionSW3,Quaternion.Euler(0,0,Random.Range(0,360)));}
        if (Random.Range(0,100)>80){Instantiate(enemyTemplateArray[Random.Range(0,enemyTemplateArray.Length)],positionWN3,Quaternion.Euler(0,0,Random.Range(0,360)));}

        }

    }
    public void SpawnStuffs(Vector2 roomCenterPosition, GameObject[] objArray, int spawnPercentage)
    {
        this.wait(3);
        for (int n=-3;n<4;n++)
        {
            for(int m=-3;m<4;m++)
            {
                if (Random.Range(0,100)>100-spawnPercentage)
                {
                    Instantiate(objArray[Random.Range(0,objArray.Length)],new Vector2(roomCenterPosition.x+n+Random.Range(-0.2f,0.2f),roomCenterPosition.y+m+Random.Range(-0.2f,0.2f)),Quaternion.Euler(0,0,Random.Range(0,360)));
                }
            }
        }
    }
    public void SpawnStuffsNoRotation(Vector2 roomCenterPosition, GameObject[] objArray, int spawnPercentage)
    {
        this.wait(3);
        for (int n=-3;n<4;n++)
        {
            for(int m=-3;m<4;m++)
            {
                if (Random.Range(0,100)>100-spawnPercentage)
                {
                    Instantiate(objArray[Random.Range(0,objArray.Length)],new Vector2(roomCenterPosition.x+n+Random.Range(-0.2f,0.2f),roomCenterPosition.y+m+Random.Range(-0.2f,0.2f)),Quaternion.identity);
                }
            }
        }
    }




    public void intantiateRoom(GameObject room ,Vector2 position){

        this.roomsArray.Add(GameObject.Instantiate(room, position, Quaternion.identity));
        this.roomName.Add(roomsArray[roomsCount].name.Split("(")[0]);
        this.roomsArray[roomsCount].SetActive(true);
        this.roomsDoors.Add(new int[4] { 0, 0, 0, 0 });

        if (this.roomName[roomsCount].Contains("N")){
            roomsDoors[roomsCount][0]=1;
        }
        if (this.roomName[roomsCount].Contains("E")){
            roomsDoors[roomsCount][1]=1;
        }
        if (this.roomName[roomsCount].Contains("S")){
            roomsDoors[roomsCount][2]=1;
        }
        if (this.roomName[roomsCount].Contains("W")){
            roomsDoors[roomsCount][3]=1;
        }
    }

    public void addRoomsCount(){
        this.roomsCount=this.roomsCount+1;
    }
    public void addRoomsCountTop(){
        this.roomsCountTop=this.roomsCountTop+1;
    }
    public void addRoomsCountRight(){
        this.roomsCountRight=this.roomsCountRight+1;
    }
    public void addRoomsCountBot(){
        this.roomsCountBot=this.roomsCountBot+1;
    }
    public void addRoomsCountLeft(){
        this.roomsCountLeft=this.roomsCountLeft+1;
    }
    
    public void addRoomsPosition(Vector2 position){
        
        this.positions.Add(new Vector2( position.x, position.y));
    }
}


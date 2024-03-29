﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{

    public GameObject Hazards;                              //The Hazard prefab to eb spawned.
    public Transform[] SpawnLocations;                      //An array of locations the hazard can spawn from.
    public float spawnTime = 3f;                            //How Long Between each Spawn.
    public float spawnTimer = 0f;
    public WallScroll ws;

    public GameObject HazardLeft;
    public GameObject HazardRight;

    public float distanceToSpawn;
    public float last;
    private float timeStart;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
        //continuosly call the spawn location after the spawnTime has finished counting and then repeats itself.
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Update()
    {

       
        if ( (int)(ws.distance * (20 * 16) / 16) % distanceToSpawn == 0 && (int) (ws.distance * (20 * 16) / 16) != last)
        {
            //Debug.Log(" sdfg");
            Spawn();
        }
        last = (int)(ws.distance * (20 * 16) / 16);
    }

    public void Spawn()
    {
        ////Find a random index between zero and on less than the number of spawn points.
        //int spawnPointIndex = Random.Range(0, SpawnLocations.Length);


        ////Creates an instance of the hazard prefab at a randomly selected spawn point and rotation.
        //Instantiate(Hazards, SpawnLocations[spawnPointIndex].position, SpawnLocations[spawnPointIndex].rotation);



        int randomSpawnIndex = Random.Range(0, 2);

        if(randomSpawnIndex == 0 )
        {
         GameObject g = Instantiate(HazardLeft, SpawnLocations[0].position, SpawnLocations[0].rotation)as GameObject;
            g.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PalletteController.currentColor;
            g.transform.GetChild(1).GetComponent<SpriteRenderer>().color = PalletteController.currentColor;
            //Debug.Log("Spawning on the left " + randomSpawnIndex);
        }
        else if (randomSpawnIndex == 1)
        {
           GameObject g = Instantiate(HazardRight, SpawnLocations[1].position, SpawnLocations[1].rotation) as GameObject;
            g.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PalletteController.currentColor;
            g.transform.GetChild(1).GetComponent<SpriteRenderer>().color = PalletteController.currentColor;
            //Debug.Log("Spawning on the right " + randomSpawnIndex);
        }
    }



}

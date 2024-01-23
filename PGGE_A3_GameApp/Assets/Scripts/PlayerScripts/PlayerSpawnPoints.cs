using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoints : MonoBehaviour
{
    public List<Transform> mSpawnPoints = new List<Transform>(); //makes a new list of coordinates (transform type) for spawn points

    public Transform GetSpawnPoint()
    {
        if (mSpawnPoints.Count == 0) //checks if the list of spawn points is empty, if empty uses transform of the current object
        {
            return transform; //(refactor comment: "this." is redundant because GetSpawnPoint, like GetComponent, already explicitly refers to the current instance)
        }
        return mSpawnPoints[Random.Range(0, mSpawnPoints.Count)]; //returns a random transform/point from the list above (refactor comment: ".transform" removed as the transform is already being returned above)
    }
}

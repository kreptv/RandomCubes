/***
 * Created by: Haley Kelly
 * Date Created: Jan 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 26, 2022
 * 
 * Description: Spawn multiple cube prefabs into the scene.
 ***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; // new GameObject
    public float scalingFactor = 0.95f; // amount each cube will shrink each frame
    public int numberOfCubes = 0; // current number of cubes

    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all of the cubes




    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); // creates the list
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; // add to number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); // creates cube instance

        gObj.name = "Cube" + numberOfCubes; // name of cube instance
        

        gObj.transform.position = Random.insideUnitSphere; // random location inside a sphere of radius 1 from 0, 0, 0

        gameObjectList.Add(gObj); // add to list

        List<GameObject> removeList = new List<GameObject>(); // list for removed objects

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; // records current scale
            scale *= scalingFactor; // scale multiplied by scale factor
            goTemp.transform.localScale = Vector3.one * scale; // transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            } // end if
        } // end foreach

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // remove from game object list
            Destroy(goTemp); // destroys game object
           // Debug.Log();
        } // end foreach
        
    }
}

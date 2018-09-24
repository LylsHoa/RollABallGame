using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoadData : MonoBehaviour
{
    //When SaveLoadData script is on any object --> written variable will stay the same on all scripts w/ SaveLoadData
    public static SaveLoadData Instance;

    //Starts Scene 1 carry on --> next scene
    public float Score = 0;
    public float timer = 0;

    void Awake()
    {
        if (Instance == null)
        {
            //DO NOT DESTROY WHEN LOAD ON TO NEW SCENE. (Will persist through all scenes)
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } 
        
        //Destroys 2nd game manager 
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // keep increasing time until ___
        timer += Time.deltaTime;
        
    }
}

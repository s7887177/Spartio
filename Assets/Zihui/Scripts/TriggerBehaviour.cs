using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject missionManager;
    
    void Start()
    {
        missionManager= GameObject.Find("MissionManager");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        CheckMission(other);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckMission(Collider other)
    {
        Debug.Log(this.GetComponent<Flowchart>().GetVariable("selfID")) ;
        Debug.Log(this.GetComponent<Flowchart>().GetVariable("missionID"));
    }
}

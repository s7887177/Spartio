using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionSystemTest : MonoBehaviour
{
    MissionScheduler scheduler;
    Mission mission1;
    Mission mission2;
    [SerializeField]GameObject missionArea;
    [SerializeField] TMP_Text tmp_pref;
    [SerializeField] TMP_Text time;
    [SerializeField] float totalTime=1;

    void Start()
    {
        scheduler = new MissionScheduler();
        scheduler.Init();
        mission1 = new Mission("mission1",0,"test mission 1",3);
        mission2 = new Mission("mission2", 1, "test mission 2", 10);
        scheduler.AddMission(0, mission1);
    }

    
    void Update()
    {
        totalTime += Time.deltaTime;
        scheduler.Update();
        Debug.Log(scheduler.elements.Count);
        if(totalTime>=1)
        {
            totalTime = 0;
            for(int i = 0;i<missionArea.transform.childCount;i++)
            {
                Destroy(missionArea.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < scheduler.elements.Count; i++) 
            {
                Spawner(scheduler.elements[i]);
            }
        }
        time.text = scheduler.currentExecuteTime.ToString();
    }
    void Spawner(SchedulerElement mission)
    {
        TMP_Text tmp_text=tmp_pref;
        tmp_pref.text = $"mission name:{mission.MissionId} ,mission starting time :{mission.startingTime}, mission ending time:{mission.endingTime}";
        Instantiate(tmp_text,missionArea.transform);

    }
    public void ButtonOnClick()
    {
        scheduler.AddMission(scheduler.currentExecuteTime, mission2);
        totalTime = 1;
    }
}

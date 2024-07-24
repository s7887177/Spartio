using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum MissionStatus{Running,Success,Fail};
public struct SchedulerElement
{
    private readonly int _missionId;
    private float _startingTime;
    private float _endingTime;
    private MissionStatus _missionResult;

    public SchedulerElement(int missionId,float startingTime, float endingTime)
    {
        this._missionId = missionId;
        this._startingTime = startingTime;
        this._endingTime = endingTime;
        this._missionResult = MissionStatus.Running;
    }

    public float startingTime
    {
        get { return _startingTime; }
        set { _startingTime = value; }
    }
    public float endingTime
    {
        get { return _endingTime; }
        set { _endingTime = value; }
    }
    public MissionStatus missionResult
    {
        get { return  _missionResult; }
        set { _missionResult = value; }
    }

    public int MissionId => _missionId;
}
public class MissionScheduler
{
    public readonly List<SchedulerElement> elements=new List<SchedulerElement>();
    public float currentExecuteTime = 0;
    public void Init()
    {
        elements.Clear();
        currentExecuteTime = 0;
    }
    public void Update()
    {
        currentExecuteTime += Time.deltaTime;
        ExecuteMission();
    }

    public void AddMission(float startingTime,Mission mission)
    {
        float endingTime = startingTime + mission.duration;
        SchedulerElement element = new SchedulerElement(mission.id,startingTime, endingTime);
        elements.Add(element);
    }

    public void ExecuteMission()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].endingTime <= currentExecuteTime)
            {
                var mission = elements[i];
                mission.missionResult = MissionStatus.Fail;
                elements[i]=mission;
                elements.Remove(elements[i]);
                break;
            }
        }
    }

    
}

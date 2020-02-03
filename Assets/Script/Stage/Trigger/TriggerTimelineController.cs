using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TriggerTimelineController : MonoBehaviour
{
    public PlayerController player;
    public List<PlayableDirector> playableList;
    public List<TimelineAsset> timelineList;
    bool canPlayerMove;

    public void ReceivedTargetBool(bool canPlayerMove)
    {
        this.canPlayerMove = canPlayerMove;
    }

    public void PlayTimeline(int index)
    {
        player.enabled = canPlayerMove;
        playableList[index].Play(timelineList[index]);
        //if(timeline finish) player.enabled = true;
    }
}

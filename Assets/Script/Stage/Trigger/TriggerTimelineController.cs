using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TriggerTimelineController : MonoBehaviour
{
    public PlayerController2D player;
    public List<PlayableDirector> playableList;
    bool canPlayerMove;

    public void ReceivedTargetBool(bool canPlayerMove)
    {
        this.canPlayerMove = canPlayerMove;
    }

    public void PlayTimeline(int index)
    {
        player.enabled = canPlayerMove;
        playableList[index].Play();
        //if(timeline finish) player.enabled = true;
    }

}

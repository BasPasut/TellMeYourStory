using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TriggerTimelineController : MonoBehaviour
{
    public OVRPlayerController player;
    public PlayableDirector director;
    public List<TimelineAsset> playableList;

    public void PlayTimeline(int index)
    {
        director.Play(playableList[index]);
    }

}

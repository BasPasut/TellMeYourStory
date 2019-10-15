using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public Heartrate bpmSource;
    LineRenderer line;
    int index = 1;
    float moveX;
    int positionCount = 1;
    public float y;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        line.SetPosition(0, new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //int bpm = bpmSource.GetIntBPM();
        positionCount++;
        Vector2 position = new Vector2(moveX, y);
        line.positionCount = positionCount;
        line.SetPosition(index++, position);
        moveX += 10;
    }
}

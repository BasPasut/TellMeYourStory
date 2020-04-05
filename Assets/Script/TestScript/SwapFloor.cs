using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapFloor : MonoBehaviour
{
    public GameObject firstFloor;
    public GameObject secondFloor;
    public GameObject underGround;
    public Collider swapCol;
    public Collider basementCol;
    public Collider openFirstFloor;
    public bool isFirstFloorActive = true;
    public bool isSecondFloorActive = false;
    public bool isUnderGroundActive = false;

    private void Awake()
    {
        firstFloor.SetActive(true);
        secondFloor.SetActive(false);
        underGround.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(swapCol) && isFirstFloorActive == true)
        {
            OpenSecondFloor();
        }
        else if (other.Equals(swapCol) && isFirstFloorActive == false && isSecondFloorActive == true)
        {
            OpenFirstFloor();
        }
        else if (other.Equals(basementCol) && isFirstFloorActive == true)
        {
            OpenUnderground();
        }
        else if (other.Equals(openFirstFloor) && isFirstFloorActive == false)
        {
            OpenFirstFloor();
        }
    }

    public void OpenFirstFloor()
    {
        firstFloor.SetActive(true);
        secondFloor.SetActive(false);
        underGround.SetActive(false);
        isFirstFloorActive = true;
        isSecondFloorActive = false;
        isUnderGroundActive = false;
    }

    public void OpenSecondFloor()
    {
        firstFloor.SetActive(false);
        secondFloor.SetActive(true);
        underGround.SetActive(false);
        isFirstFloorActive = false;
        isSecondFloorActive = true;
        isUnderGroundActive = false;
    }

    public void OpenUnderground()
    {
        firstFloor.SetActive(false);
        secondFloor.SetActive(false);
        underGround.SetActive(true);
        isFirstFloorActive = false;
        isSecondFloorActive = false;
        isUnderGroundActive = true;
    }

    public void CloseMansion()
    {
        firstFloor.SetActive(false);
        secondFloor.SetActive(false);
        underGround.SetActive(false);
    }
}

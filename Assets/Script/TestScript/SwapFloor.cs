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
        if (other.Equals(swapCol) && isFirstFloorActive == true && isSecondFloorActive == false)
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

    public void OpenUnderground()
    {
        underGround.SetActive(true);
        firstFloor.SetActive(false);
        secondFloor.SetActive(false);
        isFirstFloorActive = false;
    }

    public void OpenFirstFloor()
    {
        firstFloor.SetActive(true);
        isSecondFloorActive = false;
        secondFloor.SetActive(false);
        isFirstFloorActive = true;
        underGround.SetActive(false);
    }

    public void OpenSecondFloor()
    {
        secondFloor.SetActive(true);
        isSecondFloorActive = true;
        firstFloor.SetActive(false);
        isFirstFloorActive = false;
        underGround.SetActive(false);
    }

    public void CloseMansion()
    {
        firstFloor.SetActive(false);
        secondFloor.SetActive(false);
        underGround.SetActive(false);
    }
}

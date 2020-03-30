using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapFloor : MonoBehaviour
{
    public GameObject firstFloor;
    public GameObject secondFloor;
    public GameObject underGround;
    public Collider swapCol;
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
            secondFloor.SetActive(true);
            isSecondFloorActive = true;
            firstFloor.SetActive(false);
            isFirstFloorActive = false;
        }
        else if (other.Equals(swapCol) && isFirstFloorActive == false && isSecondFloorActive == true)
        {
            firstFloor.SetActive(true);
            isSecondFloorActive = false;
            secondFloor.SetActive(false);
            isFirstFloorActive = true;
        }
    }
}

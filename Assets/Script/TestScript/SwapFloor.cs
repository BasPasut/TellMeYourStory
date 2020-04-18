using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapFloor : MonoBehaviour
{
    public GameObject firstFloor;
    public GameObject secondFloor;
    public GameObject underGround;
    public Collider secondToFirstCol;
    public Collider firstToSecondCol;
    public Collider basementCol;
    public Collider openFirstFloor;
    public bool isFirstFloorActive = true;
    public bool isSecondFloorActive = false;
    public bool isUnderGroundActive = false;
    public Transform firstFloorSwapPoint;
    public Transform secondFloorSwapPoint;
    public GameObject firstFloorPartition;
    public Transform playerWaitingRoom;
    public Camera playerCamera;

    private void Start()
    {
        firstFloor.SetActive(true);
        secondFloor.SetActive(false);
        underGround.SetActive(false);
        firstFloorPartition.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(firstToSecondCol) && isFirstFloorActive == true)
        {
            ScenarioManager.Instance.player.transform.position = playerWaitingRoom.position;
            playerCamera.transform.rotation = playerWaitingRoom.rotation;
            OpenSecondFloor();
            StartCoroutine(GoToSecondFloor());
        }
        else if (other.Equals(secondToFirstCol) && isSecondFloorActive == true)
        {
            ScenarioManager.Instance.player.transform.position = playerWaitingRoom.position;
            playerCamera.transform.rotation = playerWaitingRoom.rotation;
            OpenFirstFloor();
            StartCoroutine(GoTOFirstFloor());
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

    IEnumerator GoTOFirstFloor()
    {
        yield return new WaitForSeconds(3);
        ScenarioManager.Instance.player.transform.position = firstFloorSwapPoint.position;
        playerCamera.transform.rotation = playerWaitingRoom.rotation;
        firstFloorPartition.SetActive(false);
    }

    IEnumerator GoToSecondFloor()
    {
        yield return new WaitForSeconds(3);
        ScenarioManager.Instance.player.transform.position = secondFloorSwapPoint.position;
        playerCamera.transform.rotation = playerWaitingRoom.rotation;
        firstFloorPartition.SetActive(true);
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

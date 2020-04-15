using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<GameManager>("GameManager"));
            }
            return _instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
        SoundManager.Initialize();
        currentPlayerReport = new PlayerDataReport();
    }

    public void ResetGameManager()
    {
        Destroy(this);
    }

    public SoundAudioClip[] SoundAudioClips;
    public PlayerDataReport currentPlayerReport;

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }

    public class PlayerDataReport
    {
        public string playerName;
        public string playerAge;
        public string playerGender;
        public string status;
        public int avgHR;
        public int maxHR;
        public int minHR;
        public int maxHRatP1;
        public int maxHRatP2;
        public int maxHRatP3;
        public int maxHRatP4;
        public int maxHRatP5;
        public int maxHRatP6;

        public void SetPlayerBasicInform(string playerName, string playerAge, string playerGender)
        {
            this.playerName = playerName;
            this.playerAge = playerAge;
            this.playerGender = playerGender;
        }  
    }
}

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
        SoundManager.Initialize();
    }

    public SoundAudioClip[] SoundAudioClips;

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }
}

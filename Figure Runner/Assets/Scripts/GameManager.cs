using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameStart = false;
    public static GameManager instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    GameObject _playerController;

    //private bool isDanceSound;
    private bool isSoundPlay;
    private void Awake()
    {
      instance = this;
    }
    void Start()
    {
      _playerController = GameObject.FindGameObjectWithTag("Player");
      audioSource = GetComponent<AudioSource>();
      isSoundPlay = true;
      //isDanceSound = true;
    }
    void Update()
    {
        IsGameStart();
    }
    public void IsGameStart()
    {
        if (Input.GetMouseButtonDown(0) && isSoundPlay == true)
        {
            isSoundPlay = false;
            gameStart = true;
            audioSource.Play();
        }
    }
    public void IsDanceSound()
    {
       //  audioSource.PlayOneShot(audioClip[0]);
       audioSource.Stop();
       audioSource.PlayOneShot(audioClip);
    }
}

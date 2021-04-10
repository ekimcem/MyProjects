using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishOne : MonoBehaviour
{
    [SerializeField] private GameObject _confetti;
    [SerializeField] private GameObject _confettiTwo;

    private GameObject _playerTwo;
    void Start()
    {
      _playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            _confetti.SetActive(true);
            _confettiTwo.SetActive(true);
            GameManager.instance.IsDanceSound();
            _playerTwo.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("isDance", true);
        }
    }
}

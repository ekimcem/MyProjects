using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTwo : MonoBehaviour
{
    [SerializeField] private GameObject _confetti;
    [SerializeField] private GameObject _confettiTwo;

    Animator twoAnim;
    Animator threeAnim;

    private GameObject playerTwo;
    private GameObject playerThreee;
    void Start()
    {
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
        playerThreee = GameObject.FindGameObjectWithTag("PlayerTwo");
        twoAnim = playerTwo.gameObject.GetComponentInChildren<Animator>();
        threeAnim=  playerThreee.gameObject.GetComponentInChildren<Animator>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        { 
            _confetti.SetActive(true);
            _confettiTwo.SetActive(true);
        }
    }
}

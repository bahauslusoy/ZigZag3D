using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    enum State
    {
        preGame,
        inGame,
        failGame,
        successGame,
    }
    [SerializeField] private BallDataTransmitter ballDataTransmitter;
    [SerializeField] private float ballMoveSpeed;
    private State currentState;

    [SerializeField] private GameObject startPanel, failPanel;
    public TextMeshProUGUI _text;
    private int inputCount;


    void Start()
    {
        startPanel.SetActive(true);
        currentState = State.preGame;
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case State.preGame:
                if (Input.GetMouseButtonDown(0))
                {
                    startPanel.SetActive(false);


                    currentState = State.inGame;
                }

                break;

            case State.inGame:
                SetBallMove();
                InputCount();

                break;

            case State.failGame:

                failPanel.SetActive(true);
                Invoke("Fail() ", 0.5f);

                break;



        }
    }
    private void SetBallMove()
    {
        transform.position += ballDataTransmitter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Plane"))
        {
            currentState = State.failGame;
            Debug.Log("TEMASLI MI");
        }

    }

    private void Fail()
    {
        Time.timeScale= 0 ;
    }
    
    private void InputCount()
    {
          if (Input.GetMouseButtonDown(0))
        {
            inputCount ++;
            _text.text = inputCount.ToString();
            
        }
    }


}









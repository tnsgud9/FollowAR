using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State
    {
        idle, move
    }

    public float speed;

    private State _state = State.idle;
    private Animator _animator;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void setState(State s)
    {
        switch (s)
        {
            case State.idle:
                
                break;
            case State.move:
                break;
        }
    }
    
    public void PlayerMove(Transform pos)
    {
        
    }
}

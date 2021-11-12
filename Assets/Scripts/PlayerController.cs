using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum PlayerState
{
    Idle,
    Move
}
public class PlayerController : MonoBehaviour
{
    private bool stateChange;
    private Animator anim;
    public float speed;
    public PlayerState currentState = PlayerState.Idle;
    private bool stateChanged = false;
    public List<Vector3> wayPoint = new List<Vector3>();

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimationController();
        MoveController();
        
        stateChanged = false;
    }

    private void AnimationController()
    {
        if(stateChange && wayPoint.Count.Equals(0))
            anim.SetTrigger("idle");
        else anim.SetTrigger("move");
    }

    private void MoveController()
    {
        if (!stateChanged)
        {
            if (transform.position == wayPoint[0])
                wayPoint.RemoveAt(0);
            transform.position = Vector3.MoveTowards(transform.position, wayPoint[0], Time.deltaTime * speed);
        }
    }
    private void ChangeState(PlayerState state)
    {
        currentState = state;
        stateChanged = true;
    }
    
    public void AddWayPoint(Vector3 pos)
    {
        wayPoint.Add(pos);
        ChangeState(PlayerState.Move);
    }
}

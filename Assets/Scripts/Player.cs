using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private List<Vector3> wayPoints;
    private float speed = 1f;
    private Animator anim;

    void Start()
    {
        this.gameObject.transform.parent = null;
        anim = GetComponent<Animator>();
        wayPoints = new List<Vector3>();
        Manager.instance.player = this.gameObject;
    }
    void Update()
    {
        if (!wayPoints.Count.Equals(0))
        {
            if(transform.position == wayPoints[0])
                wayPoints.RemoveAt(0);
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[0], Time.deltaTime * speed);
            transform.LookAt(wayPoints[0]);
            anim.SetBool("move",true);
        }
        else
            anim.SetBool("move",false);
    }

    public void addWaypoint(Vector3 pos)
    {
        wayPoints.Add(pos);
        
    }
}
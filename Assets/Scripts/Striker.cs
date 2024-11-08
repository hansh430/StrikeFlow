using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Striker : MonoBehaviour
{
    [SerializeField] private float strikeForce=200f;
    [SerializeField] private LineRenderer line;
    private Rigidbody2D rigidBody;
    private Vector2 startposition;
    private Transform selfTransform;
    private Vector2 direction;
    private Vector3 startMousePosition;
    private Vector3 endMouseposition;
    private bool hasStriked=false;
    private bool isPositionSet=false;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        selfTransform = transform;
        startposition = transform.position;
    }
    private void Update()
    {
        startMousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endMouseposition = new Vector3(-startMousePosition.x, -startMousePosition.y, -startMousePosition.z);
        line.SetPosition(0,selfTransform.position);
        line.SetPosition(1,endMouseposition);
    }
    private void ShootStriker()
    {
        rigidBody.AddForce(direction * strikeForce);
    }
}

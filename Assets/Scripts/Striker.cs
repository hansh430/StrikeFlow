using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    [SerializeField] private float strikeForce=200f;
    [SerializeField] private LineRenderer line;
    [SerializeField] private float maxLineLength = 3f;
   
    public static bool isPlayer1Turn = true;
    private Rigidbody2D rigidBody;
    private Vector2 startposition;
    private Transform selfTransform;
    private Vector2 direction;
    private Vector3 startMousePosition;
    private Vector3 endMouseposition;
    private bool hasStriked=false;
    private bool isPositionSet=false;
    private float distance = 0;
    private float currentDistance;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        selfTransform = transform;
        startposition = transform.position;
    }
    private void Update()
    {
        GetMousePositions();
        StrikerColliderDetection();
        DrawLine();
        if (Input.GetMouseButtonUp(0) && rigidBody.velocity.magnitude == 0 && isPositionSet)
        {
            line.enabled = false;
            ShootStriker();
            isPositionSet = false;
        }
        if (rigidBody.velocity.magnitude < 0.1f && hasStriked)
        {
            StartCoroutine(ResetStrikerAfterDelay());
        }
    }
    private IEnumerator ResetStrikerAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);

        if (rigidBody.velocity.magnitude == 0 && hasStriked)
        {
            StrikerReset();
        }
    }
    private void DrawLine()
    {
        if (isPositionSet && rigidBody.velocity.magnitude == 0)
        {
            line.enabled = true;
            line.SetPosition(0, selfTransform.position);
            LimitLineLenght();
        }
    }

    private void StrikerColliderDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isPositionSet)
                {
                    isPositionSet = true;
                }
            }
        }
    }
    private void GetMousePositions()
    {
        startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endMouseposition = new Vector3(-startMousePosition.x, -startMousePosition.y - 3, -startMousePosition.z);
    }
    private void ShootStriker()
    {
       
        if(isPositionSet && rigidBody.velocity.magnitude == 0)
        {
            distance = Vector2.Distance(transform.position, startMousePosition);
        }
        direction = (Vector2)(endMouseposition - transform.position).normalized;
        rigidBody.AddForce(direction *distance* strikeForce);
        hasStriked = true;
    }
    private void StrikerReset()
    {
        rigidBody.velocity = Vector2.zero;
        hasStriked = false;
        isPositionSet = false;
        distance = 0;
        SwitchPlayers();
    }

    private void SwitchPlayers()
    {
        isPlayer1Turn = !isPlayer1Turn;
        EventHandler.OnPlayerTurnChangedEvent(this.transform,isPlayer1Turn);
    }

    private void LimitLineLenght()
    {
        currentDistance = Vector2.Distance(selfTransform.position, endMouseposition);
        if (currentDistance > maxLineLength)
        {
            Vector2 direction = (endMouseposition - selfTransform.position).normalized;
            endMouseposition = (Vector2)selfTransform.position + direction * maxLineLength;
        }
        line.SetPosition(1, endMouseposition);
    }
}

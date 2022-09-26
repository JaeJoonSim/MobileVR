using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMove : MonoBehaviour
{
    public GameObject[] goPointList;
    public float rotSpeed = 2.0f;
    public float moveSpeed = 0.8f;
    [Tooltip ("forcemove = 0, lookat = 1")]
    public int viewMode = 0;
    public int curGoPoint = 0;
    public int numGoPoint = 0;
    private Transform curTransform;
    private CharacterController curCharacterController;
    private Camera curPlayerCamera;
    public int moveCount = 0;

    private void Start()
    {
        curGoPoint = 0;
        curTransform = GetComponent<Transform>();
        curCharacterController = GetComponent<CharacterController>();
        curPlayerCamera = Camera.main;
        goPointList = GameObject.FindGameObjectsWithTag("Gopoint");
        numGoPoint = goPointList.Length;
    }

    private void Update()
    {
        if (viewMode == 0) MovePlayer();
        else if (viewMode == 1) LookAtMovePlayer();

        
        if (moveCount >= 1) viewMode = 1;
    }

    void MovePlayer()
    {
        Vector3 goDirection = goPointList[curGoPoint].transform.position - curTransform.position;
        Quaternion goRotation = Quaternion.LookRotation(goDirection);
        curTransform.rotation = Quaternion.Slerp(curTransform.rotation, goRotation, Time.deltaTime * rotSpeed);
        curTransform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Gopoint"))
        {
            curGoPoint++;

            if(curGoPoint == numGoPoint)
            {
                curGoPoint = 0;
                moveCount++;
            }

            Debug.Log("Trigger Enter : " + other.name);
        }
    }

    void LookAtMovePlayer()
    {
        Vector3 ForwardDir = curPlayerCamera.transform.forward;
        ForwardDir.y = 1;
        curCharacterController.SimpleMove(ForwardDir * moveSpeed);
    }
}

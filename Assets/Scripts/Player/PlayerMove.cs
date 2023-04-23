using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatCanBeClickOn;

    private NavMeshAgent _myAgent;

    private void Awake()
    {
        _myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickOn))
            {
                _myAgent.SetDestination(hitInfo.point);
            }
        }
    }
}

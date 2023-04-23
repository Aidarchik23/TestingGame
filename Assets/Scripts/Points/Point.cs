using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Point : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPoint;

    private Collider _collider;
    private Rigidbody _rigidbody;

    public UnityEvent onCollision = new UnityEvent();

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove player))
        {
            onCollision?.Invoke();
            Instantiate(effectPoint, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

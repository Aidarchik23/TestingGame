using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class CoinComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionEffect;

    private Collider _collider;
    private Rigidbody _rigidbody;

    public UnityEvent onCollisionWithPlayer = new UnityEvent();

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
            onCollisionWithPlayer?.Invoke();
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

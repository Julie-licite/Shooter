using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil_Behavior : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        // Même logique que pour EnemyBehaviour
        var playerGameObject = GameObject.FindWithTag("Player");
        var playerBehaviour = playerGameObject.GetComponent<Controller_Behavior>();
        playerBehaviour.onDeath.AddListener(Die);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector3
        {
            x = speed * Time.fixedDeltaTime,
            y = 0,
            z = 0
        };
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

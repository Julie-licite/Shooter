using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi_Behavior : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody myRigidbody;
    private Controller_Behavior player; // Référence au script appliqué sur le joueur

    // Start is called before the first frame update
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        var playerGameObject = GameObject.FindWithTag("Player"); // Permet de trouver un GameObject grâce à son tag
        player = playerGameObject.GetComponent<Controller_Behavior>(); // On récupère le script d’après le GameObject
        player.onDeath.AddListener(Die); // On ajoute la fonction Die() à la liste des actions à faire à la mort du joueur
    }

    // Update is called once per frame
    private void Update()
    {
        // Déplacement du joueur
        myRigidbody.velocity = new Vector3
        {
            
            x = -speed * Time.fixedDeltaTime,
            y = 0,
            z = 0
        };
        // Condition de mort
        if (transform.position.x < -10)
        {
            player.Die();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Si un projectile nous rentre dedans, on détruit l’objet
        if (other.gameObject.CompareTag("Projectile"))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private int destPoint = 0;
     public SpriteRenderer enemy;
    private Transform target;
   

    public int damageValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        //l'ennemi va tourner en boucle
        // par défaut il va se déplacer vers le premier point de la liste ou le point zero
        target = waypoints[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        // déplace l'ennemi par rapport au monde qui l'entoure au fil du temps mais vers une seule position
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //permet de changer la direction de déplacement de l'ennemi 

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            //enemy.flipX = !enemy.flipX;
            enemy.flipX = !enemy.flipX;
        }
        

    }
    // methode qui permet de  détecter collision avec le personnage principal
    private void OnCollisionEnter2D(Collision2D collision) {

    //appliquer des degats au personnage s'il entre en contact avec le personnage
    if(collision.transform.CompareTag("Player"))
    {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(damageValue);
    }
    }
}


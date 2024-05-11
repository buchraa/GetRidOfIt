using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private int destPoint;
    private Transform target;
    public SpriteRenderer enemy;

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
            enemy.flipX = !enemy.flipX;
        }
        


    }
}

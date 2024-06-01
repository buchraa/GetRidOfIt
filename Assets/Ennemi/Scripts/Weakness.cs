using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : MonoBehaviour
{

    public GameObject objectToDestroy;
 //creation d'une methode qui va se charger de détruire l'ennemi si jamais le personnage principal lui saute dessus
 private void OnTriggerEnter2D(Collider2D collision)
 {
    if(collision.CompareTag("Player"))
    {
//destruction de l'ennemi avec le collider et les points target
       Destroy(objectToDestroy);
    }
 }
}

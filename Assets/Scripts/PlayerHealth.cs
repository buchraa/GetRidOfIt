using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float InvincibilityTime = 3f;

    public float InvincibilityDelay = 02f;
    public int maxHealth = 100;
    public int currentHealth;

    // pour faire référence à notre barre de vie HealthBar
    public HealthBar healthBar;


    //variable boolean qui permet de savoir si le personnage est invincible

    public  bool isInvincible = false;

    public SpriteRenderer graphics;
    // on initialise le jeu avec 100 points de vie pour le personnage avec la methode dans HealthBar 
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    //methode pour retirer  des points de vie 

   public  void TakeDamage(int damage) 
   {
        if(!isInvincible)
        {
        //retirer points 
        currentHealth -= damage;
        //mettre à jour les points
        healthBar.SetHealth(currentHealth);
        isInvincible = true;
        StartCoroutine(InvincibilityFlash());
        StartCoroutine(HandleInvicibilitDelay());
        }
      
    }

    public IEnumerator InvincibilityFlash()
        {
            while(isInvincible)
            {
                //permet d'ajouter un filtre de couleur qui va masquer le personnage
                graphics.color = new Color(1f, 1f, 1f, 0f);
                //yield permet d'ajouter un delai avant d'appliquer l'autre filtre de couleur pour réafficher 
                yield return new WaitForSeconds(InvincibilityDelay);
                graphics.color = new Color(1f, 1f, 1f, 1f);
                //cette dernière lign epermet de faire un système de toggle sur le personnage
                yield return new WaitForSeconds(InvincibilityDelay);
            }
        }
//methode qui permet de gérer le delai d'invincibilité
    public IEnumerator HandleInvicibilitDelay()
    {
        yield return new WaitForSeconds(InvincibilityTime);
        isInvincible = false;
    }    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

   //need to import component of UnityEngine.Ui
   public Slider slider;

   //ajoute une autre couleur sur le slider

   public Gradient gradient;
   public Image fillImage;
   //methode qui permet initialise et réinialise la vie du jour
   public void SetMaxHealth(int health)
   {
        slider.maxValue = health;
        slider.value = health;

        fillImage.color = gradient.Evaluate(1f);
   }

   //methode qui permet d'appliquer un certain nombre de points de vie
   public void SetHealth (int health)
   
   {
        slider.value = health;
        fillImage.color = gradient.Evaluate(slider.normalizedValue);
   }

}

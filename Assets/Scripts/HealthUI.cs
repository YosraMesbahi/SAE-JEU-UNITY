using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private PlayerData playerData;

    void Update()
    {
        if (healthBar != null && playerData != null)
        {
            healthBar.value = playerData.currentHealth;
            healthBar.maxValue = playerData.maxHealth;
            
            // Bonus: Changer couleur selon vie
            float healthPercent = playerData.currentHealth / playerData.maxHealth;
            
            if (healthPercent < 0.3f)
                healthBar.fillRect.GetComponent<Image>().color = Color.red;
            else if (healthPercent < 0.6f)
                healthBar.fillRect.GetComponent<Image>().color = Color.yellow;
            else
                healthBar.fillRect.GetComponent<Image>().color = Color.green;
        }
    }
}
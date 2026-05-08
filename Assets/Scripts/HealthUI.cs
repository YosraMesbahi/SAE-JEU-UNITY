using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private PlayerData playerData;

    void Update()
    {
        healthBar.value = playerData.currentHealth;
        healthBar.maxValue = playerData.maxHealth;
    }
}
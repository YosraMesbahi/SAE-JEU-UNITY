using UnityEngine;

public class InteractiveBlock : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite disabledSprite;

    [Header("Contenu du bloc")]
    [SerializeField] private GameObject itemPrefab; // ← La pomme à faire apparaître!

    private bool isUsed = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isUsed) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Joueur touche par le bas
                if (contact.normal.y > 0.5f)
                {
                    ActivateBlock();
                    break;
                }
            }
        }
    }

    private void ActivateBlock()
    {
        isUsed = true;

        // 1. Changer le sprite → état désactivé
        if (disabledSprite != null)
        {
            spriteRenderer.sprite = disabledSprite;
        }

        // 2. Faire apparaître la pomme AU-DESSUS du bloc
        if (itemPrefab != null)
        {
            // Position = position du bloc + un peu au-dessus
            Vector3 spawnPosition = transform.position + Vector3.up * 1.5f;
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
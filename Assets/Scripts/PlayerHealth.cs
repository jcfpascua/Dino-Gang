using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private SpriteRenderer spriteRenderer;
    private bool isInvulnerable = false;
    public float invulnerabilityTime = 1f;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return; // Prevent damage if invulnerable

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
        
        StartCoroutine(FlashRed()); // Start the flash effect
        StartCoroutine(Invulnerability()); // Start invulnerability timer

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            SceneManager.LoadScene("Lose Scene");
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    // Coroutine for flashing red when damaged
    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red; // Change sprite color to red
        yield return new WaitForSeconds(0.1f); // Flash duration
        spriteRenderer.color = Color.white; // Revert to original color
    }

    // Coroutine for handling invulnerability period
    IEnumerator Invulnerability()
    {
        isInvulnerable = true; // Make the player invulnerable
        yield return new WaitForSeconds(invulnerabilityTime); // Duration of invulnerability
        isInvulnerable = false; // End invulnerability
    }
}

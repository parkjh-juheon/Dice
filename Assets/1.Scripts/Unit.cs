using UnityEngine;
using TMPro;


public class Unit : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public TextMeshProUGUI healthText;  // 드래그해서 넣기

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();

        Debug.Log($"{gameObject.name}이(가) {amount}의 피해를 입음. 남은 체력: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }
    private void Die()
    {
        Debug.Log($"{gameObject.name}이(가) 죽었습니다.");
        // 죽는 처리 (예: 사라지거나 애니메이션 등)
        Destroy(gameObject);
    }
}

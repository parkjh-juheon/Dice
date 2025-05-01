using UnityEngine;
using TMPro;


public class Unit : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public TextMeshProUGUI healthText;  // �巡���ؼ� �ֱ�

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

        Debug.Log($"{gameObject.name}��(��) {amount}�� ���ظ� ����. ���� ü��: {currentHealth}");

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
        Debug.Log($"{gameObject.name}��(��) �׾����ϴ�.");
        // �״� ó�� (��: ������ų� �ִϸ��̼� ��)
        Destroy(gameObject);
    }
}

using TMPro; // TextMeshPro�� ����ϱ� ���� �ʿ�
using UnityEngine;

// ����(�÷��̾� �Ǵ� ��)�� ü�� ������ UI ������ ����ϴ� Ŭ����
public class Unit : MonoBehaviour
{
    public int maxHealth = 30; // �ִ� ü�� (�����Ϳ��� ���� ����)
    private int currentHealth; // ���� ü�� (���ο����� ���)

    public TextMeshProUGUI healthText; // UI�� ü���� ǥ���� �ؽ�Ʈ (�����Ϳ��� �����ؾ� ��)

    public int CurrentHP => currentHealth;


    // ���� ���� �� ȣ���
    private void Start()
    {
        currentHealth = maxHealth; // ���� ü�� ����
        UpdateHealthText(); // UI �ؽ�Ʈ ����
    }

    // ���ظ� ���� �� ȣ���ϴ� �Լ�
    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // ü�� ����
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 0���� �۰ų�, �ִ� ü�� �̻����� �� ���� ����
        UpdateHealthText(); // ü�� UI ����

        Debug.Log($"{gameObject.name}��(��) {amount}�� ���ظ� ����. ���� ü��: {currentHealth}");

        // ü���� 0 ���ϰ� �Ǹ� ���� ó��
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ȸ���� �� ȣ���ϴ� �Լ�
    public void Heal(int amount)
    {
        currentHealth += amount; // ü�� ȸ��
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �ִ� ü���� ���� �ʵ��� ����
        UpdateHealthText(); // ü�� UI ����
    }

    // ü���� UI �ؽ�Ʈ�� �ݿ��ϴ� �Լ�
    private void UpdateHealthText()
    {
        if (healthText != null) // ����� �ؽ�Ʈ�� �ִٸ�
        {
            healthText.text = $"{currentHealth}/{maxHealth}"; // ��: "25/30"
        }
    }

    // ������ �׾��� �� ����Ǵ� �Լ�
    private void Die()
    {
        Debug.Log($"{gameObject.name}��(��) �׾����ϴ�.");
        // ���⿡�� �״� ����, �ִϸ��̼� ���� ���� �� ����
        Destroy(gameObject); // ���� ���� GameObject ����
    }
}

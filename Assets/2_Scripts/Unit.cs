using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public TextMeshProUGUI healthText;

    public int CurrentHP => currentHealth;

    public bool Isdead => currentHealth <= 0;

    [SerializeField]
    private DiceButtonManager buttonManager;

    [SerializeField]
    private BattleManager battleManager;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        // buttonManager�� Inspector���� �Ҵ�
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
    EnemyDiceSpawner spawner = GetComponent<EnemyDiceSpawner>();
    if (buttonManager != null && spawner != null)
    {
        buttonManager.RemoveEnemySpawner(spawner);
        spawner.enabled = false;
        Debug.Log($"{gameObject.name}�� DiceSpawner ��Ȱ��ȭ��.");
    }

    // BattleManager���� ����
    if (battleManager != null)
    {
        battleManager.enemyUnits.Remove(this);
    }

    Destroy(gameObject);
}
}
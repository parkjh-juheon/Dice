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
        // buttonManager는 Inspector에서 할당
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
    EnemyDiceSpawner spawner = GetComponent<EnemyDiceSpawner>();
    if (buttonManager != null && spawner != null)
    {
        buttonManager.RemoveEnemySpawner(spawner);
        spawner.enabled = false;
        Debug.Log($"{gameObject.name}의 DiceSpawner 비활성화됨.");
    }

    // BattleManager에서 제거
    if (battleManager != null)
    {
        battleManager.enemyUnits.Remove(this);
    }

    Destroy(gameObject);
}
}
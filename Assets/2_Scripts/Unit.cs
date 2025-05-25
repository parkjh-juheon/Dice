using TMPro; // TextMeshPro를 사용하기 위해 필요
using UnityEngine;

// 유닛(플레이어 또는 적)의 체력 관리와 UI 갱신을 담당하는 클래스
public class Unit : MonoBehaviour
{
    public int maxHealth = 30; // 최대 체력 (에디터에서 수정 가능)
    private int currentHealth; // 현재 체력 (내부에서만 사용)

    public TextMeshProUGUI healthText; // UI에 체력을 표시할 텍스트 (에디터에서 연결해야 함)

    public int CurrentHP => currentHealth;


    // 게임 시작 시 호출됨
    private void Start()
    {
        currentHealth = maxHealth; // 시작 체력 설정
        UpdateHealthText(); // UI 텍스트 갱신
    }

    // 피해를 입을 때 호출하는 함수
    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // 체력 감소
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 0보다 작거나, 최대 체력 이상으로 못 가게 제한
        UpdateHealthText(); // 체력 UI 갱신

        Debug.Log($"{gameObject.name}이(가) {amount}의 피해를 입음. 남은 체력: {currentHealth}");

        // 체력이 0 이하가 되면 죽음 처리
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 회복할 때 호출하는 함수
    public void Heal(int amount)
    {
        currentHealth += amount; // 체력 회복
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 최대 체력을 넘지 않도록 제한
        UpdateHealthText(); // 체력 UI 갱신
    }

    // 체력을 UI 텍스트에 반영하는 함수
    private void UpdateHealthText()
    {
        if (healthText != null) // 연결된 텍스트가 있다면
        {
            healthText.text = $"{currentHealth}/{maxHealth}"; // 예: "25/30"
        }
    }

    // 유닛이 죽었을 때 실행되는 함수
    private void Die()
    {
        Debug.Log($"{gameObject.name}이(가) 죽었습니다.");
        // 여기에서 죽는 연출, 애니메이션 등을 넣을 수 있음
        Destroy(gameObject); // 현재 유닛 GameObject 제거
    }
}

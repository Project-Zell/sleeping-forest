using UnityEngine;

public class Test_enemy : MonoBehaviour
{
    public int hp = 100;
    public GameObject EXPPrefab;  // 経験値オーブのPrefab
    public int expDropCount = 3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(100);
        }
    }

    public void TakeDamage(int damage)
    {
        hp = Mathf.Max(0, hp - damage);  // HPが負にならないよう調整
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DropExp();
        Destroy(gameObject);
    }

    void DropExp()
    {
        if (EXPPrefab != null)
        {
            for (int i = 0; i < expDropCount; i++) // 複数の経験値オーブをドロップ
            {
                Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f)); // ランダムな位置
                Instantiate(EXPPrefab, transform.position + offset, Quaternion.identity);
            }
        }
    }
}
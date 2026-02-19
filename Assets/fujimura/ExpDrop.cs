using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    public GameObject EXPPrefab;  // 経験値オーブのPrefab
    public int expDropCount = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DropExp()
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

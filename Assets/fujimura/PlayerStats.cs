using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int exp = 0;
    public int level = 1;
    public int expToNextLevel = 100; // レベルアップに必要な経験値

    public void AddExp(int amount)
    {
        exp += amount;
        Debug.Log($"経験値獲得: {amount} (総経験値: {exp}/{expToNextLevel})");

        while (exp >= expToNextLevel) // 余剰経験値を繰り越し
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        exp -= expToNextLevel; // 余った分を次のレベルへ持ち越し
        expToNextLevel += 20; // 次のレベルアップに必要な経験値を増やす

        Debug.Log($"レベルアップ！現在のレベル: {level} (次のレベル: {exp}/{expToNextLevel})");
    }
}
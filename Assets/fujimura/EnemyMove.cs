using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform player; // プレイヤーのTransform
    public float speed = 2f; // 移動速度

    [SerializeField]
    private float fixedY = 0.5f; // 固定するY座標

    void Update()
    {
        // プレイヤーの方向を計算
        Vector3 direction = (player.position - transform.position).normalized;

        // 敵を移動 (Y軸の変更はせず、XとZ方向のみ移動)
        transform.position += new Vector3(direction.x, 0, direction.z) * speed * Time.deltaTime;

        // Y軸を常に固定
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);

        // 敵の向きをプレイヤーの方向に向ける
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player; // PlayerのTransform
    public Vector3 offset; // カメラのオフセット位置
    public float smoothSpeed = 0.125f; // 追従スピード（調整可能）

    void LateUpdate()
    {
        // 目標位置を計算
        Vector3 targetPosition = player.position + offset;

        // 現在の位置と目標位置を線形補間でスムーズに移動
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
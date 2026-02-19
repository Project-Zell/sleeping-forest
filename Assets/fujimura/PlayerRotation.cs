using UnityEngine;

public class PlayerRotation: MonoBehaviour
{
    public Camera mainCamera; // シーンのカメラを設定

    void FixedUpdate()
    {
        if (PauseMenu.isPaused) return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0)); // 地面の水平平面を定義
        float distance;

        if (groundPlane.Raycast(ray, out distance))
        {
            Vector3 targetPosition = ray.GetPoint(distance); // レイと平面の交点を取得
            targetPosition.y = transform.position.y; // Y座標を固定

            Vector3 direction = targetPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Player Rotation (Y): " + transform.rotation.eulerAngles.y);
            }
        }
    }
}
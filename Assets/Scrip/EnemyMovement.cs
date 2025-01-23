using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Tốc độ di chuyển của enemy

    void Update()
    {
        // Di chuyển enemy ngang qua màn hình
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    // private void OnBecameInvisible()
    // {
    //     ObjectPool.Instance.ReturnGO(this.gameObject);
    // }
}

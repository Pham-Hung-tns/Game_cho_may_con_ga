using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có phải là "Enemy" hay không
        if (collision.CompareTag("Enemy"))
        {
            // Xóa đối tượng Enemy khi chạm vào
            ObjectPool.Instance.ReturnGO(collision.gameObject);
        }
    }
}

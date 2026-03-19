using UnityEngine;

public class ItemCollectible : MonoBehaviour
{
    public enum ItemType { Gold, Health }
    public ItemType type;
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            
            if (type == ItemType.Gold)
            {
                // GỌI HÀM ADD GOLD (Tiền và Điểm đã được tách riêng)
                GlobalController.Instance.AddGold(value); 
            }
            else if (type == ItemType.Health)
            {
                player.heal(value); 
            }

            Destroy(gameObject); 
        }
    }
}
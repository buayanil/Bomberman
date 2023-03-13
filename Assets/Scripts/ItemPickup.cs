using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
        ExtraLife // new item type
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
{
    switch (type)
    {
        case ItemType.ExtraBomb:
            player.GetComponent<BombController>().AddBomb();
            break;

        case ItemType.BlastRadius:
            player.GetComponent<BombController>().explosionRadius++;
            break;

        case ItemType.SpeedIncrease:
            player.GetComponent<MovementController>().speed++;
            break;

        case ItemType.ExtraLife: // give player an extra life and update the UI
            player.GetComponent<Life>().IncreaseLives();
            //LivesUI livesUI = player.GetComponent<MovementController>().livesUI;
            //livesUI.AddLife();
            break;
    }

    Destroy(gameObject);
}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }
    }
}


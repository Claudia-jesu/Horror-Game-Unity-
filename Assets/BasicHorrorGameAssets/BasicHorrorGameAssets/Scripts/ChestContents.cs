using UnityEngine;

public enum ChestItem { Empty, Lantern, Gun, Key }

public class ChestContents : MonoBehaviour
{
    public ChestItem chestItem = ChestItem.Empty;
    public GameObject itemToDestroy;   // Item inside chest (lantern/gun/key)

    [HideInInspector]
    public bool isOpen = false;
}


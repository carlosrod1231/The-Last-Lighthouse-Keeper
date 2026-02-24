using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public void OnGrab()
    {
        GameState.Instance.GiveKey();

        // optional: remove key so it's “collected”
        gameObject.SetActive(false);
    }
}

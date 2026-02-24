using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject lockedMessageUI;

    public void TryEnter()
    {
        if (GameState.Instance != null && GameState.Instance.HasKey)
        {
            if (sceneLoader == null)
            {
                Debug.LogError("DoorUnlock: sceneLoader is NOT assigned in Inspector.");
                return;
            }

            sceneLoader.LoadInterior();
        }
        else
        {
            if (lockedMessageUI) lockedMessageUI.SetActive(true);
            Debug.Log("Locked. Need key.");
        }
    }
}

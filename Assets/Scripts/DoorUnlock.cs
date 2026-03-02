using UnityEngine;
using System.Collections;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject lockedMessageUI;
    [SerializeField] private float messageDuration = 2f;

    public void TryEnter()
    {
        if (GameState.Instance == null)
        {
            Debug.LogError("GameState not found!");
            return;
        }

        if (GameState.Instance.HasKey)
        {
            sceneLoader.LoadInterior();
        }
        else
        {
            ShowLockedMessage();
        }
    }

    private void ShowLockedMessage()
    {
        if (lockedMessageUI == null) return;

        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine());
    }

    private IEnumerator ShowMessageRoutine()
    {
        lockedMessageUI.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        lockedMessageUI.SetActive(false);
    }
}
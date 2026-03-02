using UnityEngine;
using System.Collections;

public class KeyMessageDisplay : MonoBehaviour
{
    [SerializeField] private GameObject keyMessageUI;
    [SerializeField] private float messageDuration = 4f;

    public void ShowMessage()
    {
        if (keyMessageUI == null)
        {
            Debug.LogWarning("KeyMessageDisplay: UI not assigned.");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(ShowRoutine());
    }

    private IEnumerator ShowRoutine()
    {
        keyMessageUI.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        keyMessageUI.SetActive(false);
    }
}
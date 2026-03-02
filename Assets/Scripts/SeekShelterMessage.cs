using UnityEngine;
using System.Collections;

public class SeekShelterMessage : MonoBehaviour
{
    [SerializeField] private GameObject seekShelterUI;
    [SerializeField] private float messageDuration = 4f;

    public void ShowMessage()
    {
        if (seekShelterUI == null)
        {
            Debug.LogWarning("SeekShelterMessage: UI not assigned.");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(ShowRoutine());
    }

    private IEnumerator ShowRoutine()
    {
        seekShelterUI.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        seekShelterUI.SetActive(false);
    }
}
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject endCanvas;
    [SerializeField] private GameObject locomotionRoot; // your XR Origin Locomotion object (optional)

    public void TriggerEnd()
    {
        if (endCanvas) endCanvas.SetActive(true);

        // optional: stop player movement
        if (locomotionRoot) locomotionRoot.SetActive(false);

        Debug.Log("Game ended!");
    }
}

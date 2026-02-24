using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JournalController : MonoBehaviour
{
    public ParticleSystem rainSystem;
    private bool hasTriggered = false;

    public void OnJournalSelect(SelectEnterEventArgs args)   // for Select Entered
    {
        TriggerRain();
    }

    public void OnJournalActivate(ActivateEventArgs args)    // for Activated
    {
        TriggerRain();
    }

    private void TriggerRain()
    {
        if (hasTriggered) return;
        hasTriggered = true;

        if (rainSystem == null)
        {
            Debug.LogError("Rain system not assigned!");
            return;
        }

        var emission = rainSystem.emission;
        emission.rateOverTime = 600f;

        rainSystem.Play();
        Debug.Log("Rain triggered!");
    }
}

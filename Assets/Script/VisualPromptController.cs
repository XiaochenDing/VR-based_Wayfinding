using UnityEngine;

[System.Serializable]
public class PromptPoint
{
    public Transform location;
    public GameObject prefab;
    [HideInInspector] public bool hasBeenShown = false;
}

public class VisualPromptController : MonoBehaviour
{
    public PromptPoint[] promptSequence;
    public float activationDistance = 2.0f;

    [Header("Audio Feedback")]
    public AudioSource proximityAudio;
    public Transform goalTransform;
    public float maxAudioDistance = 15f;  

    private GameObject currentInstance;
    


    private bool audioStopped = false;

    void Update()
    {
        if (proximityAudio != null && goalTransform != null && !audioStopped)
        {
            float distance = Vector3.Distance(goalTransform.position, Camera.main.transform.position);

            if (distance <= 2f)
            {
                if (proximityAudio.isPlaying)
                    proximityAudio.Stop();

                audioStopped = true;
                return;
            }

            float volume = Mathf.Clamp01(1 - (distance / maxAudioDistance)); 
            proximityAudio.volume = volume;

            if (!proximityAudio.isPlaying)
                proximityAudio.Play();
        }
    }




    public void ShowNextPrompt(Vector3 playerPosition)
    {
        PromptPoint closestPrompt = null;
        float closestDistance = Mathf.Infinity;

        foreach (PromptPoint point in promptSequence)
        {
            if (point == null || point.prefab == null || point.location == null || point.hasBeenShown)
                continue;

            float distance = Vector3.Distance(playerPosition, point.location.position);
            if (distance < closestDistance && distance <= activationDistance)
            {
                closestDistance = distance;
                closestPrompt = point;
            }
        }

        if (closestPrompt != null)
        {
            currentInstance = Instantiate(
                closestPrompt.prefab,
                closestPrompt.location.position,
                closestPrompt.location.rotation
            );

            closestPrompt.hasBeenShown = true;
        }
    }
}

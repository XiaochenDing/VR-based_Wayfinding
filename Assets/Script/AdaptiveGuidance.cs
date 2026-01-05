using UnityEngine;

public class AdaptiveGuidance : MonoBehaviour
{
    public Material highContrastMaterial;
    private Renderer signRenderer;
    private Logger logger;

    void Start()
    {
        signRenderer = GetComponent<Renderer>();
        logger = FindObjectOfType<Logger>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            logger.LogEvent("EnteredWrongPath");
            signRenderer.material = highContrastMaterial;
        }
    }
}

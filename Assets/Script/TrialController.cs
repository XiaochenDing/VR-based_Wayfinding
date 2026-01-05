using UnityEngine;

public class TrialController : MonoBehaviour
{
    public GameObject guidanceArrow;
    private Logger logger;

    void Start()
    {
        logger = FindObjectOfType<Logger>();
    }

    public void StartTrial()
    {
        logger.LogEvent("TrialStarted");
        guidanceArrow.SetActive(true);
    }

    public void EndTrial()
    {
        logger.LogEvent("TrialEnded");
        guidanceArrow.SetActive(false);
    }
}

using UnityEngine;

public class PlayerBehaviorAnalyzer : MonoBehaviour
{
    public Logger logger;
    public Transform playerHead;
    public VisualPromptController promptController;

    [Header("Gaze Settings")]
    public float gazeTimeThreshold = 1.5f;
    private float gazeTimer = 0f;

    [Header("Movement Settings")]
    public float slowSpeedThreshold = 0.2f;
    public float stationaryDurationThreshold = 2f;
    private float stopTimer = 0f;
    private Vector3 lastPosition;
    private float smoothedSpeed = 0f;
    public float speedSmoothing = 0.1f;

    [Header("Head Turn Settings")]
    public float headTurnThreshold = 100f;
    private float lastYaw;
    private float smoothedYawDiff = 0f;
    public float yawSmoothing = 0.1f;

    private bool promptShown = false;

    void Start()
    {
        lastPosition = playerHead.position;
        lastYaw = playerHead.eulerAngles.y;
        //promptController?.ResetPrompts();
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;


        // Gaze logic
        string gazeTarget = logger != null ? logger.GetCurrentGazeTarget() : "";
        bool isLookingAtSign = !string.IsNullOrEmpty(gazeTarget) && gazeTarget.Contains("Sign");

        if (isLookingAtSign)
            gazeTimer += deltaTime;
        else
            gazeTimer = 0f;


        // Movement logic
        float rawSpeed = Vector3.Distance(playerHead.position, lastPosition) / deltaTime;
        smoothedSpeed = Mathf.Lerp(smoothedSpeed, rawSpeed, speedSmoothing);

        if (smoothedSpeed < slowSpeedThreshold)
            stopTimer += deltaTime;
        else
            stopTimer = 0f;

        // Head turn logic
        float currentYaw = playerHead.eulerAngles.y;
        float yawDiff = Mathf.Abs(Mathf.DeltaAngle(lastYaw, currentYaw));
        smoothedYawDiff = Mathf.Lerp(smoothedYawDiff, yawDiff, yawSmoothing);
        lastYaw = currentYaw;
        
        // Visualization in Scene
        Debug.DrawRay(playerHead.position, playerHead.forward * 2f, Color.green);
        Debug.Log($"Speed: {smoothedSpeed:F2}, YawDiff: {smoothedYawDiff:F2}, GazeTimer: {gazeTimer:F2}, StopTimer: {stopTimer:F2}");

        // Trigger logic
        if (gazeTimer > gazeTimeThreshold || stopTimer > stationaryDurationThreshold || smoothedYawDiff > headTurnThreshold)
        {
            promptController.ShowNextPrompt(playerHead.position);
            logger.LogEvent("ConfusedPromptActivated");
            
            Debug.Log("Prompt Triggered");

            gazeTimer = 0f;
            stopTimer = 0f;
        }

        
        lastPosition = playerHead.position;
    }
}

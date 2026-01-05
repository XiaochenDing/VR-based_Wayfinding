using UnityEngine;

public class PlayerDebugHUD : MonoBehaviour
{
    public Transform playerHead;
    public float stationaryThreshold = 0.05f;  // 低于该速度视为停留
    public float raycastDistance = 20f;

    private Vector3 lastPosition;
    private float lastYaw;
    private float lastTime;

    private float speed = 0f;
    private float yawRate = 0f;
    private bool isStationary = false;
    private string gazeTarget = "None";

    void Start()
    {
        lastPosition = playerHead.position;
        lastYaw = playerHead.eulerAngles.y;
        lastTime = Time.time;
    }

    void Update()
    {
        float currentTime = Time.time;
        float deltaTime = currentTime - lastTime;

        // Speed & yaw rate
        Vector3 currentPosition = playerHead.position;
        float currentYaw = playerHead.eulerAngles.y;

        speed = Vector3.Distance(currentPosition, lastPosition) / deltaTime;
        yawRate = Mathf.DeltaAngle(lastYaw, currentYaw) / deltaTime;
        isStationary = speed < stationaryThreshold;

        lastPosition = currentPosition;
        lastYaw = currentYaw;
        lastTime = currentTime;

        // Gaze detection via Raycast
        Ray ray = new Ray(playerHead.position, playerHead.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
        {
            gazeTarget = hit.collider.gameObject.name;
        }
        else
        {
            gazeTarget = "None";
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 20;
        style.normal.textColor = Color.cyan;

        GUI.Label(new Rect(20, 20, 600, 30), $"Speed: {speed:F2} m/s", style);
        GUI.Label(new Rect(20, 50, 600, 30), $"Yaw Rate: {yawRate:F2} deg/s", style);
        GUI.Label(new Rect(20, 80, 600, 30), $"Stationary: {(isStationary ? "Yes" : "No")}", style);
        GUI.Label(new Rect(20, 110, 800, 30), $"Gazing At: {gazeTarget}", style);
    }
}

using UnityEngine;
using System.IO;

public class Logger : MonoBehaviour
{
    public Transform playerHead;
    public LayerMask gazeLayerMask;
    public float gazeRayLength = 20f;

    private StreamWriter writer;
    private Vector3 lastPosition;
    private Vector3 lastEuler;
    private float lastTime;
    private string latestGazeTarget = "None";
    private Vector3 latestGazeHit = Vector3.zero;

    void Start()
    {
        string path = Application.dataPath + "/Resources/Logs/log_" + System.DateTime.Now.ToString("HHmmss") + ".csv";
        writer = new StreamWriter(path);
        writer.WriteLine("Time,X,Y,Z,RotX,RotY,RotZ,Speed,YawRate,PitchRate,Event,GazeTarget,GazeHitX,GazeHitY,GazeHitZ");

        lastPosition = playerHead.position;
        lastEuler = playerHead.rotation.eulerAngles;
        lastTime = Time.time;

        InvokeRepeating(nameof(LogData), 0f, 0.1f);
    }

    void Update()
    {
        // Gaze detection (same logic as HUD)
        Vector3 origin = playerHead.position;
        Vector3 direction = playerHead.forward;
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;

        latestGazeTarget = "None";
        latestGazeHit = origin + direction * gazeRayLength;

        if (Physics.Raycast(ray, out hit, gazeRayLength, gazeLayerMask))
        {
            latestGazeTarget = hit.collider.gameObject.name;
            latestGazeHit = hit.point;
        }
    }

    void LogData()
    {
        float currentTime = Time.time;
        float deltaTime = currentTime - lastTime;

        Vector3 pos = playerHead.position;
        Vector3 euler = playerHead.rotation.eulerAngles;

        float speed = Vector3.Distance(pos, lastPosition) / Mathf.Max(deltaTime, 0.0001f);
        float yawRate = Mathf.DeltaAngle(lastEuler.y, euler.y) / Mathf.Max(deltaTime, 0.0001f);
        float pitchRate = Mathf.DeltaAngle(lastEuler.x, euler.x) / Mathf.Max(deltaTime, 0.0001f);

        writer.WriteLine($"{currentTime:F2},{pos.x:F2},{pos.y:F2},{pos.z:F2}," +
                         $"{euler.x:F1},{euler.y:F1},{euler.z:F1}," +
                         $"{speed:F2},{yawRate:F2},{pitchRate:F2}," +
                         $"None,{latestGazeTarget},{latestGazeHit.x:F2},{latestGazeHit.y:F2},{latestGazeHit.z:F2}");

        writer.Flush();

        lastPosition = pos;
        lastEuler = euler;
        lastTime = currentTime;
    }

    public void LogEvent(string eventName)
    {
        Vector3 pos = playerHead.position;
        Vector3 euler = playerHead.rotation.eulerAngles;

        writer.WriteLine($"{Time.time:F2},{pos.x:F2},{pos.y:F2},{pos.z:F2}," +
                         $"{euler.x:F1},{euler.y:F1},{euler.z:F1}," +
                         $",,,{eventName},{latestGazeTarget},{latestGazeHit.x:F2},{latestGazeHit.y:F2},{latestGazeHit.z:F2}");

        writer.Flush();
    }

    public string GetCurrentGazeTarget()
    {
        return latestGazeTarget;
    }

    void OnApplicationQuit()
    {
        writer?.Flush();
        writer?.Close();
    }
}

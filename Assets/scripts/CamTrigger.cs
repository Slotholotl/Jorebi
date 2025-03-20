using UnityEngine;
using Cinemachine;

public class CamTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera activeCam; // Assign in Inspector
    private static CinemachineVirtualCamera currentActiveCam; // Keeps track of the active camera

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetActiveCamera();
        }
    }

    private void SetActiveCamera()
    {
        // If this camera is already active, do nothing
        if (currentActiveCam == activeCam) return;

        // Get all Cinemachine cameras in the scene
        CinemachineVirtualCamera[] allCams = FindObjectsOfType<CinemachineVirtualCamera>();

        // Lower the priority of all cameras
        foreach (CinemachineVirtualCamera cam in allCams)
        {
            cam.Priority = 0;
        }

        // Set the priority of the new active camera
        activeCam.Priority = 10;
        currentActiveCam = activeCam; // Update the active camera reference
    }
}

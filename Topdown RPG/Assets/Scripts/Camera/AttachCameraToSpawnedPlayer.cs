using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class AttachCameraToSpawnedPlayer : MonoBehaviour {
    
    private ICinemachineCamera vCam;
    private UnityAction<Transform> setCameraTargetAction;

    private void Awake() {
        vCam = GetComponent<ICinemachineCamera>();

        setCameraTargetAction = new UnityAction<Transform>(SetCameraTarget);
    }

    private void SetCameraTarget(Transform cameraTarget) {
        vCam.Follow = cameraTarget;
        vCam.VirtualCameraGameObject.transform.parent = cameraTarget;
    }

    private void OnEnable() {
        PlayerEvents.onPlayerSpawned += setCameraTargetAction;
    }

    private void OnDisable() {
        PlayerEvents.onPlayerSpawned -= setCameraTargetAction;
    }
}

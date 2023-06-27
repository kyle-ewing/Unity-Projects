using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class HUDController : MonoBehaviour {

    [SerializeField] 
    private Slider staminaSlider;
    private void Start() {
        EventManager.RegisterListener<CurrentStaminaEvent>(SetCurrentStamina);
    }

    private void Awake() {
        ValidateReferences();
    }

    private void ValidateReferences() {
        isNull(staminaSlider);
    }

    private void isNull(Object referenceObject) {
        if (referenceObject is null) {
            throw new Exception("Reference object is null");
        }
    }

    private void OnDestroy() {
        EventManager.UnregisterListener<CurrentStaminaEvent>(SetCurrentStamina);
    }

    private void SetCurrentStamina(IEvent staminaEvent) {
        if (staminaEvent is CurrentStaminaEvent cse) {
            staminaSlider.value = cse.CurrentStamina;
        }
    }
}

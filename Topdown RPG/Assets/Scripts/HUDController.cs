using System;
using UnityEngine;
using UnityEngine.UI;
using BoringSpace.Services;
using FrozenCircle.Core.Services;
using Object = UnityEngine.Object;

public class HUDController : MonoBehaviour {

    [SerializeField] 
    private Slider staminaSlider;
    private void Start() {
        ServiceLocator.GetService<EventManager>().RegisterListener<CurrentStaminaEvent>(SetCurrentStamina);
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
        ServiceLocator.GetService<EventManager>().UnregisterListener<CurrentStaminaEvent>(SetCurrentStamina);
    }

    private void SetCurrentStamina(IEvent staminaEvent) {
        if (staminaEvent is CurrentStaminaEvent cse) {
            staminaSlider.value = cse.CurrentStamina;
        }
    }
}

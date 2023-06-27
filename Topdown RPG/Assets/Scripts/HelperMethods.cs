using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperMethods {

    public static bool Approximation(float a, float b, float tolerance) {
        return (Mathf.Abs(a - b) < tolerance);
    }
}

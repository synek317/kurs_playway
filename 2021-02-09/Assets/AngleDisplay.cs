using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleDisplay : MonoBehaviour
{
    public GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var cosTheta = Vector3.Dot(transform.forward, other.transform.position.normalized);
        var theta = Mathf.Acos(cosTheta) * Mathf.Rad2Deg;

        var normalizedDirection = (other.transform.position - transform.position).normalized;
        var right = Vector3.Cross(transform.forward, transform.up);

        var leftRight = Vector3.Dot(normalizedDirection, right) > 0f ? "left" : "right";
        var frontBehind = Vector3.Dot(normalizedDirection, other.transform.forward) < 0 ? "behind" : "in front of";

        Debug.Log($"Theta (calculated): {theta}. Theta from unity: {Vector3.Angle(transform.forward, other.transform.position)}. Target is on the {leftRight}, {frontBehind}");
    }
}

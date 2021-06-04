using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private int length;
    [SerializeField] private Vector3[] segmentPoses;
    private Vector3[] segmentV;
    private LineRenderer lineRend;

    [SerializeField] private Transform targetDir;
    [SerializeField] private float targetDist;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float trailSpeed;

    private void Start() {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    private void Update() {
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++) {
            segmentPoses[i] = Vector3.SmoothDamp(
                segmentPoses[i], 
                segmentPoses[i - 1] + targetDir.right * targetDist, 
                ref segmentV[i], 
                smoothSpeed + i / trailSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}

using UnityEngine;

public class Other : MonoBehaviour {
    Quaternion rotations = new Quaternion();
    void Update () {
        rotations.eulerAngles = Vector3.zero;
        transform.rotation = rotations;
    }
}

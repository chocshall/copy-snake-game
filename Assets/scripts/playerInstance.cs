using UnityEngine;

public class Player : MonoBehaviour
{
    
    public static Player instance { get; private set; }
    
    void OnEnable() { instance = this; }

    void OnDisable() { instance = null; }

}

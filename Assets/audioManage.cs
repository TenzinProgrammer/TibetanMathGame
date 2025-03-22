using UnityEngine;
using UnityEngine.UI;

public class audioManage : MonoBehaviour
{
    private static audioManage instance;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }
}

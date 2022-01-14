using UnityEngine;

public class CloudShadows : MonoBehaviour
{
    public Material cloudShadowMaterial;
    private Vector3 lastCamPosition;
    private Camera mainCam;
    [Range(0, .03f)] public float scrollSpeedWhenMoving = .01f;
    [Range(0, .01f)] public float idleScrollSpeed = .0003f;
    public bool CamScroll;
    [Tooltip("Movement Directional Vector")]
    public Vector2 movementDirectionalVector = new Vector2(-1, -1);

    [Range(-.5f,.5f)] public float OpacityModifier = 0;
    void Start()
    {
        mainCam = Camera.main;
        cloudShadowMaterial.SetTextureOffset("_MainTex",mainCam.transform.position);
    }
    
    void FixedUpdate()
    {
        EnsureMovementValuesAreInRange();
        var camPosition = mainCam.transform.position;
        var currentOffset = cloudShadowMaterial.GetTextureOffset("_MainTex");
        
        if (camPosition!=lastCamPosition && CamScroll)
        {
            var positionChange = (lastCamPosition - camPosition)*scrollSpeedWhenMoving;
            currentOffset.x -= positionChange.x;
            currentOffset.y -= positionChange.y;
            lastCamPosition = camPosition;
        }
        
        cloudShadowMaterial.SetTextureOffset("_MainTex",currentOffset-(movementDirectionalVector*idleScrollSpeed));
        cloudShadowMaterial.SetFloat("_OpacityModifier",OpacityModifier);

    }

    void EnsureMovementValuesAreInRange()
    {
        movementDirectionalVector.x = Mathf.Clamp(movementDirectionalVector.x, -1, 1);
        movementDirectionalVector.y = Mathf.Clamp(movementDirectionalVector.y, -1, 1);
    }
}

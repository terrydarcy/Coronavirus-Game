using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector2 offset;
    public float smoothSpeed = 0.125f;
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10f;

    void Start () {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;

    }

    void FixedUpdate () {
        float scrollData = Input.GetAxis ("Mouse ScrollWheel");
        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp (targetZoom, -8f, 18f);
       cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom,Time.deltaTime * zoomLerpSpeed);

        Vector2 targetPos = new Vector2 (player.position.x, player.position.y) + offset;
        Vector2 lerpedPos = Vector2.Lerp (transform.position, targetPos, smoothSpeed);
        transform.position = targetPos;
        // transform.LookAt (player);
    }
}
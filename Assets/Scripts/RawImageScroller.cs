using UnityEngine;
using UnityEngine.UI;

public class RawImageScroller : MonoBehaviour
{
    [SerializeField] [Range(-2, 2)] float scrollSpeed = 0.5f;

    RawImage _rawImage;
    Rect _uvRect;
    float offset;

    void Start() => _rawImage = GetComponent<RawImage>();
    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        Rect modifiedRect = _rawImage.uvRect;
        modifiedRect.y -= scrollSpeed * Time.deltaTime;
        _rawImage.uvRect = modifiedRect;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class PopText : MonoBehaviour
{
    public float lifeTime = 0.4f;
    public Vector3 Offset = new Vector3(0,2,0);
    private Vector3 endPosition;
    private Vector3 baseScale;
    private ObjectPool<PopText> _pool;
    private TextMeshPro textMesh;
    void Awake()
    {
        baseScale = transform.localScale;
        transform.rotation = IsoMatrix.ToIso;
        textMesh = GetComponent<TextMeshPro>();
        textMesh.text = "helloooo";
        DontDestroyOnLoad(this.gameObject);
    }

    public void Init(Vector3 position, ObjectPool<PopText> pool, string amount)
    {
        _pool = pool;

        if (textMesh == null)
            Debug.Log("TextMeshProUGUI is null");

        textMesh.text = amount;

        transform.position = position;
        transform.localScale = baseScale;
        endPosition = position + Vector3.one;
        transform.position += Offset;

        Invoke(nameof(BackToPool), lifeTime);
    }

    private void BackToPool()
    {
        gameObject.SetActive(false);
        _pool.Release(this);
    }

    void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, endPosition, 0.2f);
        transform.localScale += -Vector3.one * Time.deltaTime * 0.5f;
    }
}

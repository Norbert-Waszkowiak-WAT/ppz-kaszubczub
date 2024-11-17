using System.Collections;
using UnityEngine;

public class Gracz : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float strength = 5f;

    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;
    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(AnimateSprite());
    }

    private void Update()
    {
        HandleInput();
        ApplyPhysics();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || 
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            direction = Vector3.up * strength;
        }
    }

    private void ApplyPhysics()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private IEnumerator AnimateSprite()
    {
        while (true)
        {
            spriteIndex = (spriteIndex + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[spriteIndex];
            yield return new WaitForSeconds(0.15f);
        }
    }
}

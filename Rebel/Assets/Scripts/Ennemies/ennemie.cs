using UnityEngine;

public class ennemie : MonoBehaviour
{

    [Range(0f, 5f)] [SerializeField] private float currentSpeed = 1f;
    private GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }
}

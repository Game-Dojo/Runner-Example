using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject placeholder;
    private enum Type
    {
        Oil,
        Cone,
        Hole
    }

    private void Start()
    {
        placeholder.SetActive(false);
        transform.GetChild(Random.Range(1, 3)).gameObject.SetActive(true);
    }
}

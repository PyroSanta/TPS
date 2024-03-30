using UnityEngine;
using UnityEngine.Events;

public class C0llectableItem : MonoBehaviour
{
    public UnityEvent action;
    public bool destroyAfterCollected = true;

    private void OnTriggerEnter(Collider other)
    {
        var controller = other.GetComponent<CharacterController>();
        if (!controller) return;

        action.Invoke();

        if (!destroyAfterCollected) return;
        Destroy(gameObject);
    }
}

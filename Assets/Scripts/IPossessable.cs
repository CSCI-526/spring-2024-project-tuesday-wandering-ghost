using UnityEngine;

public interface IPossessable
{
    void Move(Vector2 direction);
    void UpdateAnimation(Vector2 direction);
}

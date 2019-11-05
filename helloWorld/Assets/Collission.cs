using UnityEngine;

public class Collission : MonoBehaviour
{

  public PlayerMovement movement;
  void OnCollisionEnter(Collision collissionInfo)
  {
    if (collissionInfo.collider.tag == "Obstacle")
    {
      Debug.Log("Hit");
    }
  }
}

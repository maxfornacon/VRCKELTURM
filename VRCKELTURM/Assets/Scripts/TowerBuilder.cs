using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
  public static float startHeight;
  public static int layers;
  public static float scale;


  //link BrickTyp here in Unity
  public List<GameObject> bricks = new List<GameObject>();

  //spawn probability in % for each BrickTyp (musst be 100% in total)
  //List<int> probability = new List<int>();
  public static List<int> probability;

  //smallest possible random hightScaleVariation for Bricks
  //float variation = 0.98f;
  public static float variation;

  public static void setTowerSettings(
      float startHeight2,
      int layers2,
      float scale2,
      List<int> probability2,
      float variation2) {
    startHeight = startHeight2 + 0.1f;
    layers = layers2;
    scale = scale2;
    probability = probability2;
    variation = variation2;
  }

  void Start()
  {
    buildTower();
  }

  public void buildTower() {
    Debug.Log("Building Tower with " + layers + " Layers!");
    //Vector3 = (z, y, x) = (right, up, forward)
    float y = startHeight + 0.015f * scale / 2;
    for (int i = 0; i < layers; i++)
    {
      if(i%2 == 0)
      {
        buildBrick(false, -0.025f * scale, y, 0, scale); //left
        buildBrick(false, 0, y, 0, scale); //middle
        buildBrick(false, 0.025f * scale, y, 0, scale); //right
      }
      else
      {
        y = y + 0.015f * scale;
        buildBrick(true, 0, y, -0.025f * scale, scale); //rear
        buildBrick(true, 0, y, 0, scale); //middle
        buildBrick(true, 0, y, 0.025f * scale, scale); //front
        y = y + 0.015f * scale;
      }
    }
  }

  void buildBrick(bool rotate, float z, float y, float x, float scale)
  {
    Quaternion rotation;
    if(rotate)
    {
      rotation = new Quaternion(0, 1, 0, 1);
    }
    else
    {
      rotation = new Quaternion(0, 0, 0, 0);
    }
    GameObject brick = Instantiate(bricks[randomBrick()], new Vector3(z, y, x), rotation) as GameObject;
    brick.transform.localScale = new Vector3(scale, Random.Range(variation, 1) * scale, scale);
    //BoxCollider bC = brick.AddComponent<BoxCollider>() as BoxCollider;
    //Rigidbody rB = brick.AddComponent<Rigidbody>() as Rigidbody;
    //rB.AddForce(100 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    //OVRGrabbable ovrG = brick.AddComponent<OVRGrabbable>() as OVRGrabbable;
  }

  int randomBrick()
  {
    int random = Random.Range(0,100);
    int i = 0;
    int totalprob = probability[0];
    while(random >= totalprob)
    {
      i++;
      totalprob += probability[i];
    }
    return i;
  }
}

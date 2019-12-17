using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
  public GameObject woodBrick; //link BrickAsset here in Unity

  void Start()
  {
    buildTower(15, 0f, 5f); //number of layers for Tower, startHeight, scale of BrickAsset
  }

  void buildTower(int layers, float startHeight, float scale) {
    Debug.Log("Building Tower with " + layers + " Layers!");
    //Vector3 = (z, y, x) = (right, up, forward)
    float y = startHeight + 0.015f * scale / 2;
    for (int i = 0; i < layers; i++)
    {
      if(i%2 == 0)
      {
        buildBrick(woodBrick, false, -0.025f * scale, y, 0, scale); //left
        buildBrick(woodBrick, false, 0, y, 0, scale); //middle
        buildBrick(woodBrick, false, 0.025f * scale, y, 0, scale); //right
      }
      else
      {
        y = y + 0.015f * scale;
        buildBrick(woodBrick, true, 0, y, -0.025f * scale, scale); //rear
        buildBrick(woodBrick, true, 0, y, 0, scale); //middle
        buildBrick(woodBrick, true, 0, y, 0.025f * scale, scale); //front
        y = y + 0.015f * scale;
      }
    }
  }

  void buildBrick(GameObject brick, bool rotate, float z, float y, float x, float scale)
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
    brick = Instantiate(woodBrick, new Vector3(z, y, x), rotation) as GameObject;
    brick.transform.localScale = new Vector3(scale, scale, scale);
    //BoxCollider bC = brick.AddComponent<BoxCollider>() as BoxCollider;
    //Rigidbody rB = brick.AddComponent<Rigidbody>() as Rigidbody;
  }
}

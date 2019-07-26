using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Res
{
   public Object Asset;

   public string Name
   {
      get => Asset.name;
   }

   public Res(Object res)
   {
      Asset = res;
   }

   private int mReferenceCount = 0;

   public void Retain()
   {
      mReferenceCount++;
   }

   public void Release()
   {
      mReferenceCount--;
      if (mReferenceCount == 0)
      {
         Debug.Log("<color=purple>调用1次</color>");
         Resources.UnloadAsset(Asset);
         ResLoader.mResRecord.Remove(this);
         Asset = null;
      }
   }
   
   
}

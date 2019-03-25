using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaler : MonoInstaller
{
   //binding into conteiner

   public override void InstallBindings()
   {
     //  Container.Bind<ProtectedArea>().AsSingle();
   }
}

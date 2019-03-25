using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
[CreateAssetMenu(fileName = "ScriptableObjectInstaller",menuName = "Create ScriptObjInstaller")]
public class ScriptObjInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private GameConfig gameConfig;
//   [SerializeField]
//private ProtectedArea protectedArea;


    public override void InstallBindings()
    {
        Container.BindInstance(gameConfig);
       // Container.BindInstance(protectedArea);
    }
}

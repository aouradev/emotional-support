using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;

namespace EmotionalSupport
{

    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;

        public static AssetBundle bundle;
        public static GameObject car;

        void Start()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmotionalSupport.Resources.cmcat");
            bundle = AssetBundle.LoadFromStream(stream);
            if (stream == null)
            {
                Debug.LogError("STREAM IS NULL. NOT LOADING ASSETS");
            }
            stream.Close();

            car = Instantiate(bundle.LoadAsset<GameObject>("catP"));

            Mesh carM = bundle.LoadAsset<Mesh>("catmesh");
            Material catMat = bundle.LoadAsset<Material>("catM");

            Renderer carR = car.GetComponent<Renderer>();
            carR.material = catMat;

            MeshFilter carMeshFilter = car.GetComponent<MeshFilter>();

            carMeshFilter.sharedMesh = carM;

            Texture carT = bundle.LoadAsset<Texture>("catT");

            carR.material = catMat;
            catMat.mainTexture = carT;

            car.transform.position = new Vector3(-68.853f, 11.472f, -83.271f);
            car.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            car.transform.localRotation = Quaternion.Euler(new Vector3(-95, 90, 0));

            car.AddComponent<BoxCollider>();
            car.AddComponent<GorillaSurfaceOverride>();
            car.AddComponent<AudioSource>();
            car.AddComponent<Meow>();

            car.layer = 18;
            
            GorillaSurfaceOverride carGorillaSurfaceOverride = car.GetComponent<GorillaSurfaceOverride>();
            BoxCollider carBoxCollider = car.GetComponent<BoxCollider>();

            carGorillaSurfaceOverride.overrideIndex = 3;
            carBoxCollider.isTrigger = true;

            Debug.Log("car");
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

namespace LCVR.Assets
{
    public class AssetManager
    {
        private static AssetBundle assetBundle;

        public static GameObject aLiteralCube;
        public static GameObject cockroach;
        public static GameObject keyboard;
        public static GameObject leftHand;
        public static GameObject rightHand;

        public static Material defaultRayMat;
        public static Material alwaysOnTopMat;

        public static InputActionAsset defaultInputActions;

        public static RuntimeAnimatorController localVrMetarig;
        public static RuntimeAnimatorController remoteVrMetarig;

        public static Sprite githubImage;
        public static Sprite kofiImage;

        public static bool LoadAssets()
        {
            assetBundle = AssetBundle.LoadFromMemory(Properties.Resources.lethalcompanyvr);
            var handsBundle = AssetBundle.LoadFromMemory(Properties.Resources.hands);
            var animatorBundle = AssetBundle.LoadFromMemory(Properties.Resources.animator);

            if (assetBundle == null)
            {
                Logger.LogError("Failed to load asset bundle!");
                return false;
            }

            if (handsBundle == null)
            {
                Logger.LogError("Failed to load hands asset bundle!");
                return false;
            }

            aLiteralCube = assetBundle.LoadAsset<GameObject>("ALiteralCube");
            cockroach = assetBundle.LoadAsset<GameObject>("Cockroach");
            keyboard = assetBundle.LoadAsset<GameObject>("NonNativeKeyboard");
            defaultInputActions = assetBundle.LoadAsset<InputActionAsset>("XR Input Actions");
            defaultRayMat = assetBundle.LoadAsset<Material>("Default Ray");
            alwaysOnTopMat = assetBundle.LoadAsset<Material>("Always On Top");
            githubImage = assetBundle.LoadAsset<Sprite>("Github");
            kofiImage = assetBundle.LoadAsset<Sprite>("Ko-Fi");
            leftHand = handsBundle.LoadAsset<GameObject>("Left Hand Model");
            rightHand = handsBundle.LoadAsset<GameObject>("Right Hand Model");
            localVrMetarig = animatorBundle.LoadAsset<RuntimeAnimatorController>("metarig");
            remoteVrMetarig = animatorBundle.LoadAsset<RuntimeAnimatorController>("metarigOtherPlayers");

            return true;
        }
    }
}

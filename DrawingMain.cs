using System;
using BepInEx;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static MonkeDrawing.GUIDInfo;

namespace MonkeDrawing
{
    [BepInPlugin(MonkeDrawing.GUIDInfo.Guid, Name, MonkeDrawing.GUIDInfo.Version)]
    public class DrawingMain : BaseUnityPlugin
    {
        private bool allowed;
        bool padmade = false;

        // Variables GO, TMP
        public GameObject MainBaseGameOBJ,
            InnerBaseGameOBJ,
            TitleGameOBJ,
            ColorSelectTextGameOBJ,
            SettingsTextGameOBJ,
            ButtonGameOBJ,
            Button1GameOBJ,
            Button2GameOBJ,
            Button3GameOBJ,
            Button4GameOBJ,
            Button5GameOBJ,
            Button6GameOBJ,
            Button7GameOBJ,
            Button8GameOBJ,
            Button9GameOBJ,
            Button10GameOBJ,
            Button11GameOBJ,
            Button12GameOBJ,
            Button13GameOBJ,
            ButtonTextGameOBJ,
            ButtonText1GameOBJ,
            ButtonText2GameOBJ,
            ButtonText3GameOBJ,
            ButtonText4GameOBJ,
            ButtonText5GameOBJ,
            ButtonText6GameOBJ,
            ButtonText7GameOBJ,
            ButtonText8GameOBJ,
            ButtonText9GameOBJ,
            ButtonText10GameOBJ,
            ButtonText11GameOBJ,
            ButtonText12GameOBJ,
            ButtonText13GameOBJ;

        public TextMeshPro TitleTMP,
            ColorSelectTextTMP,
            SettingsTextTMP,
            ButtonTextTMP,
            ButtonText1TMP,
            ButtonText2TMP,
            ButtonText3TMP,
            ButtonText4TMP,
            ButtonText5TMP,
            ButtonText6TMP,
            ButtonText7TMP,
            ButtonText8TMP,
            ButtonText9TMP,
            ButtonText10TMP,
            ButtonText11TMP,
            ButtonText12TMP,
            ButtonText13TMP;


        public static DrawingMain Instance; // used in my info board, good trick tbh



        public PrimitiveType Type = PrimitiveType.Sphere;
        public Vector3 sizeDrawing = new Vector3(0.1f, 0.1f, 0.1f);
        public bool DontCollide = true;
        public int Color = 7;

        public void Create(Transform parent = null)
        {

            DrawingMain.Instance = this;

            // Create MainBase
            MainBaseGameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            MainBaseGameOBJ.name = "MainBase";
            if (parent != null)
            {
                MainBaseGameOBJ.transform.SetParent(parent);
                MainBaseGameOBJ.transform.localPosition = new Vector3(0f, 0.09158f, -0.015906f);
                MainBaseGameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            }
            else
            {
                MainBaseGameOBJ.transform.position = GorillaTagger.Instance.bodyCollider.transform.position;
            }

            MainBaseGameOBJ.transform.localScale = new Vector3(0.2962051f, 0.3311441f, 0.01031929f);

            // Renderer Setup
            Renderer rend_MainBase = MainBaseGameOBJ.GetComponent<Renderer>();
            if (rend_MainBase != null)
            {
                rend_MainBase.material.shader = Shader.Find("GorillaTag/UberShader");
            }

            // Create InnerBase
            InnerBaseGameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            InnerBaseGameOBJ.name = "InnerBase";
            InnerBaseGameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            InnerBaseGameOBJ.transform.localPosition = new Vector3(0f, 0f, 0f);
            InnerBaseGameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            InnerBaseGameOBJ.transform.localScale = new Vector3(0.92045f, 0.92045f, 1.223705f);

            // Renderer Setup
            Renderer rend_InnerBase = InnerBaseGameOBJ.GetComponent<Renderer>();
            if (rend_InnerBase != null)
            {
                rend_InnerBase.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_InnerBase.material.color = new Color(0f, 0f, 0f, 1f);
            }

            // Create Title
            TitleGameOBJ = new GameObject("Title");
            TitleGameOBJ.name = "Title";
            TitleGameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            TitleGameOBJ.transform.localPosition = new Vector3(-0.023f, 0.57f, -0.8f);
            TitleGameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            TitleGameOBJ.transform.localScale = new Vector3(0.0293647f, 0.02505622f, 0.0293647f);

            // TMP Setup
            TitleTMP = TitleGameOBJ.GetComponent<TextMeshPro>();
            if (TitleTMP == null)
                TitleTMP = TitleGameOBJ.AddComponent<TextMeshPro>();
            TitleTMP.text = "Drawing Tablet";
            TitleTMP.fontSize = 30f;
            TitleTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_Title = TitleGameOBJ.GetComponent<Renderer>();
            if (rend_Title != null)
            {
            }

            // Create ColorSelectText
            ColorSelectTextGameOBJ = new GameObject("ColorSelectText");
            ColorSelectTextGameOBJ.name = "ColorSelectText";
            ColorSelectTextGameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ColorSelectTextGameOBJ.transform.localPosition = new Vector3(0.019f, 0.333f, -0.8f);
            ColorSelectTextGameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ColorSelectTextGameOBJ.transform.localScale = new Vector3(0.0293647f, 0.02505622f, 0.0293647f);

            // TMP Setup
            ColorSelectTextTMP = ColorSelectTextGameOBJ.GetComponent<TextMeshPro>();
            if (ColorSelectTextTMP == null)
                ColorSelectTextTMP = ColorSelectTextGameOBJ.AddComponent<TextMeshPro>();
            ColorSelectTextTMP.text = "Color Select!";
            ColorSelectTextTMP.fontSize = 30f;
            ColorSelectTextTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ColorSelectText = ColorSelectTextGameOBJ.GetComponent<Renderer>();
            if (rend_ColorSelectText != null)
            {
            }

            // Create settingsText
            SettingsTextGameOBJ = new GameObject("settingsText");
            SettingsTextGameOBJ.name = "settingsText";
            SettingsTextGameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            SettingsTextGameOBJ.transform.localPosition = new Vector3(0.069f, -0.159f, -0.8f);
            SettingsTextGameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            SettingsTextGameOBJ.transform.localScale = new Vector3(0.0293647f, 0.02505622f, 0.0293647f);

            // TMP Setup
            SettingsTextTMP = SettingsTextGameOBJ.GetComponent<TextMeshPro>();
            if (SettingsTextTMP == null)
                SettingsTextTMP = SettingsTextGameOBJ.AddComponent<TextMeshPro>();
            SettingsTextTMP.text = "Settings:";
            SettingsTextTMP.fontSize = 30f;
            SettingsTextTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_SettingsText = SettingsTextGameOBJ.GetComponent<Renderer>();
            if (rend_SettingsText != null)
            {
            }

            // Create Button
            ButtonGameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ButtonGameOBJ.name = "Button";
            ButtonGameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonGameOBJ.transform.localPosition = new Vector3(-0.166f, 0.213f, -0.61f);
            ButtonGameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonGameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            ButtonGameOBJ.AddComponent<GreenColorButton>();

            // Renderer Setup
            Renderer rend_Button = ButtonGameOBJ.GetComponent<Renderer>();
            if (rend_Button != null)
            {
                rend_Button.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button.material.color = new Color(0f, 1f, 0f, 1f);
            }

            // Create Button
            Button1GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button1GameOBJ.name = "Button";
            Button1GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button1GameOBJ.transform.localPosition = new Vector3(-0.012f, 0.213f, -0.61f);
            Button1GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button1GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button1GameOBJ.AddComponent<CyanColorButton>();

            // Renderer Setup
            Renderer rend_Button1 = Button1GameOBJ.GetComponent<Renderer>();
            if (rend_Button1 != null)
            {
                rend_Button1.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button1.material.color = new Color(0f, 1f, 1f, 1f);
            }

            // Create Button
            Button2GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button2GameOBJ.name = "Button";
            Button2GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button2GameOBJ.transform.localPosition = new Vector3(0.134f, 0.213f, -0.61f);
            Button2GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button2GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button2GameOBJ.AddComponent<GreyColorButton>();

            // Renderer Setup
            Renderer rend_Button2 = Button2GameOBJ.GetComponent<Renderer>();
            if (rend_Button2 != null)
            {
                rend_Button2.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button2.material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            }

            // Create Button
            Button3GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button3GameOBJ.name = "Button";
            Button3GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button3GameOBJ.transform.localPosition = new Vector3(0.286f, 0.213f, -0.61f);
            Button3GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button3GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button3GameOBJ.AddComponent<PureBlackColorButton>();

            // Renderer Setup
            Renderer rend_Button3 = Button3GameOBJ.GetComponent<Renderer>();
            if (rend_Button3 != null)
            {
                rend_Button3.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button3.material.color = new Color(0f, 0f, 0f, 1f);
            }

            // Create Button
            Button4GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button4GameOBJ.name = "Button";
            Button4GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button4GameOBJ.transform.localPosition = new Vector3(0.192f, 0.113f, -0.61f);
            Button4GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button4GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button4GameOBJ.AddComponent<YellowColorButton>();

            // Renderer Setup
            Renderer rend_Button4 = Button4GameOBJ.GetComponent<Renderer>();
            if (rend_Button4 != null)
            {
                rend_Button4.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button4.material.color = new Color(1f, 0.9215686f, 0.01568628f, 1f);
            }

            // Create Button
            Button5GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button5GameOBJ.name = "Button";
            Button5GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button5GameOBJ.transform.localPosition = new Vector3(0.05500004f, 0.113f, -0.61f);
            Button5GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button5GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button5GameOBJ.AddComponent<PureBlueColorButton>();


            // Renderer Setup
            Renderer rend_Button5 = Button5GameOBJ.GetComponent<Renderer>();
            if (rend_Button5 != null)
            {
                rend_Button5.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button5.material.color = new Color(0f, 0f, 1f, 1f);
            }

            // Create Button
            Button6GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button6GameOBJ.name = "Button";
            Button6GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button6GameOBJ.transform.localPosition = new Vector3(-0.101f, 0.113f, -0.61f);
            Button6GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button6GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button6GameOBJ.AddComponent<MagentaColorButton>();

            // Renderer Setup
            Renderer rend_Button6 = Button6GameOBJ.GetComponent<Renderer>();
            if (rend_Button6 != null)
            {
                rend_Button6.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button6.material.color = new Color(1f, 0f, 1f, 1f);
            }

            // Create Button
            Button7GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button7GameOBJ.name = "Button";
            Button7GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button7GameOBJ.transform.localPosition = new Vector3(-0.253f, 0.113f, -0.61f);
            Button7GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button7GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button7GameOBJ.AddComponent<WhiteColorButton>();

            // Renderer Setup
            Renderer rend_Button7 = Button7GameOBJ.GetComponent<Renderer>();
            if (rend_Button7 != null)
            {
                rend_Button7.material.shader = Shader.Find("GorillaTag/UberShader");
            }

            // Create Button
            Button8GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button8GameOBJ.name = "Button";
            Button8GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button8GameOBJ.transform.localPosition = new Vector3(-0.269f, -0.243f, -0.61f);
            Button8GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button8GameOBJ.transform.localScale = new Vector3(0.219033f, 0.07693783f, 1f);
            Button8GameOBJ.AddComponent<AddSize>();

            // Renderer Setup
            Renderer rend_Button8 = Button8GameOBJ.GetComponent<Renderer>();
            if (rend_Button8 != null)
            {
                rend_Button8.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button8.material.color = new Color(0f, 1f, 0f, 1f);
            }

            // Create Button
            Button9GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button9GameOBJ.name = "Button";
            Button9GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button9GameOBJ.transform.localPosition = new Vector3(-0.271f, -0.347f, -0.61f);
            Button9GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button9GameOBJ.transform.localScale = new Vector3(0.219033f, 0.07693783f, 1f);
            Button9GameOBJ.AddComponent<RemoveSize>();

            // Renderer Setup
            Renderer rend_Button9 = Button9GameOBJ.GetComponent<Renderer>();
            if (rend_Button9 != null)
            {
                rend_Button9.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button9.material.color = new Color(1f, 0f, 0f, 1f);
            }

            // Create Button
            Button10GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button10GameOBJ.name = "Button";
            Button10GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button10GameOBJ.transform.localPosition = new Vector3(-0.005f, -0.303f, -0.61f);
            Button10GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button10GameOBJ.transform.localScale = new Vector3(0.219033f, 0.07693783f, 1f);
            Button10GameOBJ.AddComponent<ColliderDrawONOFF>();

            // Renderer Setup
            Renderer rend_Button10 = Button10GameOBJ.GetComponent<Renderer>();
            if (rend_Button10 != null)
            {
                rend_Button10.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button10.material.color = new Color(1f, 0.9215686f, 0.01568628f, 1f);
            }

            // Create Button
            Button11GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button11GameOBJ.name = "Button";
            Button11GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button11GameOBJ.transform.localPosition = new Vector3(0.293f, -0.236f, -0.61f);
            Button11GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button11GameOBJ.transform.localScale = new Vector3(0.219033f, 0.07693783f, 1f);
            Button11GameOBJ.AddComponent<TypeOFDraw>();

            // Renderer Setup
            Renderer rend_Button11 = Button11GameOBJ.GetComponent<Renderer>();
            if (rend_Button11 != null)
            {
                rend_Button11.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button11.material.color = new Color(1f, 1f, 1f, 1f);
            }

            // Create Button
            Button13GameOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Button13GameOBJ.name = "Button";
            Button13GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            Button13GameOBJ.transform.localPosition = new Vector3(-0.316f, 0.213f, -0.6100001f);
            Button13GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            Button13GameOBJ.transform.localScale = new Vector3(0.1209325f, 0.07693783f, 1f);
            Button13GameOBJ.AddComponent<RedColorButton>();


            // Renderer Setup
            Renderer rend_Button13 = Button13GameOBJ.GetComponent<Renderer>();
            if (rend_Button13 != null)
            {
                rend_Button13.material.shader = Shader.Find("GorillaTag/UberShader");
                rend_Button13.material.color = new Color(1f, 0f, 0f, 1f);
            }

            // Create ButtonText
            ButtonTextGameOBJ = new GameObject("ButtonText");
            ButtonTextGameOBJ.name = "ButtonText";
            ButtonTextGameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonTextGameOBJ.transform.localPosition = new Vector3(-0.265f, 0.2074f, -1.28f);
            ButtonTextGameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonTextGameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonTextTMP = ButtonTextGameOBJ.GetComponent<TextMeshPro>();
            if (ButtonTextTMP == null)
                ButtonTextTMP = ButtonTextGameOBJ.AddComponent<TextMeshPro>();
            ButtonTextTMP.text = "Red";
            ButtonTextTMP.fontSize = 30f;
            ButtonTextTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText = ButtonTextGameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText != null)
            {
            }

            // Create ButtonText
            ButtonText1GameOBJ = new GameObject("ButtonText");
            ButtonText1GameOBJ.name = "ButtonText";
            ButtonText1GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText1GameOBJ.transform.localPosition = new Vector3(-0.12f, 0.2074f, -1.28f);
            ButtonText1GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText1GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText1TMP = ButtonText1GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText1TMP == null)
                ButtonText1TMP = ButtonText1GameOBJ.AddComponent<TextMeshPro>();
            ButtonText1TMP.text = "Green";
            ButtonText1TMP.fontSize = 30f;
            ButtonText1TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText1 = ButtonText1GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText1 != null)
            {
            }

            // Create ButtonText
            ButtonText2GameOBJ = new GameObject("ButtonText");
            ButtonText2GameOBJ.name = "ButtonText";
            ButtonText2GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText2GameOBJ.transform.localPosition = new Vector3(0.038f, 0.2074f, -1.28f);
            ButtonText2GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText2GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText2TMP = ButtonText2GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText2TMP == null)
                ButtonText2TMP = ButtonText2GameOBJ.AddComponent<TextMeshPro>();
            ButtonText2TMP.text = "Cyan";
            ButtonText2TMP.fontSize = 30f;
            ButtonText2TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText2 = ButtonText2GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText2 != null)
            {
            }

            // Create ButtonText
            ButtonText3GameOBJ = new GameObject("ButtonText");
            ButtonText3GameOBJ.name = "ButtonText";
            ButtonText3GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText3GameOBJ.transform.localPosition = new Vector3(0.186f, 0.2074f, -1.28f);
            ButtonText3GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText3GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText3TMP = ButtonText3GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText3TMP == null)
                ButtonText3TMP = ButtonText3GameOBJ.AddComponent<TextMeshPro>();
            ButtonText3TMP.text = "Grey";
            ButtonText3TMP.fontSize = 30f;
            ButtonText3TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText3 = ButtonText3GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText3 != null)
            {
            }

            // Create ButtonText
            ButtonText4GameOBJ = new GameObject("ButtonText");
            ButtonText4GameOBJ.name = "ButtonText";
            ButtonText4GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText4GameOBJ.transform.localPosition = new Vector3(0.301f, 0.2074f, -1.28f);
            ButtonText4GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText4GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText4TMP = ButtonText4GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText4TMP == null)
                ButtonText4TMP = ButtonText4GameOBJ.AddComponent<TextMeshPro>();
            ButtonText4TMP.text = "Pure Black";
            ButtonText4TMP.fontSize = 30f;
            ButtonText4TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText4 = ButtonText4GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText4 != null)
            {
            }

            // Create ButtonText
            ButtonText5GameOBJ = new GameObject("ButtonText");
            ButtonText5GameOBJ.name = "ButtonText";
            ButtonText5GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText5GameOBJ.transform.localPosition = new Vector3(0.233f, 0.1083f, -1.28f);
            ButtonText5GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText5GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText5TMP = ButtonText5GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText5TMP == null)
                ButtonText5TMP = ButtonText5GameOBJ.AddComponent<TextMeshPro>();
            ButtonText5TMP.text = "Yellow";
            ButtonText5TMP.fontSize = 30f;
            ButtonText5TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText5 = ButtonText5GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText5 != null)
            {
            }

            // Create ButtonText
            ButtonText6GameOBJ = new GameObject("ButtonText");
            ButtonText6GameOBJ.name = "ButtonText";
            ButtonText6GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText6GameOBJ.transform.localPosition = new Vector3(0.085f, 0.1083f, -1.28f);
            ButtonText6GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText6GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText6TMP = ButtonText6GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText6TMP == null)
                ButtonText6TMP = ButtonText6GameOBJ.AddComponent<TextMeshPro>();
            ButtonText6TMP.text = "Pure Blue";
            ButtonText6TMP.fontSize = 30f;
            ButtonText6TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText6 = ButtonText6GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText6 != null)
            {
            }

            // Create ButtonText
            ButtonText7GameOBJ = new GameObject("ButtonText");
            ButtonText7GameOBJ.name = "ButtonText";
            ButtonText7GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText7GameOBJ.transform.localPosition = new Vector3(-0.071f, 0.1083f, -1.28f);
            ButtonText7GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText7GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText7TMP = ButtonText7GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText7TMP == null)
                ButtonText7TMP = ButtonText7GameOBJ.AddComponent<TextMeshPro>();
            ButtonText7TMP.text = "Magenta";
            ButtonText7TMP.fontSize = 30f;
            ButtonText7TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText7 = ButtonText7GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText7 != null)
            {
            }

            // Create ButtonText
            ButtonText8GameOBJ = new GameObject("ButtonText");
            ButtonText8GameOBJ.name = "ButtonText";
            ButtonText8GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText8GameOBJ.transform.localPosition = new Vector3(-0.1969999f, 0.1083f, -1.28f);
            ButtonText8GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText8GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText8TMP = ButtonText8GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText8TMP == null)
                ButtonText8TMP = ButtonText8GameOBJ.AddComponent<TextMeshPro>();
            ButtonText8TMP.text = "White";
            ButtonText8TMP.color = UnityEngine.Color.black;
            ButtonText8TMP.fontSize = 30f;
            ButtonText8TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText8 = ButtonText8GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText8 != null)
            {
            }

            // Create ButtonText
            ButtonText9GameOBJ = new GameObject("ButtonText");
            ButtonText9GameOBJ.name = "ButtonText";
            ButtonText9GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText9GameOBJ.transform.localPosition = new Vector3(-0.2446f, -0.2258f, -1.28f);
            ButtonText9GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText9GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText9TMP = ButtonText9GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText9TMP == null)
                ButtonText9TMP = ButtonText9GameOBJ.AddComponent<TextMeshPro>();
            ButtonText9TMP.text = " Add Size";
            ButtonText9TMP.fontSize = 30f;
            ButtonText9TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText9 = ButtonText9GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText9 != null)
            {
            }

            // Create ButtonText
            ButtonText10GameOBJ = new GameObject("ButtonText");
            ButtonText10GameOBJ.name = "ButtonText";
            ButtonText10GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText10GameOBJ.transform.localPosition = new Vector3(-0.2592f, -0.351f, -1.28f);
            ButtonText10GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText10GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText10TMP = ButtonText10GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText10TMP == null)
                ButtonText10TMP = ButtonText10GameOBJ.AddComponent<TextMeshPro>();
            ButtonText10TMP.text = "Remove Size";
            ButtonText10TMP.fontSize = 30f;
            ButtonText10TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText10 = ButtonText10GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText10 != null)
            {
            }

            // Create ButtonText
            ButtonText11GameOBJ = new GameObject("ButtonText");
            ButtonText11GameOBJ.name = "ButtonText";
            ButtonText11GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText11GameOBJ.transform.localPosition = new Vector3(0.0345f, -0.303f, -1.28f);
            ButtonText11GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText11GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText11TMP = ButtonText11GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText11TMP == null)
                ButtonText11TMP = ButtonText11GameOBJ.AddComponent<TextMeshPro>();
            ButtonText11TMP.text = "Collide?";
            ButtonText11TMP.fontSize = 30f;
            ButtonText11TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText11 = ButtonText11GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText11 != null)
            {
            }

            // Create ButtonText
            ButtonText12GameOBJ = new GameObject("ButtonText");
            ButtonText12GameOBJ.name = "ButtonText";
            ButtonText12GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText12GameOBJ.transform.localPosition = new Vector3(0.3398f, -0.334f, -1.28f);
            ButtonText12GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText12GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText12TMP = ButtonText12GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText12TMP == null)
                ButtonText12TMP = ButtonText12GameOBJ.AddComponent<TextMeshPro>();
            ButtonText12TMP.text = Type.ToString();
            ButtonText12TMP.fontSize = 30f;
            ButtonText12TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText12 = ButtonText12GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText12 != null)
            {
            }

            // Create ButtonText
            ButtonText13GameOBJ = new GameObject("ButtonText");
            ButtonText13GameOBJ.name = "ButtonText";
            ButtonText13GameOBJ.transform.SetParent(MainBaseGameOBJ.transform);
            ButtonText13GameOBJ.transform.localPosition = new Vector3(0.3388f, -0.235f, -1.28f);
            ButtonText13GameOBJ.transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
            ButtonText13GameOBJ.transform.localScale = new Vector3(0.007671689f, 0.006546075f, 0.007671689f);

            // TMP Setup
            ButtonText13TMP = ButtonText13GameOBJ.GetComponent<TextMeshPro>();
            if (ButtonText13TMP == null)
                ButtonText13TMP = ButtonText13GameOBJ.AddComponent<TextMeshPro>();
            ButtonText13TMP.text = "Change Drawing Type";
            ButtonText13TMP.color = UnityEngine.Color.black;
            ButtonText13TMP.fontSize = 30f;
            ButtonText13TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;

            // Renderer Setup
            Renderer rend_ButtonText13 = ButtonText13GameOBJ.GetComponent<Renderer>();
            if (rend_ButtonText13 != null)
            {
            }

            Destroy(MainBaseGameOBJ.GetComponent<Collider>());
            Destroy(InnerBaseGameOBJ.GetComponent<Collider>());
            Destroy(TitleGameOBJ.GetComponent<Collider>());
            Destroy(ColorSelectTextGameOBJ.GetComponent<Collider>());
            Destroy(SettingsTextGameOBJ.GetComponent<Collider>());

        }










        private void Awake()
        {
            GorillaTagger.OnPlayerSpawned(Init);
        }

        void Init()
        {
            // you on game start functions here

            Debug.Log("game initialized");

            // subscribe to join/leave room events
            NetworkSystem.Instance.OnMultiplayerStarted += JoinedRoom;
            NetworkSystem.Instance.OnReturnedToSinglePlayer += OnLeaveRoom;













        }

        void FixedUpdate()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed && allowed)
            {

                GameObject CreatePrimitive(PrimitiveType type) // REDDIT found on there
                {
                    GameObject temp = GameObject.CreatePrimitive(type);
                    Mesh mesh = temp.GetComponent<MeshFilter>().sharedMesh;
                    Material mat = temp.GetComponent<Renderer>().sharedMaterial;
                    Destroy(temp);
                    GameObject go = new GameObject(type.ToString());
                    go.AddComponent<MeshFilter>().sharedMesh = mesh;
                    go.AddComponent<MeshRenderer>().sharedMaterial = mat;
                    return go;
                }

                GameObject cube;

                if (DontCollide)
                {
                    cube = CreatePrimitive(Type);
                }
                else
                {
                    cube = GameObject.CreatePrimitive(Type);
                }

                cube.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                cube.transform.localScale = sizeDrawing;
                Renderer rend = cube.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("GorillaTag/UberShader");
                if (Color == 1)
                {
                    rend.material.color = UnityEngine.Color.red;
                }
                else if (Color == 2)
                {
                    rend.material.color = UnityEngine.Color.green;
                }
                else if (Color == 3)
                {
                    rend.material.color = UnityEngine.Color.cyan;
                }
                else if (Color == 4)
                {
                    rend.material.color = UnityEngine.Color.gray;
                }
                else if (Color == 5)
                {
                    rend.material.color = UnityEngine.Color.black;
                }
                else if (Color == 6)
                {
                    rend.material.color = UnityEngine.Color.white;
                }
                else if (Color == 7)
                {
                    rend.material.color = UnityEngine.Color.magenta;
                }
                else if (Color == 8)
                {
                    rend.material.color = UnityEngine.Color.blue;
                }
                else if (Color == 9)
                {
                    rend.material.color = UnityEngine.Color.yellow;
                }

                Vector3 offset = -GorillaTagger.Instance.rightHandTransform.right * 0.12f;



            }

            if (Mouse.current.rightButton.isPressed || ControllerInputPoller.instance.leftControllerPrimaryButton && allowed)
                {
                    if (padmade && allowed)
                    {
                        MainBaseGameOBJ.transform.position = Vector3.Lerp(MainBaseGameOBJ.transform.position,
                            GorillaTagger.Instance.leftHandTransform.position, Time.deltaTime * 6f);
                        MainBaseGameOBJ.transform.localRotation =
                            GorillaTagger.Instance.leftHandTransform.localRotation * Quaternion.Euler(180f, 90f, 450f);
                    }
                    else if (allowed)
                    {
                        Create();
                        padmade = true;
                        
                    }
               
            }
            else if (padmade && allowed)
            {
                Destroy(MainBaseGameOBJ);
                padmade = false;
                
            }
        }

        void JoinedRoom()
        {
            allowed = NetworkSystem.Instance.GameModeString.Contains("MODDED");
            if (allowed)
            {
                // enable your mod here
            }
        }

        void OnLeaveRoom()
        {
            allowed = false;
            // disable/cleanup your mod here
        }

        private void OnGUI()
        {

            if (GUI.Button(new Rect(10, 300, 80, 30), "Red"))
            {
                Color = 1;
            }

            if (GUI.Button(new Rect(10, 335, 80, 30), "Green"))
            {
                Color = 2;
            }

            if (GUI.Button(new Rect(10, 370, 80, 30), "Cyan"))
            {
                Color = 3;
            }

            if (GUI.Button(new Rect(10, 405, 80, 30), "Grey"))
            {
                Color = 4;
            }

            if (GUI.Button(new Rect(10, 440, 80, 30), "Black"))
            {
                Color = 5;
            }

            if (GUI.Button(new Rect(10, 475, 80, 30), "White"))
            {
                Color = 6;
            }

            if (GUI.Button(new Rect(10, 510, 80, 30), "Magenta"))
            {
                Color = 7;
            }

            if (GUI.Button(new Rect(10, 545, 80, 30), "Blue"))
            {
                Color = 8;
            }

            if (GUI.Button(new Rect(10, 580, 80, 30), "Yellow"))
            {
                Color = 9;
            }
            if (GUI.Button(new Rect(100, 300, 60, 30), "Size +"))
            {
                sizeDrawing += new Vector3(0.05f, 0.05f, 0.05f);
            }

            if (GUI.Button(new Rect(100, 335, 60, 30), "Size -"))
            {
                sizeDrawing -= new Vector3(0.05f, 0.05f, 0.05f);
            }
            if (GUI.Button(new Rect(100, 370, 60, 30), "Collide"))
            {
                DontCollide = !DontCollide;
            }
            
            if (GUI.Button(new Rect(100, 405, 60, 30), "Type"))
            {
                if (Type == PrimitiveType.Cube)
                {
                    Type = PrimitiveType.Sphere;
                }
                else if (Type == PrimitiveType.Sphere)
                {
                    Type = PrimitiveType.Plane;
                }
                else if (Type == PrimitiveType.Plane)
                {
                    Type = PrimitiveType.Quad;
                }
                else if (Type == PrimitiveType.Quad)
                {
                    Type = PrimitiveType.Cylinder;
                }
                else if (Type == PrimitiveType.Cylinder)
                {
                    Type = PrimitiveType.Capsule;
                }
                else if (Type == PrimitiveType.Capsule)
                {
                    Type = PrimitiveType.Cube;
                }
                else
                {
                    Type = PrimitiveType.Cube;
                }
            }

        }

    }
}


// HOLY FUCK BASICALLY 1K LINES!!
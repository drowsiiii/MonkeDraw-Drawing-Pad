using UnityEngine;

namespace MonkeDrawing
{
    public class RedColorButton : GorillaPressableButton
    {
       
        public override void Start()
        {
            
            gameObject.layer = 18;
            
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 1;
        }
    }

    public class GreenColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 2;
        }
    }

    public class CyanColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 3;
        }
    }

    public class GreyColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 4;
        }
    }

    public class PureBlackColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 5;
        }
    }

    public class WhiteColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 6;
        }
    }

    public class MagentaColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 7;
        }
    }

    public class PureBlueColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 8;
        }
    }

    public class YellowColorButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.Color = 9;
        }
    }

    public class ColliderDrawONOFF : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.DontCollide = !DrawingMain.Instance.DontCollide;
        }
    }
    public class TypeOFDraw : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            if (DrawingMain.Instance.Type == PrimitiveType.Cube)
            {
                DrawingMain.Instance.Type = PrimitiveType.Sphere;
            }
            else if (DrawingMain.Instance.Type == PrimitiveType.Sphere)
            {
                DrawingMain.Instance.Type = PrimitiveType.Plane;
            }
            else if (DrawingMain.Instance.Type == PrimitiveType.Plane)
            {
                DrawingMain.Instance.Type = PrimitiveType.Quad;
            }
            else if (DrawingMain.Instance.Type == PrimitiveType.Quad)
            {
                DrawingMain.Instance.Type = PrimitiveType.Cylinder;
            }
            else if (DrawingMain.Instance.Type == PrimitiveType.Cylinder)
            {
                DrawingMain.Instance.Type = PrimitiveType.Capsule;
            }
            else if (DrawingMain.Instance.Type == PrimitiveType.Capsule)
            {
                DrawingMain.Instance.Type = PrimitiveType.Cube;
            }
            else
            {
                DrawingMain.Instance.Type = PrimitiveType.Cube;
            }
            
            
           DrawingMain.Instance.ButtonText12TMP.text = DrawingMain.Instance.Type.ToString();
        }
    }
    public class AddSize : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.sizeDrawing += new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
    public class RemoveSize : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            DrawingMain.Instance.sizeDrawing -= new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
   

}

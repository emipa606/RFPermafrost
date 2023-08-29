using UnityEngine;
using Verse;

namespace RPF_Code;

public class Controller : Mod
{
    public static Settings Settings;

    public Controller(ModContentPack content) : base(content)
    {
        Settings = GetSettings<Settings>();
    }

    public override string SettingsCategory()
    {
        return "RPF.Permafrost".Translate();
    }

    public override void DoSettingsWindowContents(Rect canvas)
    {
        Settings.DoWindowContents(canvas);
    }
}
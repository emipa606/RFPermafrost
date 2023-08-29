using UnityEngine;
using Verse;

namespace RPF_Code;

public class Settings : ModSettings
{
    public bool waterFreezes = true;

    public void DoWindowContents(Rect canvas)
    {
        var list = new Listing_Standard
        {
            ColumnWidth = canvas.width
        };
        list.Begin(canvas);
        list.Gap();
        list.CheckboxLabeled("RPF.WaterFreezes".Translate(), ref waterFreezes, "RPF.WaterFreezesTip".Translate());
        list.Gap();
        list.End();
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref waterFreezes, "waterFreezes", true);
    }
}
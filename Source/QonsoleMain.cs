using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Qon {


[StaticConstructorOnStartup]
public static class QonsoleMain {

    // this is a Qonsole variable
    [Description( "Demo a dynamic QGL message." )]
    static bool ShowQglMessage_kvar = false;
    [Description( "Show dynamic draws classes." )]
    static bool ShowDynamicDraws_kvar = false;

    static QonsoleMain() {
        try {

        Qonsole.CreateBootstrapObject();

        } catch ( Exception e ) {
            Qonsole.Error( e );
        }
    }

    static void QonsolePreConfig_kmd( string [] _ ) {
        // changing this will reset the console variables to defaults
        Cellophane.ConfigVersion_kvar = 10;
    }
    
    static void QonsoleTick_kmd( string [] _ ) {
        try {

        ShowDynamicDraws();

        if ( ShowQglMessage_kvar ) {
            int n = ( ( int )( Time.unscaledTime * 1000 ) >> 9 ) % 4;
            string dots = "";
            for ( int i = 0; i < n; i++ ) {
                dots += '.';
            }
            QGL.LatePrint( "This is a QGL mod message" + dots,
                                                    Screen.width / 2, Screen.height / 2, scale: 3,
                                                    color: Color.magenta );
        }

        } catch ( Exception e ) {
            Qonsole.Error( e );
        }
    }

    static void PrintBehaviours_kmd( string [] _ ) {
        MonoBehaviour [] behs = GameObject.FindObjectsOfType<MonoBehaviour>();
        foreach ( var b in behs ) {
            Qonsole.Log( $"{b.name} {b.GetType()}" );
        }
    }

    static void ShowDynamicDraws() {
        if ( ! ShowDynamicDraws_kvar ) {
            return;
        }

        DynamicDrawManager ddm = Find.CurrentMap?.dynamicDrawManager;
        if ( ddm == null ) {
            return;
        }

        FieldInfo drawThingsInfo = ddm.GetType().GetField( "drawThings",
                                            BindingFlags.NonPublic | BindingFlags.Instance );
        if ( drawThingsInfo == null ) {
            return;
        }

        var drawThings = drawThingsInfo.GetValue( ddm ) as List<Thing>;
        if ( drawThings == null ) {
            return;
        }

        var dta = drawThings.ToArray();
        foreach ( var dt in dta ) {
            Vector3 pos = dt.DrawPos;
            QGL.LatePrintWorld( dt.GetType().ToString(), pos, color: Color.magenta );
        }
    }
}


}

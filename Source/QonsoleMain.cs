using System;
using System.Reflection;
using UnityEngine;
using Verse;

namespace Qon {


[StaticConstructorOnStartup]
public static class QonsoleMain {

    // this is a Qonsole variable
    static bool ShowQglMessage_kvar = false;

    static QonsoleMain() {
        try {

        Qonsole.CreateBootstrapObject();

        } catch ( Exception e ) {
            Qonsole.Error( e );
        }
    }

    static void QonsolePreConfig_kmd( string [] _ ) {
        Cellophane.ConfigVersion_kvar = 10;
    }
    
    static void QonsoleTick_kmd( string [] _ ) {
        try {

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
}


}

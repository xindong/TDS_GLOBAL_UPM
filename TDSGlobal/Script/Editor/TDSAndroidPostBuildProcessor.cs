#if UNITY_EDITOR && UNITY_ANDROID
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_ANDROID
using UnityEditor.Android;
#endif
using UnityEngine;

using TDSEditor;

public class TDSAndroidPostBuildProcessor : IPostGenerateGradleAndroidProject
{
    public int callbackOrder
    {
        get
        {
            return 100;
        }
    }

    void IPostGenerateGradleAndroidProject.OnPostGenerateGradleAndroidProject(string path)
    {   
        Debug.Log("path:" + path);

        string projectPath = path.Substring(0,path.Length - 12);

        string googleServiceOriginPath = projectPath + "/unityLibrary/src/main/assets/google-services.json";

        string targetServicePath = projectPath + "/launcher/google-services.json";
    
        if(File.Exists(googleServiceOriginPath)){
            //copy google-service.json 到目录下
            File.Copy(googleServiceOriginPath,targetServicePath,true);
        }

        string launcherGradle = projectPath + "/launcher/build.gradle";

        string baseProjectGradle = projectPath + "/build.gradle";

        string unityLibraryGradle = projectPath + "/unityLibrary/build.gradle";

        if(File.Exists(launcherGradle)){
            Debug.Log("write launch gradle");
            TDSGlobalEditor.TDSGlobalScriptStreamWriterHelper writerHelper = new TDSGlobalEditor.TDSGlobalScriptStreamWriterHelper(launcherGradle);
            writerHelper.WriteBelow(@"implementation project(':unityLibrary')", @"
                implementation 'com.google.firebase:firebase-core:16.0.1'
                implementation 'com.google.firebase:firebase-analytics:15.0.1'
                implementation 'com.google.firebase:firebase-messaging:17.3.4'
            ");
            writerHelper.WriteBelow(@"apply plugin: 'com.android.application'",@"apply plugin: 'com.google.gms.google-services'");
        }

        if(File.Exists(baseProjectGradle)){
            Debug.Log("write project gradle");
            TDSGlobalEditor.TDSGlobalScriptStreamWriterHelper writerHelper = new TDSGlobalEditor.TDSGlobalScriptStreamWriterHelper(baseProjectGradle);
            writerHelper.WriteBelow(@"task clean(type: Delete) {
    delete rootProject.buildDir
}",@"allprojects {
    buildscript {
        dependencies {
            classpath 'com.google.gms:google-services:4.0.2'
        }
    }
}");
        }

        if(File.Exists(unityLibraryGradle)){
            Debug.Log("write unity gradle");
            TDSGlobalEditor.TDSGlobalScriptStreamWriterHelper writerHelper = new TDSGlobalEditor.TDSGlobalScriptStreamWriterHelper(unityLibraryGradle);
            writerHelper.WriteBelow(@"implementation fileTree(dir: 'libs', include: ['*.jar'])",@"
                implementation 'com.google.firebase:firebase-core:16.0.1'
                implementation 'com.google.firebase:firebase-analytics:15.0.1'
                implementation 'com.google.firebase:firebase-messaging:17.3.4'
    
                implementation 'com.google.code.gson:gson:2.8.5'

                implementation 'com.google.android.gms:play-services-auth:16.0.1'
                implementation 'com.facebook.android:facebook-login:5.15.3'
                implementation 'com.facebook.android:facebook-share:5.15.3'
                implementation 'com.appsflyer:af-android-sdk:4.11.0'
                implementation 'com.adjust.sdk:adjust-android:4.24.1'
                implementation 'com.android.installreferrer:installreferrer:2.1'
                implementation 'com.android.billingclient:billing:3.0.0'
    
                implementation 'com.android.support:support-annotations:28.0.0'
                implementation 'com.android.support:appcompat-v7:28.0.0'
                implementation 'com.android.support:recyclerview-v7:28.0.0'
            ");
        }

    }

}
#endif
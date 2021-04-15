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
            return 999;
        }
    }

    public static bool GeneratedAndroidGradle(string projectPath)
    {

        if (!Directory.Exists(projectPath + "/launcher"))
        {
            Debug.Log($"TDSG can't find {projectPath}/launcher");

            string targetGradlePath = projectPath + "/build.gradle";

            string googleServiceOriginPath = projectPath + "/src/main/assets/google-services.json";

            string targetServicePath = projectPath + "/google-services.json";

            if (File.Exists(googleServiceOriginPath))
            {
                //copy google-service.json 到目录下
                Debug.Log($"Copy GoogleService.json to Android Project:{targetServicePath}");
                File.Copy(googleServiceOriginPath, targetServicePath, true);
            }

            if (File.Exists(targetGradlePath))
            {
                TDSEditor.TDSScriptStreamWriterHelper writeHelper = new TDSEditor.TDSScriptStreamWriterHelper(targetGradlePath);
                writeHelper.WriteBelow(@"apply plugin: 'com.android.application'", @"apply plugin: 'com.google.gms.google-services'");
                writeHelper.WriteBelow(@"apply plugin: 'com.android.application'", @"buildscript {dependencies {classpath 'com.google.gms:google-services:4.0.2'}}");

                writeHelper.WriteBelow(@"implementation fileTree(dir: 'libs', include: ['*.jar'])", @"
                implementation 'com.google.firebase:firebase-core:16.0.1'
                implementation 'com.google.firebase:firebase-analytics:15.0.1'
                implementation 'com.google.firebase:firebase-messaging:17.3.4'
                implementation 'com.google.code.gson:gson:2.8.6'
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
                implementation 'com.google.android.gms:play-services-ads-identifier:15.0.1'
                implementation 'com.twitter.sdk.android:twitter:3.3.0'
                implementation 'com.twitter.sdk.android:tweet-composer:3.3.0'
                implementation 'com.linecorp:linesdk:5.0.1'
                ");
                return true;
            }
            else
            {
                Debug.LogError("TDSGlobal can't find Android Gradle File!");
                return false;
            }
        }
        return false;
    }

    void IPostGenerateGradleAndroidProject.OnPostGenerateGradleAndroidProject(string path)
    {
        string projectPath = null;

        if (path.Contains("unityLibrary"))
        {
            projectPath = path.Substring(0, path.Length - 12);
        }

        Debug.Log($"Project path:{path},substring path:{projectPath}");

        if (GeneratedAndroidGradle(projectPath))
        {
            return;
        }

        string googleServiceOriginPath = projectPath + "/unityLibrary/src/main/assets/google-services.json";

        string targetServicePath = projectPath + "/launcher/google-services.json";

        if (File.Exists(googleServiceOriginPath))
        {
            //copy google-service.json 到目录下
            File.Copy(googleServiceOriginPath, targetServicePath, true);
        }

        string launcherGradle = projectPath + "/launcher/build.gradle";

        string baseProjectGradle = projectPath + "/build.gradle";

        string unityLibraryGradle = projectPath + "/unityLibrary/build.gradle";

        if (File.Exists(launcherGradle))
        {

            Debug.Log("write launch gradle");

            TDSEditor.TDSScriptStreamWriterHelper writerHelper = new TDSEditor.TDSScriptStreamWriterHelper(launcherGradle);
            writerHelper.WriteBelow(@"implementation project(':unityLibrary')", @"
                implementation 'com.google.firebase:firebase-core:16.0.1'
                implementation 'com.google.firebase:firebase-analytics:15.0.1'
                implementation 'com.google.firebase:firebase-messaging:17.3.4'
            ");
            writerHelper.WriteBelow(@"apply plugin: 'com.android.application'", @"apply plugin: 'com.google.gms.google-services'");
        }

        if (File.Exists(baseProjectGradle))
        {
            Debug.Log("write project gradle");
            TDSEditor.TDSScriptStreamWriterHelper writerHelper = new TDSEditor.TDSScriptStreamWriterHelper(baseProjectGradle);
            writerHelper.WriteBelow(@"task clean(type: Delete) {
    delete rootProject.buildDir
}", @"allprojects {
    buildscript {
        dependencies {
            classpath 'com.google.gms:google-services:4.0.2'
        }
    }
}");
        }

        if (File.Exists(unityLibraryGradle))
        {
            TDSEditor.TDSScriptStreamWriterHelper writerHelper = new TDSEditor.TDSScriptStreamWriterHelper(unityLibraryGradle);
            writerHelper.WriteBelow(@"implementation fileTree(dir: 'libs', include: ['*.jar'])", @"
                implementation 'com.google.firebase:firebase-core:16.0.1'
                implementation 'com.google.firebase:firebase-analytics:15.0.1'
                implementation 'com.google.firebase:firebase-messaging:17.3.4'
    
                implementation 'com.google.code.gson:gson:2.8.6'

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
                implementation 'com.google.android.gms:play-services-ads-identifier:15.0.1'
                
                implementation 'com.twitter.sdk.android:twitter:3.3.0'
                implementation 'com.twitter.sdk.android:tweet-composer:3.3.0'
                implementation 'com.linecorp:linesdk:5.0.1'
            ");
        }

    }

}
#endif
using UnityEditor;
using UnityEngine;

namespace Intar.Editor {
    [CustomPropertyDrawer(typeof(AnimationCurveI17F15))]
    public class AnimationCurveI17F15Drawer : PropertyDrawer {
        // AnimationCurve の preWrapMode と postWrapMode は
        // 以下のような規則に従ってシリアライズ・デシリアライズされる.
        //
        // UnityEngine.WrapMode Convert(int a) => a switch {
        //     0 => UnityEngine.WrapMode.PingPong,
        //     1 => UnityEngine.WrapMode.Loop,
        //     _ => UnityEngine.WrapMode.ClampForever,
        //     3 => UnityEngine.WrapMode.Default,
        // };
        //
        // static int Convert(UnityEngine.WrapMode a) => a switch {
        //     UnityEngine.WrapMode.PingPong => 0,
        //     UnityEngine.WrapMode.Loop     => 1,
        //     _                             => 2,
        //     UnityEngine.WrapMode.Default  => 3,
        // };
        //
        // 以下の点に注意すること.
        //
        // * AnimationCurve のデフォルトコンストラクタは
        //   preWrapMode, postWrapMode に ClampForever を設定する.
        // * 列挙型 WrapMode の各メンバに関連する定数値と
        //   シリアライズ時に使用される定数値は異なる.
        // * Clamp と Once は同じ値を持つ.
        // * Clamp, ClampForever は共に 2 にシリアライズされ,
        //   デシリアライズ時には ClampForever に変換される.
        //
        // AnimationCurveI17F15, AnimationCurveI17F15Drawer は
        // UnityEngine.AnimationCurve を参考に以下のような規則で変換を行う.
        //
        // * 0 は UnityEngine.WrapMode.Loop にマップする.
        // * 0, WrapMode.Loop, WrapMode.PingPong 以外のすべての値は
        //   UnityEngine.WrapMode.ClampForever にマップする.
        // * UnityEngine.WrapMode.Default の動作はごく一部を除き Loop と同等であるため
        //   Intar.WrapMode.Loop にマップする.
        // * UnityEngine.WrapMode.Default, UnityEngine.WrapMode.Loop,
        //   UnityEngine.WrapMode.PingPoing 以外のすべての値は
        //   Intar.WrapMode.Clamp にマップする.

        static UnityEngine.WrapMode Convert(WrapMode wrapMode) {
            switch (wrapMode) {
                case 0:
#if false
                return UnityEngine.WrapMode.Default;
#endif
                case WrapMode.Loop: return UnityEngine.WrapMode.Loop;
                case WrapMode.PingPong: return UnityEngine.WrapMode.PingPong;
                case WrapMode.Clamp:
                default: return UnityEngine.WrapMode.ClampForever;
            }
        }
        static WrapMode Convert(UnityEngine.WrapMode wrapMode) {
            switch (wrapMode) {
                case UnityEngine.WrapMode.Default:
#if false
                return 0;
#endif
                case UnityEngine.WrapMode.Loop: return WrapMode.Loop;
                case UnityEngine.WrapMode.PingPong: return WrapMode.PingPong;
                case UnityEngine.WrapMode.ClampForever:
                case UnityEngine.WrapMode.Clamp:
                default: return WrapMode.Clamp;
            }
        }
        static int Convert(float tangent) {
            if (float.IsNaN(tangent)) {
                return -1;
            } else if (float.IsPositiveInfinity(tangent)) {
                return int.MaxValue;
            } else if (float.IsNegativeInfinity(tangent)) {
                return int.MinValue;
            } else {
                return I17F15Drawer.ToBits(tangent);
            }
        }
        AnimationCurve proxy;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var keys = property.FindPropertyRelative("keys");

            // 一度すべてのキーをクリアして再構築する。
            // AnimationCurve は内部的にネイティブメモリを参照しているため
            // それによって再アロケーションが走る可能性は低いことを期待する。
            if (proxy == null) {
                proxy = new AnimationCurve();
                if (keys.arraySize > 0) {
                    for (var i = 0; i < keys.arraySize; i++) {
                        var e = keys.GetArrayElementAtIndex(i);
                        var tangentMode = e.FindPropertyRelative("tangentMode").intValue;
                        float inTangent, outTangent;
                        if (TangentMode.Constant == (TangentMode)(0b1111 & (tangentMode >> 1))) {
                            inTangent = float.PositiveInfinity;
                        } else {
                            inTangent = I17F15Drawer.FromBits(e.FindPropertyRelative("InTangent.Bits").intValue);
                        }
                        if (TangentMode.Constant == (TangentMode)(0b1111 & (tangentMode >> 5))) {
                            outTangent = float.PositiveInfinity;
                        } else {
                            outTangent = I17F15Drawer.FromBits(e.FindPropertyRelative("OutTangent.Bits").intValue);
                        }
#pragma warning disable CS0618 // 型またはメンバーが旧型式です
                        var key = new Keyframe(
                            I17F15Drawer.FromBits(e.FindPropertyRelative("Time.Bits").intValue),
                            I17F15Drawer.FromBits(e.FindPropertyRelative("Value.Bits").intValue),
                            inTangent, outTangent,
                            I17F15Drawer.FromBits(e.FindPropertyRelative("InWeight.Bits").intValue),
                            I17F15Drawer.FromBits(e.FindPropertyRelative("OutWeight.Bits").intValue)
                        ) {
                            tangentMode = tangentMode,
                            weightedMode = (UnityEngine.WeightedMode)e.FindPropertyRelative("WeightedMode").intValue,
                        };
#pragma warning restore CS0618 // 型またはメンバーが旧型式です
                        _ = proxy.AddKey(key);
                    }
                }
                proxy.preWrapMode = Convert((WrapMode)property.FindPropertyRelative("PreWrapMode").intValue);
                proxy.postWrapMode = Convert((WrapMode)property.FindPropertyRelative("PostWrapMode").intValue);
            }

            // GUI を描画し変更を検知する
            {
                EditorGUI.BeginChangeCheck();
                proxy = EditorGUI.CurveField(position, label, proxy);
            }

            // 変更があった場合はプロパティに書き戻す
            if (EditorGUI.EndChangeCheck()) {
                keys.ClearArray();
                keys.arraySize = proxy.length;

                for (var i = 0; i < proxy.length; i++) {
                    var key = keys.GetArrayElementAtIndex(i);
                    var k = proxy.keys[i];
                    key.FindPropertyRelative("Time.Bits").intValue = I17F15Drawer.ToBits(k.time);
                    key.FindPropertyRelative("Value.Bits").intValue = I17F15Drawer.ToBits(k.value);
                    key.FindPropertyRelative("InTangent.Bits").intValue = Convert(k.inTangent);
                    key.FindPropertyRelative("OutTangent.Bits").intValue = Convert(k.outTangent);
                    key.FindPropertyRelative("InWeight.Bits").intValue = I17F15Drawer.ToBits(k.inWeight);
                    key.FindPropertyRelative("OutWeight.Bits").intValue = I17F15Drawer.ToBits(k.outWeight);
                    key.FindPropertyRelative("WeightedMode").intValue = (int)k.weightedMode;
#pragma warning disable CS0618 // 型またはメンバーが旧型式です
                    key.FindPropertyRelative("tangentMode").intValue = k.tangentMode;
#pragma warning restore CS0618 // 型またはメンバーが旧型式です
                }

                // Update wrap modes
                property.FindPropertyRelative("PreWrapMode").intValue = (int)Convert(proxy.preWrapMode);
                property.FindPropertyRelative("PostWrapMode").intValue = (int)Convert(proxy.postWrapMode);

                _ = property.serializedObject.ApplyModifiedProperties();
            }
        }
        public override float GetPropertyHeight(
            SerializedProperty property, GUIContent label
        ) => EditorGUI.GetPropertyHeight(SerializedPropertyType.Generic, label);
    }
}

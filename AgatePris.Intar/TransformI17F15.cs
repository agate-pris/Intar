using AgatePris.Intar.Numerics;
using System;
using System.Runtime.CompilerServices;

#if UNITY_5_6_OR_NEWER

using UnityEditor;
using UnityEngine;

#endif

namespace AgatePris.Intar {

    partial struct Matrix3x3I17F15 {
        /// Prerequisite: q is normalized (to prevent overflow)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix3x3I17F15(QuaternionI17F15 q) {
            var v = q.XYZW;
            var vXNeg = -v.X;
            var vYNeg = -v.Y;
            var vZNeg = -v.Z;
            var vWNeg = -v.W;
            var v2 = v.Twice();
            C0 = (v2.Y * new Vector3I17F15(vYNeg, v.X, vWNeg)) - (v2.Z * new Vector3I17F15(v.Z, vWNeg, vXNeg)) + Vector3I17F15.UnitX;
            C1 = (v2.Z * new Vector3I17F15(vWNeg, vZNeg, v.Y)) - (v2.X * new Vector3I17F15(vYNeg, v.X, vWNeg)) + Vector3I17F15.UnitY;
            C2 = (v2.X * new Vector3I17F15(v.Z, vWNeg, vXNeg)) - (v2.Y * new Vector3I17F15(vWNeg, vZNeg, v.Y)) + Vector3I17F15.UnitZ;
        }
    }

    partial struct Matrix4x4I17F15 {
        /// Prerequisite: q is normalized (to prevent overflow)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4I17F15 TRS(Vector3I17F15 translation, QuaternionI17F15 rotation, Vector3I17F15 scale) {
            var r = new Matrix3x3I17F15(rotation);
            return new Matrix4x4I17F15(
                new Vector4I17F15(r.C0.SaturatingMul(scale.X), I17F15.Zero),
                new Vector4I17F15(r.C1.SaturatingMul(scale.Y), I17F15.Zero),
                new Vector4I17F15(r.C2.SaturatingMul(scale.Z), I17F15.Zero),
                new Vector4I17F15(translation, I17F15.One));
        }
    }

    [Serializable]

#if UNITY_5_6_OR_NEWER
    [ExecuteAlways, RequireComponent(typeof(Transform))]
#endif
    public class TransformI17F15
#if UNITY_5_6_OR_NEWER
        : MonoBehaviour
#endif
    {
        // Fields
        // ---------------------------------------

#if UNITY_5_6_OR_NEWER
        [SerializeField]
#endif
        TransformI17F15 parent;

#if UNITY_5_6_OR_NEWER
        [SerializeField]
#endif
        Vector3I17F15 localPosition;
#if UNITY_5_6_OR_NEWER
        [SerializeField]
#endif
        Vector3I17F15 localScale;
#if UNITY_5_6_OR_NEWER
        [SerializeField]
#endif
        Vector3I17F15 localEulerAnglesHint;

        QuaternionI17F15? localRotation;
        Matrix4x4I17F15? localToWorldMatrix;
        Vector3I17F15? position;

        // Properties
        // ---------------------------------------

        public TransformI17F15 Parent {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => parent;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (parent == value) {
                    return;
                }
                parent = value;
                localToWorldMatrix = null;
                position = null;
            }
        }

        public Vector3I17F15 LocalPosition {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => localPosition;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (localPosition == value) {
                    return;
                }
                localPosition = value;
                localToWorldMatrix = null;
                position = null;
            }
        }
        public Vector3I17F15 LocalScale {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => localScale;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (localScale == value) {
                    return;
                }
                localScale = value;
                localToWorldMatrix = null;
            }
        }
        public QuaternionI17F15 LocalRotation {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private get {
                // ユーザは値を明示的にセットすることができる｡
                // よって､ ユーザーは `LocalRotation` が参照される前に明示的に値をセットすることで､
                // オイラー角から四元数に変換する際のアルゴリズムを選択することができる｡
                // (それによって､ 変換時の計算の速度や精度の選択権を得る｡ )
                // もし明示的に四元数で値がセットされていなかった場合､
                // QuaternionI17F15.EulerZxyP5A51437 で値を計算しキャッシュする｡
                if (!localRotation.HasValue) {
                    localRotation = QuaternionI17F15.EulerZxyP5A51437(localEulerAnglesHint);
                }
                return localRotation.Value;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (localRotation.HasValue) {
                    if (localRotation.Value == value) {
                        return;
                    }
                }
                localRotation = value;
            }
        }

        public Matrix4x4I17F15 LocalToWorldMatrix {
            get {
                if (!localToWorldMatrix.HasValue) {
                    var m = Matrix4x4I17F15.TRS(localPosition, LocalRotation, localScale);
                    localToWorldMatrix
                        = parent != null
                        ? parent.LocalToWorldMatrix.SaturatingProduct(m)
                        : m;
                }
                return localToWorldMatrix.Value;
            }
        }

        public Vector3I17F15 Position {
            get {
                if (!position.HasValue) {
                    if (parent != null) {
                        throw new NotImplementedException();
                    } else {
                        position = localPosition;
                    }
                }
                return position.Value;
            }
        }

        // Constructors
        // ---------------------------------------

        public TransformI17F15() {
            localScale = Vector3I17F15.One;
        }

        // Methods
        // ---------------------------------------

#if UNITY_EDITOR

        void Update() {
            if (Application.isPlaying || !transform) {
                return;
            }
            {
                const float max = 65535;
                const float min = -65536;
                {
                    var x = Mathf.Clamp(transform.localPosition.x, min, max);
                    var y = Mathf.Clamp(transform.localPosition.y, min, max);
                    var z = Mathf.Clamp(transform.localPosition.z, min, max);
                    transform.localPosition = new Vector3(x, y, z);
                    localPosition = new Vector3I17F15(
                        I17F15.FromBits((int)(x * I17F15.One.Bits)),
                        I17F15.FromBits((int)(y * I17F15.One.Bits)),
                        I17F15.FromBits((int)(z * I17F15.One.Bits)));
                }
                {
                    var x = Mathf.Clamp(transform.localScale.x, min, max);
                    var y = Mathf.Clamp(transform.localScale.y, min, max);
                    var z = Mathf.Clamp(transform.localScale.z, min, max);
                    transform.localScale = new Vector3(x, y, z);
                    localScale = new Vector3I17F15(
                        I17F15.FromBits((int)(x * I17F15.One.Bits)),
                        I17F15.FromBits((int)(y * I17F15.One.Bits)),
                        I17F15.FromBits((int)(z * I17F15.One.Bits)));
                }
            }
            {
                const int right = 90;
                const float min = -5898240;
                const float max = 5898239;
                var serializedObject = new SerializedObject(transform);
                var serializedProperty = serializedObject.FindProperty("m_LocalEulerAnglesHint");
                var x = Mathf.Clamp(serializedProperty.vector3Value.x, min, max);
                var y = Mathf.Clamp(serializedProperty.vector3Value.y, min, max);
                var z = Mathf.Clamp(serializedProperty.vector3Value.z, min, max);
                var v = new Vector3(x, y, z);
                serializedProperty.vector3Value = v;
                _ = serializedObject.ApplyModifiedProperties();
                transform.localEulerAngles = v;
                localEulerAnglesHint = new Vector3I17F15(
                    I17F15.FromBits((int)(x * I17F15.One.Bits / right)),
                    I17F15.FromBits((int)(y * I17F15.One.Bits / right)),
                    I17F15.FromBits((int)(z * I17F15.One.Bits / right)));
            }
        }

#endif

#if UNITY_5_6_OR_NEWER

        void LateUpdate() {
            transform.localPosition = new Vector3(
                (float)localPosition.X,
                (float)localPosition.Y,
                (float)localPosition.Z);
            transform.localScale = new Vector3(
                (float)localScale.X,
                (float)localScale.Y,
                (float)localScale.Z);

            // TODO: Add rotation represented by Quaternion
        }

        void OnTransformParentChanged() {
            localToWorldMatrix = null;
            position = null;
        }

#endif

    }
}

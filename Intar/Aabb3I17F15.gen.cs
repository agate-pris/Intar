using System;
using System.Runtime.CompilerServices;

#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif // UNITY_5_3_OR_NEWER

namespace Intar {
    [Serializable]
    public struct Aabb3I17F15 {
        #region min, max
#if UNITY_5_3_OR_NEWER
        [SerializeField]
#endif // UNITY_5_3_OR_NEWER
        Vector3I17F15 min;
#if UNITY_5_3_OR_NEWER
        [SerializeField]
#endif // UNITY_5_3_OR_NEWER
        Vector3I17F15 max;
        #endregion
        #region Min, Max, Size
        public Vector3I17F15 Min {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => min;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                min = value;
                max = max.Max(value);
            }
        }
        public Vector3I17F15 Max {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                max = value;
                min = min.Min(value);
            }
        }
        public Vector3I17F15 Size {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max - min;
        }
        #endregion
        #region MinX, MaxX, SizeX
        public I17F15 MinX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => min.X;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                min.X = value;
                max.X = max.X.Max(value);
            }
        }
        public I17F15 MaxX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max.X;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                max.X = value;
                min.X = min.X.Min(value);
            }
        }
        public I17F15 SizeX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max.X - min.X;
        }
        #endregion
        #region MinY, MaxY, SizeY
        public I17F15 MinY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => min.Y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                min.Y = value;
                max.Y = max.Y.Max(value);
            }
        }
        public I17F15 MaxY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max.Y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                max.Y = value;
                min.Y = min.Y.Min(value);
            }
        }
        public I17F15 SizeY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max.Y - min.Y;
        }
        #endregion
        #region MinZ, MaxZ, SizeZ
        public I17F15 MinZ {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => min.Z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                min.Z = value;
                max.Z = max.Z.Max(value);
            }
        }
        public I17F15 MaxZ {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max.Z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                max.Z = value;
                min.Z = min.Z.Min(value);
            }
        }
        public I17F15 SizeZ {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => max.Z - min.Z;
        }
        #endregion
        #region Construction
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aabb3I17F15(Vector3I17F15 p) {
            min = p;
            max = p;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aabb3I17F15(Geometry.SphereI17F15 circle) {
            min = circle.Center - (I17F15)circle.Radius;
            max = circle.Center + (I17F15)circle.Radius;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aabb3I17F15(Geometry.Segment3I17F15 segment) {
            I17F15 minX, maxX;
            if (segment.P1.X < segment.P2.X) {
                minX = segment.P1.X;
                maxX = segment.P2.X;
            } else {
                minX = segment.P2.X;
                maxX = segment.P1.X;
            }
            I17F15 minY, maxY;
            if (segment.P1.Y < segment.P2.Y) {
                minY = segment.P1.Y;
                maxY = segment.P2.Y;
            } else {
                minY = segment.P2.Y;
                maxY = segment.P1.Y;
            }
            I17F15 minZ, maxZ;
            if (segment.P1.Z < segment.P2.Z) {
                minZ = segment.P1.Z;
                maxZ = segment.P2.Z;
            } else {
                minZ = segment.P2.Z;
                maxZ = segment.P1.Z;
            }
            min = new Vector3I17F15(minX, minY, minZ);
            max = new Vector3I17F15(maxX, maxY, maxZ);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Aabb3I17F15? CheckedFromMinMax(Vector3I17F15 min, Vector3I17F15 max) {
            if (max.X < min.X || max.Y < min.Y || max.Z < min.Z) {
                return null;
            }
            return new Aabb3I17F15 {
                min = min,
                max = max,
            };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Aabb3I17F15 UncheckedFromMinMax(Vector3I17F15 min, Vector3I17F15 max) {
            return new Aabb3I17F15 {
                min = min,
                max = max,
            };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Aabb3I17F15 StrictFromMinMax(Vector3I17F15 min, Vector3I17F15 max) {
            var nullable = CheckedFromMinMax(min, max);
            if (nullable.HasValue) {
                return nullable.Value;
            }
            throw new ArgumentException("Invalid Aabb3I17F15: max must be greater than or equal to min.");
        }
        #endregion
        #region EncapsulateX
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EncapsulateX(I17F15 v) {
            if (v < min.X) {
                min.X = v;
            } else if (v > max.X) {
                max.X = v;
            }
        }
        #endregion
        #region EncapsulateY
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EncapsulateY(I17F15 v) {
            if (v < min.Y) {
                min.Y = v;
            } else if (v > max.Y) {
                max.Y = v;
            }
        }
        #endregion
        #region EncapsulateZ
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EncapsulateZ(I17F15 v) {
            if (v < min.Z) {
                min.Z = v;
            } else if (v > max.Z) {
                max.Z = v;
            }
        }
        #endregion
        #region Encapsulate
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encapsulate(Aabb3I17F15 other) {
            min = min.Min(other.min);
            max = max.Max(other.max);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encapsulate(Vector3I17F15 p) {
            if (p.X < min.X) {
                min.X = p.X;
            } else if (p.X > max.X) {
                max.X = p.X;
            }
            if (p.Y < min.Y) {
                min.Y = p.Y;
            } else if (p.Y > max.Y) {
                max.Y = p.Y;
            }
            if (p.Z < min.Z) {
                min.Z = p.Z;
            } else if (p.Z > max.Z) {
                max.Z = p.Z;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encapsulate(Geometry.SphereI17F15 a) {
            Encapsulate(new Aabb3I17F15(a));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encapsulate(Geometry.Segment3I17F15 a) {
            Encapsulate(new Aabb3I17F15(a));
        }
        #endregion
        #region Intersects
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(Vector3I17F15 p) {
            if (p.X < min.X || max.X < p.X) { return false; }
            if (p.Y < min.Y || max.Y < p.Y) { return false; }
            if (p.Z < min.Z || max.Z < p.Z) { return false; }
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(Aabb3I17F15 other) {
            if (max.X < other.min.X || other.max.X < min.X) { return false; }
            if (max.Y < other.min.Y || other.max.Y < min.Y) { return false; }
            if (max.Z < other.min.Z || other.max.Z < min.Z) { return false; }
            return true;
        }
        #endregion
        #region Overlaps
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(Vector3I17F15 p) {
            if (p.X <= min.X || max.X <= p.X) { return false; }
            if (p.Y <= min.Y || max.Y <= p.Y) { return false; }
            if (p.Z <= min.Z || max.Z <= p.Z) { return false; }
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(Aabb3I17F15 other) {
            if (max.X <= other.min.X || other.max.X <= min.X) { return false; }
            if (max.Y <= other.min.Y || other.max.Y <= min.Y) { return false; }
            if (max.Z <= other.min.Z || other.max.Z <= min.Z) { return false; }
            return true;
        }
        #endregion
    }
} // namespace Intar

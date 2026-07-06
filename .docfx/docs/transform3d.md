# 3 次元の座標変換とコライダー

Intar における 3 次元の座標変換と 3 次元コライダーの使い方を説明します｡

## 座標変換

`AffineTransform3I17F15` は平行移動･回転･拡大縮小を表すアフィン変換です｡ `Trs` メソッドで生成できます｡

回転を表す `QuaternionI2F30` の生成メソッドに渡す角度は直角を 1 とする単位で指定します｡ たとえば `I17F15.One` は 90 度を表します｡

```cs
using Intar;

// 平行移動
var t = new Vector3I17F15(
    I17F15.One,
    I17F15.Zero,
    I17F15.Zero);

// Y 軸まわりに 90 度回転
var r = QuaternionI2F30.RotateYP5(I17F15.One);

// 拡大縮小
var s = Vector3I17F15.One;

var matrix = AffineTransform3I17F15.Trs(t, r, s);

// 点の変換
var position = Vector3I17F15.UnitZ;
position = matrix * position;
```

## 変換の合成

変換同士の乗算で変換を合成できます｡ 親子関係にあるオブジェクトのワールド変換は､ 親の変換とローカル変換の積として求められます｡

```cs
var parent = AffineTransform3I17F15.Trs(
    Vector3I17F15.UnitY,
    QuaternionI2F30.RotateZP5(I17F15.One),
    Vector3I17F15.One);

var local = AffineTransform3I17F15.Trs(
    Vector3I17F15.UnitX,
    QuaternionI2F30.Identity,
    Vector3I17F15.One);

var world = parent * local;
var position = world * Vector3I17F15.Zero;
```

## スケールの分解

変換に含まれる拡大縮小の成分は `DecomposeScaleX` ･ `DecomposeScaleY` ･ `DecomposeScaleZ` で取り出せます｡

```cs
var sx = matrix.DecomposeScaleX();
var sy = matrix.DecomposeScaleY();
var sz = matrix.DecomposeScaleZ();
```

## 3 次元コライダー

3 次元のコライダーとして以下の型を提供します｡

- `Intar.Geometry.SphereI17F15` ─ 球
- `Intar.Geometry.Segment3I17F15` ─ 線分
- `Intar.Aabb3I17F15` ─ 軸並行境界ボックス

`Intersects` は境界を含む交差判定､ `Overlaps` は境界を含まない交差判定を行います｡

```cs
using Intar;
using Intar.Geometry;

var sphere = new SphereI17F15(Vector3I17F15.Zero, U17F15.One);
var other = new SphereI17F15(Vector3I17F15.UnitX, U17F15.One);

// 球同士の交差判定
if (sphere.Intersects(other)) {
    // ...
}

// 点との交差判定
if (sphere.Intersects(Vector3I17F15.UnitY)) {
    // ...
}

// 線分との交差判定
var segment = new Segment3I17F15(
    new Vector3I17F15(I17F15.NegativeOne, I17F15.Zero, I17F15.Zero),
    new Vector3I17F15(I17F15.One, I17F15.Zero, I17F15.Zero));
if (segment.Intersects(sphere)) {
    // ...
}

// 線分上で最も点に近い点
var closest = segment.ClosestPoint(Vector3I17F15.One);
```

## コライダーの変換

コライダーにアフィン変換を適用できます｡ 球に対して各軸で異なる拡大縮小を含む変換を適用した場合､ 半径には最も大きい拡大率が使用されます｡

```cs
var transformed = matrix * sphere;
```

## バウンディングボックス

`Envelope` でコライダーを包む軸並行境界ボックスを取得できます｡ 交差判定の事前判定に使用できます｡

```cs
var aabb = sphere.Envelope();
if (aabb.Intersects(segment.Envelope())) {
    // 必要な場合のみ詳細な判定を行う
}
```

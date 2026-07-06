# SIMD への対応方針

Intar は SIMD 命令を明示的には使用しません｡ これは以下の理由によります｡

- ポータブルに対応するのが難しい｡ 実行環境ごとに利用可能な命令セットが異なるため､ すべての対象環境で同様に対応することが困難です｡
- 64 ビット整数の取り扱いが難しい｡ Intar は乗除算の途中計算で 64 ビット以上の整数を多用しますが､ SIMD 命令セットにおける 64 ビット整数演算のサポートは限定的です｡
- Unity の [Burst](https://docs.unity3d.com/Packages/com.unity.burst@latest) と .NET の [System.Runtime.Intrinsics](https://learn.microsoft.com/dotnet/api/system.runtime.intrinsics) のどちらにも対応することが難しい｡ 最適化の仕組みが分かれているため､ 両立が困難です｡
- オーバーフロー対策ができない｡ SIMD 演算はすべて unchecked で行われるため､ オーバーフローの検出と対策を行えません｡

## Unity における最適化

Unity では最適化を Burst に任せ､ Intar 自身は `AggressiveInlining` の指定のみを行います｡

## 非 Unity 環境における SIMD 対応

非 Unity 環境向けの SIMD 対応は未定です (当面行いません) ｡

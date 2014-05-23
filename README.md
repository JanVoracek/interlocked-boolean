interlocked-boolean
===================

Boolean type usable for Interlocked.Exchange.
It supports all logical operations and it's comparable with standard bool type. Also can be used in conditional statements.

The goal is to behave completely like bool.

Usage
=====

```csharp
InterlockedBoolean locked = false;

if(Interlocked.Exchange(ref locked, true) == false) {
  // some exclusive operation
  locked = false;
}
```

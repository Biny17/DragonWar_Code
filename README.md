## 💡 Coding with C# and Unity

### List<things> ILearnedInC#

Delegates, coroutines, LINQ, Polymorphism, static class/methods, foreach loop, List, Queue, Stack, Dictionary, Interfaces

### List<things> ILearnedInUnity

Monobehaviors and its methods, Events,Scriptable Objects, new Input System, Colliders, Character Controller, Canva, 
Button, Images, Textures, Animator, Slider, Meshes, Camera, Pooling


## 🌇 Design patterns

While coding the game i learned about design patterns and implemented them gradually.
I would re-do a some parts differently but hey let's not touch what is not broken 😎

### Design patterns i used: visitors, composition over inheritance, observers, singleton.

## 💔 Healbars

### Procedurally generated

Every section delimited by thin vertical black lines represent 50hp.
The health bar design intuitively indicates the enemy's total health points to the player.
Additionally there is a color gradient from green = 100 to red = 0.  
100 Health points Bar:  
![100 Healthpoints Bar](Img/100%20HB.PNG)  
250 Health points Bar:  
<img src="Img/250HB.PNG" height="60"><br> 
Gradient from green to red:  
![Gradient](Img/LowHB.PNG)

## 🏊 Pooling

Pooling is a good way to improve performance, right now it's only used for the damage text popup.
I will extend it to ennemies and projectiles next.
I like my implementation where the pool is static and belongs to the class.
In [Entites/Code/VisualDamageHeal.cs](/Entites/Code/VisualDamageHeal.cs)
```csharp
private static ObjectPool<PopText> pool;

// Static constructor
static VisualDamageHeal()
{
    pool = new ObjectPool<PopText>(
        createFunc: CreateText,
        actionOnGet:  null,
        actionOnRelease: null,
        defaultCapacity: 150
    );
}
```
Every instance of the class will take an element from the same pool.  
Every pool element have a reference to the pool to get back to it when finished.
``` csharp
private void BackToPool()
{
    gameObject.SetActive(false);
    _pool.Release(this);
}
```

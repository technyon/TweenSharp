### What is Tween# ?
Tween# (TweenSharp) is a tweening library for C# / Unity with an interface inspired by Greensocks TweenMax.

### Why to write another tweeling library?
I've used ActionScript / Flash for several years, and I'm moving to Unity / C# now. TweenMax is very ease to use and nice to work with, while still being very powerfull if needed. I've found the existing tweening libraries for C# tedious to work with ... they often require several lines of code where Tween# only needs one line. Which bring us to the next section:

### Example
You want move an object along x- and y-coordinates while fading alpha to 0 using a Quad ease? Ease over 5 seconds? Ease, just do this:

	TweenSharp tween = new TweenSharp(gameObject, 5f, new
	{
		x  = 8f,
		y = -5f,
		alpha = 0f,
		ease = Quad.EaseOut
	} );

	or
	
	TweenSharp tween = new TweenSharp(gameObject, 5f, new Dictionary<string, object>()
	{
		{"x", 8f},
		{"y", -5f},
		{"alpha", 0f},
		{"ease", Quad.EaseOut}
	} );

Tween# of course supports many more features:

### Features
- Tween any float property on any object
- All important ease functions are included (from simple one like Linear and Quad to more complex ones like Bounce and Elastic)
- Plugin support for properties. x,y and alpha in the example mentioned above are handled by plugins.
- Autodetection of object type. If necessary, those plugins use the RectTransform of the object instead of the Transform.
- onComplete and onUpdate with and without parameters are supported
- You can easily control the tween with propertied and methods like "paused", "reverted", "Progress" and "Restart".
- Use "DelayedCall" for delayed execution of methods.

### How to Use
Just download with git or as a ZIP and included all files in your project. Add TSScheduler.cs to any GameObject in the scene and you're all setup.
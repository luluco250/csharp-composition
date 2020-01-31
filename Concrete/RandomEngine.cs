using System;
using Traits.Interface;

namespace Traits.Concrete {

sealed class RandomEngine : IRandomEngine {
	[ThreadStatic]
	private static RandomEngine _Instance = null;
	public static RandomEngine Instance
		=> _Instance = _Instance ?? new RandomEngine();

	private RandomEngine() {}

	[ThreadStatic]
	static Random random = new Random();

	public int Between(int a, int b)
		=> random.Next(a, b + 1);

	// Let's say we didn't implement it, eh?
	/*public int BetweenExclusive(int a, int b)
		=> random.Next(a, b);*/

	public double Between(double a, double b)
		=> random.NextDouble() % (b - a) + a;
}

}
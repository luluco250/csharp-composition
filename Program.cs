using static System.Console;

using Traits.Interface;
using Traits.Concrete;

namespace Traits {

static class Program {
	static void Main(string[] args) {
		WriteLine("Testing constraints...");
		TestConstraints();

		WriteLine("Testing polymorphism...");
		TestPolymorphism();
	}

	static void TestConstraints() {
		var cow = new Cow();
		EmitSound(cow);
		EvaluateProducer(cow);
		ProduceAtMost(cow, 3);

		var soda = new SodaCan("Colada");
		EmitSound(soda);
		ProduceAtMost(soda, 3);
		ProduceWithProgress(soda);
		ProduceWithProgress(soda);
	}

	static void TestPolymorphism() {
		var producers = new dynamic[] {new Cow("Judy"), new SodaCan()};

		foreach (var p in producers)
			Produce(p);
	}

	static void EvaluateProducer<T>(T producer) where T : INamed, IProducer {
		WriteLine($"{producer.Name} is producing:");

		foreach (var prod in producer.Produce())
			WriteLine($"  {prod.Name}");
	}

	static void EmitSound<T>(T origin) where T : ISoundMaker {
		WriteLine(origin.Sound);
	}

	static void ProduceWithProgress<T>(T producer)
	where T : INamed, IProducer, IQuantifiable {
		if (producer.IsEmpty)
		{
			WriteLine($"{producer.Name} is empty, can't produce!");
			return;
		}

		WriteLine($"{producer.Name} is producing:");

		foreach (var prod in producer.Produce())
			WriteLine($"  {prod.Name} ({producer.PercentLeft * 100f:0}%)");
	}

	static void ProduceAtMost<T>(T producer, int maximum)
	where T : INamed, IProducer {
		WriteLine($"{producer.Name} will produce at most {maximum} products:");
		
		foreach (var prod in producer.Produce(maximum))
			WriteLine($"  {prod.Name}");
	}

	static void Produce<T>(T producer) where T : INamed, IProducer {
		if (producer is ISoundMaker sm)
			WriteLine($"{producer.Name}: \"{sm.Sound}\"");

		if (producer is IQuantifiable qt)
			foreach (var prod in producer.Produce())
				WriteLine($"  {prod.Name} ({qt.PercentLeft * 100f:0}%)");
		else
			foreach (var prod in producer.Produce())
				WriteLine($"  {prod.Name}");
	}
}

}
using System;

static class Program {
	static void Main(string[] args) {
		var cow = new Cow();
		EmitSound(cow);
		EvaluateProducer(cow);
		ProduceAtMost(cow, 3);

		var soda = new SodaCan();
		soda.Name = "Colada";
		EmitSound(soda);
		ProduceAtMost(soda, 3);
		ProduceWithProgress(soda);
		ProduceWithProgress(soda);
	}

	static void EvaluateProducer<T>(T producer) where T : INamed, IProduces {
		Console.WriteLine($"{producer.Name} is producing:");

		foreach (var prod in producer.Produce())
			Console.WriteLine($"  {prod.Name}");
	}

	static void EmitSound<T>(T origin) where T : ISoundMaker {
		Console.WriteLine(origin.Sound);
	}

	static void ProduceWithProgress<T>(T producer)
	where T : INamed, IProduces, IQuantifiable {
		if (producer.IsEmpty)
		{
			Console.WriteLine($"{producer.Name} is empty, can't produce!");
			return;
		}

		Console.WriteLine($"{producer.Name} is producing:");

		foreach (var prod in producer.Produce())
			Console.WriteLine(
				$"  {prod.Name} ({producer.PercentLeft * 100f:0}%)");
	}

	static void ProduceAtMost<T>(T producer, int maximum)
	where T : INamed, IProduces {
		Console.WriteLine(
			$"{producer.Name} will produce at most {maximum} products:");
		
		foreach (var prod in producer.Produce(maximum))
			Console.WriteLine($"  {prod.Name}");
	}
}
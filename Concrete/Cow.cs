using System.Collections.Generic;

sealed class Cow : INamed, ISoundMaker, IProduces {
	public string Name { get; set; } = "Betsy";

	public string Sound => "Moo!";

	public IEnumerable<IProduct> Produce() {
		IRandomEngine rand = RandomEngine.Instance;
		int amount = rand.Between(1, 4);

		for (int i = 0; i < amount; ++i)
			yield return new Milk();
	}
}
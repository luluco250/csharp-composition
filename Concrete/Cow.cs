using System.Collections.Generic;
using Traits.Interface;

namespace Traits.Concrete {

sealed class Cow : INamed, ISoundMaker, IProducer {
	public string Name { get; set; } = "Betsy";

	public string Sound => "Moo!";

	public Cow() {}

	public Cow(string name)
		=> Name = name;

	public IEnumerable<IProduct> Produce() {
		IRandomEngine rand = RandomEngine.Instance;
		int amount = rand.Between(1, 4);

		for (int i = 0; i < amount; ++i)
			yield return new Milk();
	}
}

}
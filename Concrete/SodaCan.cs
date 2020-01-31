using System.Collections.Generic;
using Traits.Interface;

namespace Traits.Concrete {

sealed class SodaCan : INamed, IProducer, ISoundMaker, IQuantifiable {
	public string Name { get; set; } = "Bepis";

	public string Sound => "Fthsssss!";

	const int _MaxQuantity = 10;
	public int MaxQuantity => _MaxQuantity;

	public int Quantity { get; private set; } = _MaxQuantity;

	public SodaCan() {}

	public SodaCan(string name)
		=> Name = name;

	public IEnumerable<IProduct> Produce() {
		int initialQuantity = Quantity;

		for (int i = 0; i < initialQuantity; ++i)
		{
			yield return new SodaGulp();
			--Quantity;
		}
	}
}

}
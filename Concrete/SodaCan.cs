using System.Collections.Generic;

class SodaCan : INamed, IProduces, ISoundMaker, IQuantifiable {
	public string Name { get; set; } = "Bepis";

	public string Sound => "Fthsssss!";

	const int _MaxQuantity = 10;
	public int MaxQuantity => _MaxQuantity;

	public int Quantity { get; private set; } = _MaxQuantity;

	public IEnumerable<IProduct> Produce() {
		int initialQuantity = Quantity;

		for (int i = 0; i < initialQuantity; ++i)
		{
			yield return new SodaGulp();
			--Quantity;
		}
	}
}
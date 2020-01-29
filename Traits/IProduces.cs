using System.Collections.Generic;

interface IProduces {
	IEnumerable<IProduct> Produce();

	IEnumerable<IProduct> Produce(int maximum) {
		int i = 0;

		foreach (var prod in Produce())
		{
			++i;

			if (i > maximum)
				yield break;
			
			yield return prod;
		}
	}
}
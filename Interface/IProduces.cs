using System.Collections.Generic;

namespace Traits.Interface {

interface IProducer {
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

}
namespace Traits.Interface {

interface IRandomEngine {
	int Between(int a, int b);

	int BetweenExclusive(int a, int b) => Between(a, b - 1);

	double Between(double a, double b);
}

}
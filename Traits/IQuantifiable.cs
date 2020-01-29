interface IQuantifiable {
	int MaxQuantity { get; }

	int Quantity { get; }

	bool IsEmpty => Quantity <= 0;

	float PercentLeft => Quantity / (float)MaxQuantity;
}
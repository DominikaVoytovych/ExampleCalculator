namespace ExampleCalculator
{
    public class CalculatorEngine
    {
        public double StoredValue { get; private set; } = 0;
        public double CurrentValue { get; set; } = 0;
        public string CurrentOperation { get; private set; } = string.Empty;
        private bool _isNewEntry = true;


        public double SetOperation(string operation, double inputValue)
        {
            if (!string.IsNullOrEmpty(CurrentOperation) && !_isNewEntry)
            {
                StoredValue = Calculate(StoredValue, inputValue, CurrentOperation);
            }
            else
            {
                StoredValue = inputValue;
            }

            CurrentOperation = operation;
            _isNewEntry = true;
            return StoredValue;
        }

        //Результат
        public double CalculateResult(double inputValue)
        {
            if (string.IsNullOrEmpty(CurrentOperation))
                return inputValue;

            double result = Calculate(StoredValue, inputValue, CurrentOperation);
            StoredValue = 0;
            CurrentOperation = string.Empty;
            _isNewEntry = true;
            return result;
        }

        //Обчислення
        private double Calculate(double val1, double val2, string operation)
        {
            return operation switch
            {
                "+" => val1 + val2,
                "−" => val1 - val2,
                "×" => val1 * val2,
                "÷" => val2 != 0 ? val1 / val2 : 0, // Захист від ділення на нуль
                _ => val2
            };
        }

        //Очищення
        public void Clear()
        {
            StoredValue = 0;
            CurrentValue = 0;
            CurrentOperation = string.Empty;
            _isNewEntry = true;
        }
    }
}
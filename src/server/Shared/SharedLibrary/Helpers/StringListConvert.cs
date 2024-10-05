namespace SharedLibrary.Helpers
{
    public static class StringListConvert
    {
        public static List<T> ConvertToList<T>(string input, char spliceChar = ',')
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<T>(); 
            }

            var result = input.Split(spliceChar);

            var returnValue = new List<T>();

            foreach (var item in result) {
                var value = (T)Convert.ChangeType(item, typeof(T));

                if (value is null)
                    continue;

                returnValue.Add(value);
            }

           return returnValue;
                                
        }

        public static string ConverToString<T>(List<T> inputs, char spliceChar = ',')
        {
            if(inputs is null || !inputs.Any())
                return string.Empty;

            return string.Join(spliceChar, inputs);
        }
    }
}

using System.Collections.Generic;

namespace CurrencyToTextConverter
{
    public class NumberToTextTranslator
    {
        private const double MaxValue = 999999999.99;
        private const int Million = 1000000;
        private const int Thousand = 1000;
        private const int Hundred = 100;

        EnglishVocabluraly vocabluraly = new EnglishVocabluraly();

        public string Convert(int value)
        {
            Queue<string> words = new Queue<string>();

            if (value == 0)
                return vocabluraly.GetWordForNumber(value);

            if (value >= Million)
            {
                var millionPart = value / Million;
                
                Translate(millionPart, words);
                words.Enqueue(vocabluraly.Million);

                value = value % Million;
            }
            if (value >= Thousand)
            {
                var thousandPart = value / Thousand;

                Translate(thousandPart, words);
                words.Enqueue(vocabluraly.Thousand);

                value = value % Thousand;
            }

            Translate(value, words);

            return string.Join(" ", words);
        }

        private void Translate(int value, Queue<string> words)
        {
            var hundreds = value / Hundred;
            if (hundreds > 0)
            {
                words.Enqueue(vocabluraly.GetWordForNumber(hundreds));
                words.Enqueue(vocabluraly.Hundred);
            }

            var tens = value % 100;
            if(tens == 0)
            {
                return;
            }
            else if (tens >= 20)
            {
                var dig = tens % 10;
                var dec = tens - dig;
                string word = vocabluraly.GetWordForNumber(dec);

                if (dig > 0)
                    word = $"{word}-{vocabluraly.GetWordForNumber(dig)}";

                words.Enqueue(word);
            }
            else
            {
                words.Enqueue(vocabluraly.GetWordForNumber(tens));
            }
        }
    }
}

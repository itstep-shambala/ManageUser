using System;
using System.IO;
using System.Text.Json;

namespace CheckPassword
{
    public class CheckPassword
    {
        public PasswordRules importRules(string path)
        {var rules = new PasswordRules();
            using (var file = new FileStream(path, FileMode.Open))
            { 
                rules = JsonSerializer.DeserializeAsync<PasswordRules>(file).Result;
            }
            return rules; 
        }

        public bool PasswordCheck(string password, string pathToRules)
        {
            bool check = false;
            int capLetterCountRus = 0;
            int capLetterCountEn = 0;
            int smallLetterCountRus = 0;
            int smallLetterCountEn = 0;
            int intCount = 0;
            int symbolCount = 0;
            
            var rules = importRules(pathToRules);
            
            capLetterCountRus = CapLettersRusCount(password, rules);
            capLetterCountEn = CapLettersEnCount(password, rules);
            smallLetterCountRus = SmallLettersRusCount(password, rules);
            smallLetterCountEn = SmallLettersEnCount(password, rules);
            intCount = IntCount(password, rules);
            symbolCount = SymbolsCount(password, rules);
            
            if (password.Length >= rules.MinLen && capLetterCountRus+capLetterCountEn >= rules.MinCapLetter && smallLetterCountRus+smallLetterCountEn >= rules.MinSmallLetter && intCount >=rules.MinInt &&
                    symbolCount >= rules.MinSymbol)
                {
                    check = true;
                }
            if (rules.EnYesNo== 0 && capLetterCountEn+smallLetterCountEn>0 || rules.RusYesNo== 0 && capLetterCountRus+smallLetterCountRus>0)
            {
                check = false;
            }
            return check;
        }

        int CapLettersRusCount(string password, PasswordRules rules)
        {
            int count = 0;

            foreach (var letter in password)
            {
                foreach (var capLetterRus in rules.CapLettersRus)
                {
                    if (letter == capLetterRus)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
        
        int SmallLettersRusCount(string password, PasswordRules rules)
        {
            int count = 0;

            foreach (var letter in password)
            {
                foreach (var smallLetterRus in rules.SmallLettersRus)
                {
                    if (letter == smallLetterRus)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
        
        int CapLettersEnCount(string password, PasswordRules rules)
        {
            int count = 0;

            foreach (var letter in password)
            {
                foreach (var capLetterEn in rules.CapLettersEn)
                {
                    if (letter == capLetterEn)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
        
        int SmallLettersEnCount(string password, PasswordRules rules)
        {
            int count = 0;

            foreach (var letter in password)
            {
                foreach (var smallLetterEn in rules.SmallLettersEn)
                {
                    if (letter == smallLetterEn)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
        
        int SymbolsCount(string password, PasswordRules rules)
        {
            int count = 0;
            
            foreach (var letter in password)
            {
                foreach (var symbol in rules.Symbols)
                {
                    if (letter == symbol)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        
        int IntCount(string password, PasswordRules rules)
        {
            int count = 0;

            foreach (var letter in password)
            {
                foreach (var _int in rules.Int)
                {
                    if (letter == _int)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
    }
}
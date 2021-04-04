using System;
using System.IO;
using static CheckPassword.PasswordRules;
using System.Text.Json;

namespace CheckPassword
{
    public class CheckPassword
    {
        public PasswordRules importRules()
        {var rules = new PasswordRules();
            using (var file = new FileStream("PasswordRules.json", FileMode.Open))
            { 
                rules = JsonSerializer.DeserializeAsync<PasswordRules>(file).Result;
            }
            return rules; 
        }

        public int PasswordCheck(string password)
        {
            int check = 0;
            int capLetterCount = 0;
            int smallLetterCount = 0;
            int intCount = 0;
            int symbolCount = 0;
            
            var rules = new PasswordRules();
            rules = importRules();
            string pass = password;
            for (int i = 0; i < pass.Length; ++i)
            {
                int symNum = (int)Convert.ToChar(pass[i]);

                if (symNum >= 65 & symNum <= 90 | symNum >= 65 & symNum <= 90)
                { 
                    capLetterCount++;
                 }
                if (symNum >= 97 & symNum <= 122 | symNum >= 224 & symNum <= 255)
                { 
                    smallLetterCount++;
                }
                if (symNum >= 48 & symNum <= 57)
                { 
                    intCount++;
                }
                if (symNum >= 33 & symNum <= 47 | symNum >= 58 & symNum <= 64 | symNum >= 91 & symNum <= 96 | symNum >= 123 & symNum <= 126)
                { 
                    symbolCount++;
                }

                if (pass.Length >= rules.MinLen & capLetterCount != 0 & smallLetterCount != 0 & intCount != 0 &
                    symbolCount != 0)
                {
                    check = 1;
                }
            }
            return check;
        }
    }
}
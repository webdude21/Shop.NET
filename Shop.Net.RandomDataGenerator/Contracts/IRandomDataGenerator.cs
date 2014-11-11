namespace RandomDataGenerator.Contracts
{
    using System;

    public interface IRandomDataGenerator
    {
        string GetStringExact(int length, string charsToUse);

        string GetStringExact(int length);

        string GetString(int min, int max);

        string GetString(int min, int max, string charsToUse);

        int GetInt(int min, int max);

        DateTime GeneraDateTime();

        double GetDouble();

        bool GetChance(int percent);
    }
}
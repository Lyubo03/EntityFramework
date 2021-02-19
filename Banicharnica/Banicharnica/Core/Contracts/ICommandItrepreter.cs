namespace App.Core.Contracts
{
    public interface ICommandItrepreter
    {
        string Read(string[] input);
    }
}
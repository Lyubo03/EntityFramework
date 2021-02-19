namespace App.Core.Contracts
{
    public interface ICommnad
    {
        string Execute(string[] args);
    }
}
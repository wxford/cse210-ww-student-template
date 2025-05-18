public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public string GetDisplayString()
    {
        return $"\nDate: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
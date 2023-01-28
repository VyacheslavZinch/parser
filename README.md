Simple parser.
Search links on page.

This project using IE COM-object for getting data from site.
https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa752084(v=vs.85)


Interface IFunctions contatins abstract method- public abstract List<string> ParsedLink(string html);

class CollectDataFromSearch - download data and put it to list of strings.

class GetInfoFromData - format data and show them for user.

